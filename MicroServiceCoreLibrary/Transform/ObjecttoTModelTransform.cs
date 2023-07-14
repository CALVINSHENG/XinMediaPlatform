#region SonarLint Disabled 放置區域
#pragma warning disable S1066
//警告 S1066   Merge this if statement with the enclosing one.MicroServiceCoreLibrary
#pragma warning disable S125
//警告 S125 Remove this commented out code.MicroServiceCoreLibrary
#pragma warning disable S112
//警告 S112 'System.Exception' should not be thrown by user code.MicroServiceCoreLibrary
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable CS8604 // 可能有 Null 參考引數。
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#endregion

using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Security;
using System.Collections;
using System.Reflection;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreLibrary.Transform
{
    /// <summary>
    /// 具加解密特性值數據模型
    /// </summary>
    public static class ObjecttoTModelTransform
    {
        /// <summary>
        /// 組成參數值前：取得特性值決定是否進行加解密程序<br/>
        /// </summary>
        /// <param name="refModel">資料模型</param>
        /// <param name="props">特性集合</param>
        /// <param name="SecurityKey">加解密金鑰</param>
        /// <param name="securityType">進行加密或是解密</param>
        /// <param name="encoderType">加解密類型</param>
        /// <returns></returns>
        public static bool DynamictoTModel(
            IEnumerable refModel
            , PropertyInfo[] props
            , string? SecurityKey
            , SecurityType securityType
            , EncoderType encoderType)
        {
            try
            {
                foreach (var item in refModel)
                {
                    foreach (PropertyInfo prop in props)
                    {
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
                                * 編輯作者：ADD BY CALVIN AT 2023/01/05
                                * 說明：
                                * 針對NeedEnDecriptAttribute>EnDeSignal進行檢查
                                * 如果 attriField.EnDeSignal == true
                                * 將進行資料加解密後資料更換程序
                                */
                                if (attriField.EnDeSignal)
                                {
                                    /*
                                    * 編輯作者：ADD BY CALVIN AT 2023/01/05
                                    * 說明：取得資料庫原始欄位值
                                    */
                                    var fieldValues = item.GetType().GetProperty(attriField.FieldName).GetValue(item, null).ToString();
                                    /*
                                    * 編輯作者：ADD BY CALVIN AT 2023/01/05
                                    * 說明：將加解密後的機敏資料覆蓋資料庫原始欄位值
                                    */
                                    switch (securityType)
                                    {
                                        case SecurityType.EnCryiption:
                                            item.GetType().GetProperty(attriField.FieldName).SetValue(item, EnDeCryptionIntegrateSecurity.Encrypt(encoderType, fieldValues, SecurityKey));
                                            break;
                                        case SecurityType.DeCryiption:
                                            item.GetType().GetProperty(attriField.FieldName).SetValue(item, EnDeCryptionIntegrateSecurity.Decrypt(encoderType, fieldValues, SecurityKey));
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw new Exception(ex.Message);
            }
        }
    }
}
