#region SonarLint Disabled 放置區域
#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S2259 // Null pointers should not be dereferenced
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using Dapper;
using DapperQueryBuilder;
using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Common;
using MicroServiceCoreLibrary.Models;
using MicroServiceCoreLibrary.Models.InputType;
using MicroServiceCoreResposity.Models.Filter;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text;
using BaseLogger = MicroServiceCoreLibrary.Logger.BaseLogger;

namespace MicroServiceCoreLibrary.Helper
{
    /// <summary>
    /// FilterHelper
    /// </summary>
    public class FilterHelper
    {
        #region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
        /// <summary>
        /// The baselogger
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterHelper"/> class.
        /// </summary>
        /// <param name="baselogger">The baselogger.</param>
        public FilterHelper(ILogger<BaseLogger>? baselogger)
        {
            _baselogger = baselogger;
        }
        public FilterHelper() { }

        #endregion

        /*
        *  編輯作者：ADD BY Shan AT 2023/03/29
        *  說    明：
        *      1.用於複合條件(過濾器)查詢。(查詢結果含分頁 PageInfo)
        *      2.目的為 i. 轉換前端傳來之運算子 EX: "is_less_than" => "<="
        *               ii. 動態組成 SQL WHERE 子句
        *               iii. 查詢結果(含分頁查詢) 
        *      3. FilterHelper包含回傳格式
        *          => Function的return須以 FilterHelperResult<TFilterListContentModel>包裝 
        *          ※TFilterListContentModel需自定義，參考其他Service
        *          ※TFilterListContentModel須包含Properties(Name, TypeName, IsCondition, displayType, LanguageName)
        *      4. InputType的filter格式統一為 Library.Models.InputType.FilterInputType.cs
        *      5. Select語法、已知固定條件於呼叫Helper前定義好，語法內設定 where, orderby ※符號、大小寫不可變。
        *      6. 客製化欄位以 List<FilterCustomModel>包覆， CustomFIeld = 自定義欄位, CustomSQLColumn = SQL替代語法(可參考BusService) 
        *      7.！！！Filter內客製化欄位若不能用SQL語法處理則不適用
        *  備    註：
        *      參數說明：1. conn => MSGetConfig.AutoEstablishConnection()：此次查詢交易連線
        *                2. selectQuery => 查詢資料SQL語法(含分頁查詢)
        *                3. pagecondition => 查詢資料總筆數SQL語法(提供PageInfo給前端)
        *                4. filterList => InputType中的filter格式統一為 Library.Models.InputType.FilterInputType(可為Null)
        *                5. pageinfo => InputType需傳入前端提供之分頁資訊(PageInfo格式)
        *                6. filter_needed => 是否需回傳Filter資訊給前端
        *                7. filtercustom 客製化欄位 => 應用於不存在SQL之欄位，必須確認能改以SQL語法執行(參考Bus Service)
        *  引    用：
        *  ▓▓▓▓▓▓▓▓▓
        *  修改歷程：
        *  2023/03/29 初版
        */
        public FilterHelperResult<TFilterListContentModel> MultipleFilterQuery<TFilterListContentModel>(
            System.Data.IDbConnection conn
            , String selectQuery
            , SqlBuilder pagecondition
            , QueryBuilder pagetotal
            , List<FilterInputType>? filterList
            , PageInfo? pageinfo
            , bool? filter_needed = true
            , List<FilterCustomModel>? filtercustom = null
        ) where TFilterListContentModel : class
        {

            string symbol = "";
            string date_start = "";
            string date_end = "";
            var result = new FilterHelperResult<TFilterListContentModel>();

            try
            {
                if (filterList is not null && pageinfo is not null)
                {
                    foreach (var filter in filterList)
                    {
                        // 運算子判斷
                        if (filter.DataType.ToLower() == "string" && filter.Value is not null)
                        {
                            symbol = filter.ArrayConditions switch
                            {
                                "equal" => " = ",
                                "like" => " LIKE ",
                            };
                        }
                        else if (filter.DataType.ToLower() == "date" && filter.Value is not null)
                        {
                            symbol = filter.ArrayConditions switch
                            {
                                "before" => " <= ",
                                "after" => ">=",
                                _ => " BETWEEN ",
                            };
                            if (symbol == " BETWEEN ")
                            {
                                date_start = filter.Value.Split("-")[0];
                                date_end = filter.Value.Split("-")[1];
                            }
                        }
                        else
                        {
                            symbol = filter.ArrayConditions switch
                            {
                                "is_less_than" => " < ",
                                "is_less_than_or_equal_to" => " <= ",
                                "is_great_than" => " > ",
                                "is_great_than_or_equal_to" => " >= ",
                                "equal" => " = ",
                                _ => " LIKE ",
                            };
                        }
                        if (symbol == " LIKE ")
                        {
                            filter.Value = "%" + filter.Value + "%";
                        }

                        // SQL客製化欄位
                        if (filtercustom != null)
                        {
                            foreach (var item in filtercustom)
                            {
                                if (filter.Field_Name.ToLower() == item.CustomField)
                                {
                                    filter.Field_Name = item.CustomSQLColumn;
                                }
                            }
                        }

                        // WHERE子句組成
                        // message = 組合欲比較欄位 & 運算子
                        var message = System.Runtime.CompilerServices
                            .FormattableStringFactory.Create(
                                $"{filter.Field_Name}{symbol}"
                            );

                        if (filter.DataType.ToLower() == "date" && symbol == " BETWEEN ")
                        {
                            pagecondition.Where($"{message} '{date_start}' AND '{date_end}' ");
                            pagetotal.Where($" {message} {date_start} AND {date_end} ");
                        }
                        else
                        {
                            pagecondition.Where($" {message}'{filter.Value}'");
                            pagetotal.Where($"{message}{filter.Value}");
                        }
                    }
                }
                // Order 子句組成
                // 升冪降冪
                if ("asc".Equals(pageinfo.Arrangement))
                {
                    pagecondition.OrderBy(pageinfo.Orderby);
                }
                else if ("desc".Equals(pageinfo.Arrangement) || pageinfo.Arrangement is null)
                {
                    pagecondition.OrderBy(pageinfo.Orderby + " desc");
                }

                // 第幾頁及每頁幾筆
                var selector = pagecondition.AddTemplate(selectQuery, new { PageIndex = pageinfo.Page_Index, PageSize = pageinfo.Page_Size });

                // 查詢資料(分頁)
                var dataContent = conn.Query<TFilterListContentModel>(
                                selector.RawSql
                                , selector.Parameters
                            );

                // 回傳分頁資訊
                var pageInfo_result = new PageHelper().GetPageInfo(
                                pageinfo.Page_Size
                                , pageinfo.Page_Index
                                , pagetotal.ExecuteReader()
                            );

                // Return Model
                result = new FilterHelperResult<TFilterListContentModel>()
                {
                    ContentList = dataContent.AsList(),
                    PageInfo = pageInfo_result
                };
            }
            catch (Exception ex)
            {
                StringBuilder ExceptionMessage = new(NLogHelper.FetchCompleteMessage());
                _baselogger?.LogError(ex, ExceptionMessage.ToString());
            }
            finally
            {
                /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/02/19
                    * 說明：關閉並釋放交易連線
                    * 備註：
                    */
                conn.Close();
                conn.Dispose();
            }

            // 組成 FilterCondition
            if (filter_needed == true)
            {
                var props = typeof(TFilterListContentModel).GetProperties();
                List<TFilterListConditionModel> conditionModel = new();
                List<string> list = new();

                foreach (PropertyInfo prop in props)
                {
                    /*
                * 編輯作者：ADD BY CALVIN AT 2023/03/05
                * 說明：第二層(特性組合：欄位名稱+欄位描述)
                * 備註：所有資料模型欄位有掛載的特性都會被引入
                */
                    object[] attrs = prop.GetCustomAttributes(true);

                    foreach (object attr in attrs)
                    {
                        /*
                        * 編輯作者：ADD BY CALVIN AT 2023/03/05
                        * 說明：針對ColumnsAttribute > IsCondition進行檢查
                        *       如果 attriField.IsCondition == false
                        *       將被排除在Filter名單外
                        */
                        if (attr is ColumnsAttribute attriField
                            && attriField.IsCondition)
                        {
                            var responsed = string.Empty;
                            /*
                            * 編輯作者：ADD BY CALVIN AT 2023/03/05
                            * 說明：欄位名稱
                            *       欄位型態
                            */
                            var fieldName = attriField.Name;
                            var fieldType = attriField.TypeName;
                            var dataType = "";
                            var displayType = attriField.displayType;
                            var languageName = attriField.LanguageName;
                            /*
                            * 編輯作者：ADD BY CALVIN AT 2023/03/05
                            * 說明：根據欄位型態加入對應的條件式列舉
                            */
                            switch (fieldType.ToLower())
                            {
                                case "int":
                                    dataType = "int";
                                    foreach (string name in Enum.GetNames(typeof(ConditionForCommon)))
                                    {
                                        list.Add(name ?? string.Empty);
                                        //strConcat.Clear();
                                    }
                                    break;
                                case "varchar":
                                case "nvarchar":
                                    dataType = "string";
                                    foreach (string name in Enum.GetNames(typeof(ConditionForStringType)))
                                    {
                                        list.Add(name ?? string.Empty);
                                        //strConcat.Clear();
                                    }
                                    break;
                                case "date":
                                case "datetime":
                                case "datetime2":
                                case "datetimeoffset":
                                    dataType = "date";
                                    foreach (string name in Enum.GetNames(typeof(ConditionForDateType)))
                                    {
                                        list.Add(name ?? string.Empty);
                                        //strConcat.Clear();
                                    }
                                    break;
                                default:
                                    foreach (string name in Enum.GetNames(typeof(ConditionForCommon)))
                                    {
                                        list.Add(name ?? string.Empty);
                                        //strConcat.Clear();
                                    }
                                    break;
                            }
                            responsed = String.Join(",", list.ToArray());
                            if (responsed != "")
                            {
                                char separator = ',';
                                conditionModel.Add(
                                    new TFilterListConditionModel()
                                    {
                                        Field_Name = fieldName
                                        ,
                                        ArrayConditions = responsed.Split(separator)
                                        ,
                                        DataType = dataType
                                        ,
                                        DisplayType = displayType
                                        ,
                                        Label = languageName
                                    });
                            }
                        }
                    }
                    list.Clear();
                }
                result.ConditionList = conditionModel;
            }

            return result;
        }
    }
}
