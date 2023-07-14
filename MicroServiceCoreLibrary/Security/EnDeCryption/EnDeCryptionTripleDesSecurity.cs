using System.Security.Cryptography;
using System.Text;

namespace MicroServiceCoreLibrary.Security.EnDeCryption
{
    #region SonarLint Disabled 放置區域
#pragma warning disable SYSLIB0021
#pragma warning disable S5547
#pragma warning disable CS8603

    #endregion

    /// <summary>
    /// EnDeCryptionTripleDesSecurity
    /// </summary>
    public class EnDeCryptionTripleDesSecurity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnDeCryptionTripleDesSecurity"/> class.
        /// </summary>
        protected EnDeCryptionTripleDesSecurity()
        {
            /* 
             * 編輯作者：ADD BY CALVIN AT 2022/12/27
             * 說　　明：
             * TripleDes加解密開發測試
             * 備　　註：開發時請勿使用
             * 引　　用：
             * ░░░░░░░░░
             * 修改歷程：
             * 2022/12/27 初版
            */
        }

        #region DES 加密
        /// <summary>
        /// 加密程序
        /// TripleDes加解密開發測試
        /// 開發時請勿使用
        /// </summary>
        /// <param name="plainText">進行加密字串</param>
        /// <param name="sCryptoKey">加密金鑰</param>
        /// <returns></returns>
        public static string encryptToBase64(string plainText, string sCryptoKey)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sCryptoKey);
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7; //補位
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB; //CipherMode.CBC
                CryptoStream cStream = new CryptoStream(mStream,
                    tripleDESCryptoServiceProvider.CreateEncryptor(),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = Encoding.UTF8.GetBytes(plainText);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return System.Convert.ToBase64String(ret);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion DES 加密

        #region DES解密
        /// <summary>
        /// <summary>
        /// 解密程序
        /// TripleDes加解密開發測試
        /// 開發時請勿使用 
        /// </summary>
        /// <param name="base64">進行解密base64</param>
        /// <param name="sCryptoKey">解密金鑰</param>
        /// <returns></returns>
        public static string decryptFromBase64(string base64, string sCryptoKey)
        {
            try
            {
                byte[] inputByteArray = System.Convert.FromBase64String(base64);
                // Create a new MemoryStream using the passed
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(inputByteArray);

                // Create a CryptoStream using the MemoryStream
                TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                tripleDESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sCryptoKey);
                tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;//补位
                tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;//CipherMode.CBC
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tripleDESCryptoServiceProvider.CreateDecryptor(),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[inputByteArray.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return Encoding.UTF8.GetString(fromEncrypt).TrimEnd('\0');
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        #endregion DES解密
    }
}