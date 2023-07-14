#region SonarLint Disabled 放置區域
//#pragma warning disable CS8600
#pragma warning disable CS8605
//警告 CS8605  Unboxing 可能 null 值。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	80	作用中
#pragma warning disable CS8625
//警告 CS8625  無法將 null 常值轉換成不可為 Null 的參考型別。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	82	作用中
#pragma warning disable S112
//警告 S112    'System.Exception' should not be thrown by user code.MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	84	作用中
#pragma warning disable S1118
//警告 S1118   Add a 'protected' constructor or the 'static' keyword to the class declaration.	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	105	作用中
#pragma warning disable S2971
//警告 S2971   Drop 'Where' and move the condition into the 'SingleOrDefault'.	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	146	作用中
#pragma warning disable S3928
//警告 S3928   Use a constructor overloads that allows a more meaningful exception message to be provided.MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs 143	作用中
#pragma warning disable CS8600
//警告 CS8600  正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	64	作用中
#pragma warning disable CS8603
//警告 CS8603  可能有 Null 參考傳回。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetEnumHelper.cs	46	作用中
#pragma warning disable IDE0019
//訊息 IDE0019 使用模式比對 MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\GetExtensionHelper.cs	182	作用中
#pragma warning disable S1854 // Unused assignments should be removed
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S2184 // Results of integer division should not be assigned to floating point variables
#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable IDE0018 // 內嵌變數宣告
#pragma warning disable S4136 // Method overloads should be grouped together
#pragma warning disable IDE0059 // 指派了不必要的值
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Drawing.Charts;
using MongoDB.Driver.Core.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Reflection;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreLibrary.Helper
{
    /// <summary>
    /// 資料型別轉換
    /// </summary>
    public static class DataConversion
    {
        #region Int methods

        /// <summary>
        ///Converts object to Integer if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static int ParseInt(this object value, int ifNone)
        {
            if (value == null)
            {
                return ifNone;
            }
            return ParseInt("" + value, ifNone);
        }

        /// <summary>
        ///Converts string to Integer if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static int ParseInt(this string value, int ifNone)
        {
            int i = ifNone;
            if (!int.TryParse(value, out i))
            {
                i = ifNone;
            }
            return i;
        }
        /// <summary>
        /// Parses the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="ifNone">If none.</param>
        /// <returns></returns>
        public static double ParseDouble(this string value, double ifNone)
        {
            double i = ifNone;
            if (!double.TryParse(value, out i))
            {
                i = ifNone;
            }
            return i;
        }
        #endregion

        #region Dec methods

        /// <summary>
        ///Converts object to decimal if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static decimal ParseDec(this object value, decimal ifNone)
        {
            if (value == null)
            {
                return ifNone;
            }
            return ParseDec("" + value, ifNone);
        }

        /// <summary>
        ///Converts string to decimal if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static decimal ParseDec(this string value, decimal ifNone)
        {
            decimal d = ifNone;
            if (!decimal.TryParse(value, out d))
            {
                d = ifNone;
            }
            return d;
        }

        #endregion

        #region Date methods

        /// <summary>
        ///Converts string to datetime if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static DateTime ParseDate(this string date, DateTime ifNone)
        {
            DateTime res = ifNone;
            if (!DateTime.TryParse(date, out res))
            {
                res = ifNone;
            }
            return res;
        }

        #endregion

        #region Long methods

        /// <summary>
        ///Converts object to long if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static long ParseLong(this object value, long ifNone)
        {
            if (value == null)
            {
                return ifNone;
            }
            return ParseLong("" + value, ifNone);
        }

        /// <summary>
        ///Converts string to long if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static long ParseLong(this string value, long ifNone)
        {
            long i = ifNone;
            if (!long.TryParse(value, out i))
            {
                i = ifNone;
            }
            return i;
        }

        #endregion

        #region Bool Methods
        /// <summary>
        ///Converts string to bool if the value is valid, otherwise returns ifnone value.
        /// </summary>
        public static bool ParseBool(this string value, bool ifNone = false)
        {
            bool res = ifNone;
            value = "" + value;
            if (value.Length > 1)
            {
                value = value.Substring(0, 1);
            }
            value = value.ToLower();
            if (value == "1" || value == "t" || value == "y")
            {
                res = true;
            }
            else if (value == "0" || value == "f" || value == "n")
            {
                res = false;
            }
            return res;
        }

        #endregion
    }

    /// <summary>
    /// 動態物件轉換成DB參數
    /// </summary>
    public static class ObjectTransformExtensions
    {
        /// <summary>
        /// 📰動態轉換為Dictionary格式
        /// 📰一般類型轉換(不附加"@")
        /// </summary>
        /// <param name="dynObj">物件格式</param>
        /// <returns>Dictionary<string, object>格式資料</returns>
        public static Dictionary<String, Object> DynamictoDictionary(dynamic dynObj)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
                {
                    object obj = propertyDescriptor.GetValue(dynObj);
                    dictionary.Add(propertyDescriptor.Name, obj);
                }
                return dictionary;
            }
            catch
            {
                var emptyDictionary = new Dictionary<string, object>();
                return emptyDictionary;
            }
        }
        /// <summary>
        /// 📰Dynamictoes the dictionary exclude list.
        /// 📰動態轉換為Dictionary格式但是排除掉模型內的List屬型(子類別)
        /// 📰一般轉換
        /// 📰附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <param name="ignoreFields">The ignore fields.-強制指定排除欄位(可忽略參數或是設為null)</param>
        /// <returns>Dictionary<string, object>格式資料</returns>
        public static Dictionary<String, Object> DynamictoDictionaryExcludeList(
            dynamic dynObj
            , string? fieldsPrefixSymbol
            , List<string>? ignoreFields = null)
        {
            try
            {
                var dictionary = new Dictionary<string, Object>();
                foreach (PropertyInfo propertyInfo in dynObj.GetType().GetProperties())
                {
                    if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string))
                    {
                        dictionary.Remove(propertyInfo.Name);
                    }
                    else
                    {
                        object obj = propertyInfo.GetValue(dynObj);
                        dictionary.Add(fieldsPrefixSymbol + propertyInfo.Name, obj);
                    }
                }
                if (ignoreFields is not null)
                {
                    foreach (var fieldName in ignoreFields)
                    {
                        dictionary.Remove(fieldsPrefixSymbol + fieldName);
                    }
                }
                return dictionary;
            }
            catch
            {
                var emptyDictionary = new Dictionary<string, object>();
                return emptyDictionary;
            }
        }
        /// <summary>
        /// 📰動態轉換為Dictionary格式
        /// 📰一般轉換
        /// 📰附加@記號
        /// </summary>
        /// <param name="dynObj">物件</param>
        /// <param name="fieldsPrefixSymbol">資料庫欄位附加指定標記符號</param>
        /// <returns>Dictionary<string, object>格式資料</returns>
        public static Dictionary<String, Object> DynamictoDictionary(
            dynamic dynObj
            , string? fieldsPrefixSymbol)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
                {
                    object obj = propertyDescriptor.GetValue(dynObj);
                    dictionary.Add(fieldsPrefixSymbol + propertyDescriptor.Name, obj);
                }
                return dictionary;
            }
            catch
            {
                var emptyDictionary = new Dictionary<string, object>();
                return emptyDictionary;
            }
        }
        /// <summary>
        /// 📰Dynamictoes the dynamic parameters.
        /// 📰動態轉換為DynamicParameters格式
        /// 📰一般轉換
        /// 📰附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <returns>DynamicParameters格式資料</returns>
        public static DynamicParameters DynamictoDynamicParameters(
            dynamic dynObj
            , string? fieldsPrefixSymbol)
        {
            try
            {
                var parameters = new DynamicParameters();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
                {
                    object obj = propertyDescriptor.GetValue(dynObj);
                    parameters.Add(fieldsPrefixSymbol + propertyDescriptor.Name, obj);
                }
                return parameters;
            }
            catch
            {
                var empty_parameters = new DynamicParameters();
                return empty_parameters;
            }
        }
        /// <summary>
        /// 📰Dynamictoes the dictionary exclude list.
        /// 📰動態轉換為DynamicParameters格式但是排除掉模型內的List屬型(子類別)
        /// 📰一般轉換
        /// 📰附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <returns>DynamicParameters格式資料</returns>
        public static DynamicParameters DynamictoDynamicParametersExcludeList(
            dynamic dynObj
            , string? fieldsPrefixSymbol)
        {
            try
            {
                var parameters = new DynamicParameters();
                foreach (PropertyInfo propertyInfo in dynObj.GetType().GetProperties())
                {
                    if (!(typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string)))
                    {
                        object obj = propertyInfo.GetValue(dynObj);
                        parameters.Add(fieldsPrefixSymbol + propertyInfo.Name, obj);
                    }
                }
                return parameters;
            }
            catch
            {
                var empty_parameters = new DynamicParameters();
                return empty_parameters;
            }
        }
    }

    public static class DateExtensions
    {
        /// <summary>
        /// Dates the difference.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="datepart">The datepart.</param>
        /// <param name="enddate">The enddate.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">You input a invalid datepart parameter.</exception>
        public static double DateDiff(this DateTime startdate, string datepart, DateTime enddate)
        {
            // 參考 SQL Server 2005 線上叢書：http://technet.microsoft.com/zh-tw/library/ms189794.aspx

            double result = 0;

            TimeSpan tsDiff = new TimeSpan(enddate.Ticks - startdate.Ticks);

            switch (datepart.ToLower())
            {
                case "year":
                case "yyyy":
                case "yy":
                    result = enddate.Year - startdate.Year;
                    break;

                case "quarter":
                case "qq":
                case "q":
                    // 每一季的平均天數
                    const double AvgQuarterDays = 365 / 4;
                    result = Math.Floor(tsDiff.TotalDays / AvgQuarterDays);
                    break;

                case "month":
                case "mm":
                case "m":
                    // 每一個月的平均天數
                    const double AvgMonthDays = 365 / 12;
                    result = Math.Floor(tsDiff.TotalDays / AvgMonthDays);
                    break;

                case "day":
                case "dd":
                case "d":
                    result = tsDiff.TotalDays;
                    break;

                case "week":
                case "wk":
                case "ww":
                    result = Math.Floor(tsDiff.TotalDays / 7);
                    break;

                case "hour":
                case "hh":
                    result = tsDiff.TotalHours;
                    break;

                case "minute":
                case "mi":
                case "n":
                    result = tsDiff.TotalMinutes;
                    break;

                case "second":
                case "ss":
                case "s":
                    result = tsDiff.TotalSeconds;
                    break;

                case "millisecond":
                case "ms":
                    result = tsDiff.TotalMilliseconds;
                    break;

                default:
                    throw new ArgumentException("You input a invalid datepart parameter.");
            }

            return result;
        }

        /// <summary>
        /// Dates the add.
        /// 日期增量
        /// </summary>
        /// <param name="inputDate">The input date.</param>
        /// <param name="dateAddUnit">The date add unit.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public static DateTime DateAdd(this string inputDate, string dateAddUnit, long quantity)
        {
            DateTime pointDate = inputDate.ToNullableDate();

            int vOut = Convert.ToInt32(quantity);
            pointDate = dateAddUnit switch
            {
                //years
                "years" => pointDate.AddYears(vOut),
                //months
                "months" => pointDate.AddMonths(vOut),
                //days
                "days" => pointDate.AddDays(quantity),
                //hours
                "hours" => pointDate.AddHours(quantity),
                //minutes
                "minutes" => pointDate.AddMinutes(quantity),
                //seconds
                "seconds" => pointDate.AddSeconds(quantity),
                //milliseconds
                "milliseconds" => pointDate.AddMilliseconds(quantity),
                //ticks
                "ticks" => pointDate.AddTicks(quantity),
                //無法識別
                _ => throw new ArgumentException("You have a wrong date increment."),
            };

            return pointDate;
        }

        /// <summary>
        /// 字符串到日期時間擴展Convert.* 
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime ToNullableDate(this String dateString)
        {
            //if (String.IsNullOrEmpty((dateString ?? "").Trim()))
            //    return null;

            DateTime resultDate;
            if (DateTime.TryParse(dateString, out resultDate))
                return resultDate;

            throw new Exception("無法轉換日期");
        }
    }

    /// <summary>
    /// 列舉的擴充方法
    /// </summary>
    public static class EnumExtenstion
    {
        /// <summary>
        /// 回傳 Enum 的 Description 屬性，如果沒有 Description 屬性就回傳列舉成員名稱
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes
                                    (
                                        typeof(DescriptionAttribute), false
                                    ).FirstOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
    /// <summary>
    /// 擴展方法 String對象
    /// </summary>
    public static class CommonExtension
    {
        public static object OrDBNull(this String value)
        {
            return String.IsNullOrEmpty(value) ? DBNull.Value : value;
        }
    }
    /// <summary>
    /// 擴展方法 SqlParameterCollection對象
    /// </summary>
    public static class ParameterExtensions
    {
        public static void AddString(this SqlParameterCollection collection, string parameterName, string value)
        {
            collection.AddWithValue(parameterName, String.IsNullOrEmpty(value) ? DBNull.Value : value);
        }
    }

    /// <summary>
    /// 為所有數據類型擴展 TryParse
    /// Example：
    /// var invalidTest = "12345".ParseTo<DateTime>();
    /// var validTest = "12345".ParseTo<int>();
    /// var veryInvalidTest = "12345".ParseTo<Test>();
    /// 
    /// Console.WriteLine(!invalidTest.HasValue? "<null>" : invalidTest.Value.ToString());
    /// Console.WriteLine(!validTest.HasValue? "<null>" : validTest.Value.ToString());
    /// </summary>
    public static class TryParseExtensions
    {
        public static T? ParseTo<T>(this string inputValue) where T : struct
        {
            var method = typeof(T)
                                .GetMethod(
                                    "TryParse"
                                    , new Type[] {
                                        typeof(string)
                                        , typeof(T).MakeByRefType()
                                    }
                                );

            if (method == null)
            {
                /*
                * 編輯作者：REMARK BY CALVIN AT 2023/03/22
                * 說明：無法進行解析作業，拋出例外
                * 備註：or return null or whatever
                */
                throw new Exception
                    (
                        string.Format("TryParse程序失敗：解析數值 {0} ", inputValue)
                    );
            }
            else
            {
                var parameters = new object[] { inputValue, null };

                if ((bool)method.Invoke(null, parameters))
                {
                    /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/03/22
                    * 說明：解析成功
                    * 備註：
                    */
                    return (T)parameters[1];
                }
                else
                {
                    /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/03/22
                    * 說明：解析失敗
                    * 備註：
                    */
                    return null;
                }
            }
        }
    }

    public class GetExtensionHelper
    {
        /// <summary>
        /// Roles the item rlace.
        /// </summary>
        /// <param name="targetEnum">The target enum.</param>
        /// <returns></returns>
        public static string RoleItemPlace(DataTypeCollection targetEnum)
        {
            return targetEnum.GetDescription();
        }
        /// <summary>
        /// 
        /// </summary>
        public static class Get
        {
            public static string GetDescriptionFromEnumValue(Enum value)
            {
                DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }
            /// <summary>
            /// Gets the enum value from description.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="description">The description.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentException"></exception>
            public static T GetEnumValueFromDescription<T>(string description)
            {
                var type = typeof(T);
                if (!type.IsEnum)
                    throw new ArgumentException();
                FieldInfo[] fields = type.GetFields();
                var field = fields
                                .SelectMany(f => f.GetCustomAttributes(
                                    typeof(DescriptionAttribute), false), (
                                        f, a) => new { Field = f, Att = a })
                                .Where(a => ((DescriptionAttribute)a.Att)
                                    .Description == description).SingleOrDefault();
                return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
            }
        }
    }
}
