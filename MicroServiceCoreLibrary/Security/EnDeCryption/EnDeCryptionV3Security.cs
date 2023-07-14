using System.Security.Cryptography;
using System.Text;

namespace MicroServiceCoreLibrary.Security.EnDeCryption
{
    #region SonarLint Disabled 放置區域
#pragma warning disable SYSLIB0021
#pragma warning disable S112
    //[一般異常不應該被拋出 ]

    #endregion

    /// <summary>
    /// AES within SymmetricKey
    /// 加解密工具
    /// 
    /// AesOperation
    /// </summary>
    public static class EnDeCryptionV3Security
    {
        /// <summary>
        /// 字串加密
        /// </summary>
        /// <param name="sCryptoKey">金鑰</param>
        /// <param name="plainText">加密前字串</param>
        /// <returns>加密後字串</returns>
        public static string EncryptString(string sCryptoKey, string plainText)
        {
            byte[] array;

            if (string.IsNullOrEmpty(sCryptoKey) && string.IsNullOrEmpty(plainText))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：加密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(plainText))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：加密資料未給值");
            }
            else if (string.IsNullOrEmpty(sCryptoKey))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                    byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("AES within SymmetricKey：" + ex.Message);
                }
            }

            return System.Convert.ToBase64String(array);
        }
        /// <summary>
        /// 字串解密
        /// </summary>
        /// <param name="sCryptoKey">金鑰</param>
        /// <param name="cipherText">解密前字串</param>
        /// <returns>解密後字串</returns>
        public static string DecryptString(string sCryptoKey, string cipherText)
        {
            byte[] buffer = System.Convert.FromBase64String(cipherText);

            if (string.IsNullOrEmpty(sCryptoKey) && string.IsNullOrEmpty(cipherText))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：解密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(cipherText))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：解密資料未給值");
            }
            else if (string.IsNullOrEmpty(sCryptoKey))
            {
                throw new Exception("AES within SymmetricKey：發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                    byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(sCryptoKey));
                    aes.Key = key;
                    aes.IV = iv;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("AES within SymmetricKey：" + ex.Message);
                }
            }
        }
    }
}

