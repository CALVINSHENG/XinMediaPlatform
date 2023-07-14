using System.Security.Cryptography;
using System.Text;

namespace MicroServiceCoreLibrary.Security.EnDeCryption
{
    #region SonarLint Disabled 放置區域
#pragma warning disable SYSLIB0021
#pragma warning disable S125
#pragma warning disable S112
#pragma warning disable S1854
#pragma warning disable CS8600

    #endregion

    /// <summary>
    /// AES+MD5+SHA384
    /// 加解密工具
    /// 
    /// 加解密Class：
    /// 例DB連線字串
    /// User ID
    /// Password
    /// </summary>
    public static class EnDeCryptionV4Security
    {
        //加解密金鑰，請自行設定
        //private static readonly string sCryptoKey = "LIONELDPLAT";

        /// <summary>
        /// Aes字串加密
        /// </summary>
        /// <param name="sCryptoKey">金鑰</param>
        /// <param name="sSource">加密前字串</param>
        /// <returns>加密後字串</returns>
        public static string AesEncryptBase64(string sCryptoKey, string sSource)
        {
            string encrypt = "";

            if (string.IsNullOrEmpty(sCryptoKey) && string.IsNullOrEmpty(sSource))
            {
                throw new Exception("發生錯誤：加密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(sSource))
            {
                throw new Exception("發生錯誤：加密資料未給值");
            }
            else if (string.IsNullOrEmpty(sCryptoKey))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
                    byte[] key = sha384.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    byte[] dataByteArray = Encoding.UTF8.GetBytes(sSource);
                    using (MemoryStream ms = new MemoryStream())
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        encrypt = System.Convert.ToBase64String(ms.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            return encrypt;
        }

        /// <summary>
        /// Aes字串解密
        /// </summary>
        /// <param name="sCryptoKey">金鑰</param>
        /// <param name="sEncrypt">解密前字串</param>
        /// <returns>解密後字串</returns>
        public static string AesDecryptBase64(string sCryptoKey, string sEncrypt)
        {
            string decrypt = "";

            if (string.IsNullOrEmpty(sCryptoKey) && string.IsNullOrEmpty(sEncrypt))
            {
                throw new Exception("發生錯誤：解密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(sEncrypt))
            {
                throw new Exception("發生錯誤：解密資料未給值");
            }
            else if (string.IsNullOrEmpty(sCryptoKey))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
                    byte[] key = sha384.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    byte[] dataByteArray = System.Convert.FromBase64String(sEncrypt);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(dataByteArray, 0, dataByteArray.Length);
                            cs.FlushFinalBlock();
                            decrypt = Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            return decrypt;
        }

        /// <summary>
        /// 對字串產生MD5 HashCode，用於比對檔案HashCode
        /// </summary>
        /// <param name="sData">資料字串</param>
        /// <returns>MD5 HashCode</returns>
        public static string ComputeMD5Hash(string sData)
        {
            if (string.IsNullOrEmpty(sData))
            {
                throw new Exception("發生錯誤：檔案比對資料字串未給值");
            }
            else
            {
                try
                {
                    byte[] byteResult;
                    MD5? oMD5 = new MD5CryptoServiceProvider();

                    byteResult = oMD5.ComputeHash(Encoding.UTF8.GetBytes(sData));
                    oMD5 = null;
                    return System.Convert.ToBase64String(byteResult);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 對字串產生MD5 HashCode，用於比對檔案HashCode
        /// </summary>
        /// <param name="sFile">檔案路徑及名稱</param>
        /// <returns>MD5 HashCode</returns>
        public static string GetFileMD5Hash(string sFile)
        {
            if (string.IsNullOrEmpty(sFile))
            {
                throw new Exception("發生錯誤：檔案比對檔案路徑及名稱未給值");
            }
            else
            {
                try
                {
                    StreamReader oSR;
                    oSR = File.OpenText(sFile);
                    string sResult = ComputeMD5Hash(oSR.ReadToEnd());
                    oSR.Close();
                    oSR = null;
                    return sResult;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 將字串轉成Base 64
        /// </summary>
        /// <param name="plainText">plain Text</param>
        /// <returns>base64 data</returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.Default.GetBytes(plainText);
            //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// 將Base64轉成字串
        /// </summary>
        /// <param name="base64EncodedData">base64 data</param>
        /// <returns>plain text</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Encoding.Default.GetString(base64EncodedBytes);
            //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
