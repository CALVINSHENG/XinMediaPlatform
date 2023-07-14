#region SonarLint Disabled 放置區域
#pragma warning disable S1066
//警告 S1066   Merge this if statement with the enclosing one.MicroServiceCoreLibrary
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S4136 // Method overloads should be grouped together
#pragma warning disable CS8604 // 可能有 Null 參考引數。
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using Dapper;
using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Common;
using MicroServiceCoreLibrary.Security;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreLibrary.Transform
{
    /// <summary>
    /// ObjecttoDictionaryTransform
    /// </summary>
    public static class ObjecttoDictionaryTransform
    {
        /// <summary>
        /// Dynamictoes the dictionary.
        /// 空的目錄
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, Object> GetEmptyDictionary()
        {
            var emptyDictionary = new Dictionary<string, object>();
            return emptyDictionary;
        }
        /// <summary>
        /// 動態轉換為Dictionary格式
        /// 一般轉換
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
        /// Dynamictoes the dictionary exclude list.
        /// 動態轉換為Dictionary格式但是排除掉模型內的List屬型(子類別)
        /// 一般轉換
        /// 附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件格式</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <returns>Dictionary<string, object>格式資料</returns>
        public static Dictionary<String, Object> DynamictoDictionaryExcludeList(dynamic dynObj, string? fieldsPrefixSymbol)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
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
                return dictionary;
            }
            catch
            {
                var emptyDictionary = new Dictionary<string, object>();
                return emptyDictionary;
            }
        }
        /// <summary>
        /// 動態轉換為Dictionary格式
        /// 一般轉換
        /// 附加@記號
        /// </summary>
        /// <param name="dynObj">物件格式</param>
        /// <param name="fieldsPrefixSymbol">資料庫欄位附加指定標記符號</param>
        /// <returns>Dictionary<string, object>格式資料</returns>
        public static Dictionary<String, Object> DynamictoDictionary(dynamic dynObj, string? fieldsPrefixSymbol)
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
        /// Dynamictoes the dynamic parameters.
        /// 動態轉換為DynamicParameters格式
        /// 一般轉換
        /// 附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件格式</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <returns>DynamicParameters格式資料</returns>
        public static DynamicParameters DynamictoDynamicParameters(dynamic dynObj, string? fieldsPrefixSymbol)
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
        /// Dynamictoes the dictionary exclude list.
        /// 動態轉換為DynamicParameters格式但是排除掉模型內的List屬型(子類別)
        /// 一般轉換
        /// 附加@記號
        /// </summary>
        /// <param name="dynObj">The dyn object.-物件格式</param>
        /// <param name="fieldsPrefixSymbol">The fields prefix symbol.-資料庫欄位附加指定標記符號</param>
        /// <returns>DynamicParameters格式資料</returns>
        public static DynamicParameters DynamictoDynamicParametersExcludeList(dynamic dynObj, string? fieldsPrefixSymbol)
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
        /// <summary>
        /// 組成參數值前<br/>
        /// 1.取得特性值決定是否進行加解密程序<br/>
        /// 2.加入組合Dapper資料庫欄位所需要前置修飾字元<br/>
        /// </summary>
        /// <param name="props">特性集合</param>
        /// <param name="dynObj">資料模型</param>
        /// <param name="SecurityKey">加解密金鑰</param>
        /// <param name="securityType">進行加密或是解密</param>
        /// <param name="encoderType">加解密類型</param>
        /// <param name="fieldsPrefixSymbol">前置修飾字元</param>
        /// <returns></returns>
        public static Dictionary<String, Object> DynamictoDictionary(
            PropertyInfo[] props
            , dynamic dynObj
            , string? SecurityKey
            , SecurityType securityType
            , EncoderType encoderType
            , string? fieldsPrefixSymbol = "")
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                var resourceNames = new List<string>();
                bool forceBreak = false;

                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
                {
                    object obj = propertyDescriptor.GetValue(dynObj);
                    /*
                    * 編輯作者：ADD BY CALVIN AT 2023/01/03
                    * 說明：第一層(資料模型：欄位名稱+欄位值)
                    */
                    foreach (PropertyInfo prop in props)
                    {
                        if (forceBreak)
                        {
                            /*
                            * 編輯作者：ADD BY CALVIN AT 2023/01/03
                            * 說明：幫篩選到重複的欄位時，強制跳出第二層返回第一層取下一個欄位名稱進行比對
                            */
                            forceBreak = false;
                            break;
                        }
                        /*
                        * 編輯作者：ADD BY CALVIN AT 2023/01/03
                        * 說明：第二層(特性組合：欄位名稱+欄位描述)
                        * 備註：所有資料模型欄位有掛載的特性都會被引入
                        */
                        object[] attrs = prop.GetCustomAttributes(true);

                        foreach (object attr in attrs)
                        {
                            if (attr is NeedEnDecriptAttribute attriField)
                            {
                                /*
                                * 編輯作者：ADD BY CALVIN AT 2023/01/03
                                * 說明：第三層(特性指定：欄位名稱+僅針對加解密的布林值特性)
                                * 備註：使用　if (attr is NeedEnDecriptAttribute attriField)　進行篩選
                                */
                                /*
                                * 編輯作者：ADD BY CALVIN AT 2023/01/03
                                * 說明：裝載 Dictionary<String, Object>
                                */
                                if (SearchTargetCommon.FindListDuplicates(resourceNames, propertyDescriptor.Name.ToLower()))
                                {
                                    if (attriField.FieldName.ToLower().Equals(propertyDescriptor.Name.ToLower()))
                                    {
                                        if (attriField.EnDeSignal)
                                        {
                                            if (string.IsNullOrEmpty(fieldsPrefixSymbol))
                                            {
                                                switch (securityType)
                                                {
                                                    case SecurityType.EnCryiption:
                                                        dictionary.Add(propertyDescriptor.Name, EnDeCryptionIntegrateSecurity.Encrypt(encoderType, obj.ToString(), SecurityKey));
                                                        break;
                                                    case SecurityType.DeCryiption:
                                                        dictionary.Add(propertyDescriptor.Name, EnDeCryptionIntegrateSecurity.Decrypt(encoderType, obj.ToString(), SecurityKey));
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (securityType)
                                                {
                                                    case SecurityType.EnCryiption:
                                                        dictionary.Add(fieldsPrefixSymbol + propertyDescriptor.Name, EnDeCryptionIntegrateSecurity.Encrypt(encoderType, obj.ToString(), SecurityKey));
                                                        break;
                                                    case SecurityType.DeCryiption:
                                                        dictionary.Add(fieldsPrefixSymbol + propertyDescriptor.Name, EnDeCryptionIntegrateSecurity.Decrypt(encoderType, obj.ToString(), SecurityKey));
                                                        break;
                                                }
                                            }
                                            resourceNames.Add(propertyDescriptor.Name.ToLower());
                                            forceBreak = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(fieldsPrefixSymbol))
                                            {
                                                dictionary.Add(propertyDescriptor.Name, obj);
                                            }
                                            else
                                            {
                                                dictionary.Add(fieldsPrefixSymbol + propertyDescriptor.Name, obj);
                                            }
                                            resourceNames.Add(propertyDescriptor.Name.ToLower());
                                            forceBreak = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
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
    }
}
