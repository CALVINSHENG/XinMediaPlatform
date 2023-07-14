#region SonarLint Disabled 放置區域
#pragma warning disable S125
//嚴重性	程式碼	說明
//警告	S125	Remove this commented out code.
#pragma warning disable S112
//嚴重性 程式碼 說明 專案  檔案 行   隱藏項目狀態
//警告  S112	'System.Exception' should not be thrown by user code
#pragma warning disable CS8604 // 可能有 Null 參考引數。
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#pragma warning disable S2259 // Null pointers should not be dereferenced
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreResposity.DbAccess.T4_Design_Time;
using System.Reflection;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    /// <summary>
    /// 多語系共用函式庫
    /// </summary>
    public static class LanguageCultureHelper
    {
        /// <summary>
        /// Gets the lans.
        /// 取得多語系設定json
        /// </summary>
        /// <param name="LangCultureName">Name of the language culture.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">
        /// 解析多語系失敗，無設定 TypeName 設定值
        /// or
        /// 解析多語系失敗，缺少 DefaultValue 設定值
        /// </exception>
        public static string GetLans(string LangCultureName, string PageInfor)
        {
            var strLansJson = string.Empty;
            try
            {
                string? SEGMENTSYMBOL = string.Empty;
                string? Join_SegmentSymbol = string.Empty;
                char Split_SegmentSymbol;

                SEGMENTSYMBOL = new GetConfigHelper()
                        .GetConfig(
                            ConfigTargetType.ServiceDefault
                            , "SegmentSymbol:EventCodeSegmentSymbol"
                        );
                Join_SegmentSymbol = new GetConfigHelper()
                        .GetConfig(
                            ConfigTargetType.ServiceDefault
                            , "SegmentSymbol:StringJoinSegmentSymbol"
                        );
                Split_SegmentSymbol = Convert.ToChar(Join_SegmentSymbol);

                var props = typeof(VendorLanguageCode).GetProperties();

                #region JSON結構
                //List<TVendorLanguageModel> languageFamilyModel = new();
                //List<string> list = new();
                //List<string> Lans = new();
                //List<string> ListLans = new();
                //var LastName = string.Empty;
                //var fieldName = string.Empty;
                //bool Lock = false;
                //foreach (PropertyInfo prop in props)
                //{
                //	object[] attrs = prop.GetCustomAttributes(true);

                //	foreach (object attr in attrs)
                //	{
                //		if (attr is ColumnsLanguageAttribute attriField)
                //		{
                //			var responsed = string.Empty;
                //			var responsedLans = string.Empty;
                //			/*
                //			* 編輯作者：ADD BY CALVIN AT 2023/03/05
                //			* 說明：欄位名稱
                //			*       欄位型態
                //			*/
                //			fieldName = attriField.Name;
                //			var fieldType = attriField.TypeName;
                //			var fieldPage = attriField.DefaultValue.Split(SEGMENTSYMBOL)[2].ToString();
                //			var fieldLans = attriField.DefaultValue.Split(SEGMENTSYMBOL)[3].ToString();
                //			list.Add(fieldName ?? string.Empty);
                //			Lans.Add(fieldLans ?? string.Empty);
                //			ListLans.Add(fieldLans ?? string.Empty);
                //			responsed = String.Join(",", list.ToArray());
                //			responsedLans = String.Join(",", Lans.ToArray());
                //			if (responsed != "" && (!Lock))
                //			{
                //				char[] separator = { ',' };
                //				languageFamilyModel.Add(
                //					new TVendorLanguageModel()
                //					{
                //						id = fieldName
                //						,
                //						type = fieldType
                //						,
                //						page = fieldPage
                //						,
                //						value1 = responsedLans.Split(separator)
                //						,
                //						value2 = ListLans
                //						,
                //						value3 = new Lans()
                //						{
                //							language = fieldLans
                //						}
                //					});
                //			}
                //		}
                //	}
                //	if (LastName != fieldName)
                //	{
                //		Lans.Clear();
                //		list.Clear();
                //		Lock = false;
                //	}
                //	else
                //	{
                //		Lock = true;
                //	}
                //	LastName = fieldName;
                //}
                #endregion

                var LangsCultureIndex =
                            DataConversion.ParseInt(
                                EnumExtenstion.GetDescription(
                                    (VendorLanguageList)Enum.Parse(
                                        typeof(VendorLanguageList)
                                        , LangCultureName.Replace('-', '_')
                                    )
                                )
                                , 0
                            );

                var id = string.Empty;
                var structs = string.Empty;
                var page = string.Empty;
                var lastID = string.Empty;
                List<string> list = new();
                foreach (PropertyInfo prop in props)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        if (attr is ColumnsLanguageAttribute attriField)
                        {
                            id = attriField.Name;
                            page = attriField.DefaultValue?.Split(SEGMENTSYMBOL)[3].ToString();
                            if (
                                    !(lastID.ToLower().Equals(id?.ToLower()))
                                    &&
                                    (page.ToLower().Equals(PageInfor.ToLower()))
                                )
                            {
                                list.Add(id);
                            }
                        }
                    }
                    lastID = id;
                }

                var LansList = String.Join(
                            Join_SegmentSymbol
                            , list.ToArray()
                        );

                StringBuilder LansBuilder = new();
                LansBuilder.Append('{');
                if (LansList != "")
                {
                    char[] separator = { Split_SegmentSymbol };
                    string[]? ArrayLansList = LansList.ToString().Split(separator);
                    foreach (string item in ArrayLansList)
                    {
                        var index = 0;
                        var isRepeat = true;
                        var searchItem = item.ToLower();
                        var groupData = props.Where(t => t.Name.ToLower().Contains(searchItem));
                        var indexJsonTail = groupData.Count();
                        foreach (PropertyInfo prop in groupData)
                        {
                            object[] attrs = prop.GetCustomAttributes(true);
                            foreach (object attr in attrs)
                            {
                                if (attr is ColumnsLanguageAttribute attriField)
                                {
                                    id = attriField.Name;
                                    structs = attriField.TypeName ?? throw new Exception("解析多語系失敗，無設定 TypeName 設定值");
                                    var _defaultValue = attriField.DefaultValue ?? throw new Exception("解析多語系失敗，缺少 DefaultValue 設定值");
                                    page = _defaultValue.Split(SEGMENTSYMBOL)[3].ToString();
                                    var value = _defaultValue.Split(SEGMENTSYMBOL)[LangsCultureIndex].ToString();
                                    if (structs.ToLower().Equals("value"))
                                    {
                                        LansBuilder.Append('\"').Append(id).Append("\":[{");
                                        LansBuilder.Append("\"structs\":").Append('\"').Append(structs).Append("\",");
                                        LansBuilder.Append("\"type\":").Append('0').Append(',');
                                        LansBuilder.Append("\"page\":").Append('\"').Append(page).Append("\",");
                                        LansBuilder.Append("\"value\":").Append('\"').Append(value).Append('\"');
                                        LansBuilder.Append("}]");
                                    }
                                    else
                                    {
                                        if (isRepeat)
                                        {
                                            LansBuilder.Append('\"').Append(id).Append("\":[{");
                                            LansBuilder.Append("\"structs\":").Append('\"').Append(structs).Append("\",");
                                            LansBuilder.Append("\"type\":").Append('0').Append(',');
                                            LansBuilder.Append("\"page\":").Append('\"').Append(page).Append("\",");
                                            LansBuilder.Append("\"value\":").Append('[').Append('\"').Append(value).Append('\"');
                                            isRepeat = false;
                                        }
                                        else
                                        {
                                            LansBuilder.Append('\"').Append(value).Append("\"");
                                        }
                                    }
                                }
                                if ((index >= (indexJsonTail - 1)) && (structs.ToLower().Equals("array")))
                                {
                                    LansBuilder.Append("]}]");
                                }
                            }
                            index++;
                            LansBuilder.Append(',');
                        }
                    }
                    LansBuilder.Append('}');
                }
                else
                {
                    throw new Exception(string.Format("PageInfor {0} 查無符合資料", PageInfor));
                }

                strLansJson = LansBuilder.ToString().Replace(",}", "}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strLansJson;
        }
    }
}
