using System.Security.Cryptography;
using System.Text;

namespace MicroServiceCoreLibrary.Security.EnDeCryption
{
    #region SonarLint Disabled 放置區域
#pragma warning disable SYSLIB0021
#pragma warning disable S1481
#pragma warning disable S112
#pragma warning disable S5547

    #endregion

    /// <summary>
    /// AES+SHA256
    /// DES+SHA256
    /// 加解密工具
    /// </summary>
    public class EnDeCryptionV2Security
    {
        /// <summary>
        /// DesKeyIV
        /// </summary>
        private sealed class DesKeyIV
        {
            /// <summary>
            /// 宣告金鑰變數
            /// </summary>
            public byte[] Key = new byte[8];
            /// <summary>
            /// 宣告IV值變數
            /// </summary>
            public byte[] IV = new byte[8];
            /// <summary>
            /// 取得DES-IV值
            /// </summary>
            public DesKeyIV(string strKey)
            {
                var sha = new SHA256CryptoServiceProvider();
                var bpHash = sha.ComputeHash(Encoding.ASCII.GetBytes(strKey));
                for (int i = 0; i < 8; i++) Key[i] = bpHash[i];
                for (int i = 8; i < 16; i++) IV[i - 8] = bpHash[i];
            }
        }
        /// <summary>
        /// 加密程序
        /// </summary>
        /// <param name="key">金鑰</param>
        /// <param name="rawString">加密前字串</param>
        /// <returns>加密後字串資料</returns>
        public static string DesEncrypt(string key, string rawString)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(rawString))
            {
                throw new Exception("發生錯誤：加密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(rawString))
            {
                throw new Exception("發生錯誤：加密資料未給值");
            }
            else if (string.IsNullOrEmpty(key))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    if (rawString.Length > 92160)
                    {
                        throw new Exception("發生錯誤：加密資料過於巨大(請在90Kb以下)");
                    }
                    var keyIv = new DesKeyIV(key);
                    var rbData = Encoding.Unicode.GetBytes(rawString);

                    var descsp = new DESCryptoServiceProvider();
                    var desEncrypt = descsp.CreateEncryptor(keyIv.Key, keyIv.IV);

                    using (var mOut = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(mOut, desEncrypt, CryptoStreamMode.Write))
                        {
                            cs.Write(rbData, 0, rbData.Length);
                            cs.FlushFinalBlock();
                            if (mOut.Length == 0)
                                return string.Empty;
                            else
                            {
                                var buff = mOut.ToArray();
                                return System.Convert.ToBase64String(buff, 0, buff.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// 解密程序
        /// </summary>
        /// <param name="key">金鑰</param>
        /// <param name="encString">解密前字串</param>
        /// <returns>解密後字串資料</returns>
        public static string DesDecrypt(string key, string encString)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(encString))
            {
                throw new Exception("發生錯誤：解密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(encString))
            {
                throw new Exception("發生錯誤：解密資料未給值");
            }
            else if (string.IsNullOrEmpty(key))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    var keyIv = new DesKeyIV(key);
                    var descsp = new DESCryptoServiceProvider();
                    var desDecrypt = descsp.CreateDecryptor(keyIv.Key, keyIv.IV);
                    using (var mOut = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write))
                        {
                            byte[] bPlain;
                            try
                            {
                                bPlain = System.Convert.FromBase64CharArray(encString.ToCharArray(), 0, encString.Length);
                            }
                            catch (Exception)
                            {
                                throw new Exception("發生錯誤：解密資料並非base64編碼)");
                            }
                            try
                            {
                                cs.Write(bPlain, 0, bPlain.Length);
                                cs.FlushFinalBlock();
                                return Encoding.Unicode.GetString(mOut.ToArray());
                            }
                            catch (Exception e)
                            {
                                return "Error. Decryption Failed. Possibly due to incorrect Key or corrputed data: " + e.ToString();
                                throw new Exception("解密過程失敗：可能給予不正確的解密金鑰所導致");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// 取得AES-IV值
        /// </summary>
        private sealed class AesKeyIV
        {
            public byte[] Key = new byte[16];
            public byte[] IV = new byte[16];

            public AesKeyIV(string strKey)
            {
                var sha = SHA256.Create();
                var hash = sha.ComputeHash(Encoding.ASCII.GetBytes(strKey));
                Array.Copy(hash, 0, Key, 0, 16);
                Array.Copy(hash, 16, IV, 0, 16);
            }
        }
        /// <summary>
        /// 加密程序
        /// </summary>
        /// <param name="key">金鑰</param>
        /// <param name="rawString">加密前字串</param>
        /// <returns>加密後字串資料</returns>
        public static string AesEncrypt(string key, string rawString)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(rawString))
            {
                throw new Exception("發生錯誤：加密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(rawString))
            {
                throw new Exception("發生錯誤：加密資料未給值");
            }
            else if (string.IsNullOrEmpty(key))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    var keyIv = new AesKeyIV(key);
                    var aes = Aes.Create();
                    aes.Key = keyIv.Key;
                    aes.IV = keyIv.IV;
                    var rawData = Encoding.UTF8.GetBytes(rawString);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                        {
                            cs.Write(rawData, 0, rawData.Length);
                            cs.FlushFinalBlock();
                            return System.Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// 解密程序
        /// </summary>
        /// <param name="key">金鑰</param>
        /// <param name="encString">解密前字串</param>
        /// <returns>解密後字串資料</returns>
        public static string AesDecrypt(string key, string encString)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(encString))
            {
                throw new Exception("發生錯誤：解密資料以及金鑰均未給值");
            }
            else if (string.IsNullOrEmpty(encString))
            {
                throw new Exception("發生錯誤：解密資料未給值");
            }
            else if (string.IsNullOrEmpty(key))
            {
                throw new Exception("發生錯誤：金鑰未給值");
            }
            else
            {
                try
                {
                    var keyIv = new AesKeyIV(key);
                    var aes = Aes.Create();
                    aes.Key = keyIv.Key;
                    aes.IV = keyIv.IV;
                    var encData = System.Convert.FromBase64String(encString);
                    byte[] buffer = new byte[8192];
                    using (var ms = new MemoryStream(encData))
                    {
                        using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                using (var dec = new MemoryStream())
                                {
                                    cs.CopyTo(dec);
                                    return Encoding.UTF8.GetString(dec.ToArray());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}