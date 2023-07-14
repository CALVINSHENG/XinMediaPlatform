using MicroServiceCoreLibrary.Security.EnDeCryption;
using System.Security.Cryptography;
using System.Text;

namespace MicroServiceCoreLibrary.Security
{
    #region SonarLint Disabled 放置區域
#pragma warning disable SYSLIB0021
#pragma warning disable S5547
#pragma warning disable S5542
#pragma warning disable S4426
#pragma warning disable S112
#pragma warning disable CS8604
#pragma warning disable IDE0090
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    // 訊息 IDE0090 'new' 運算式可簡化 MicroServiceCoreLibrary
#pragma warning disable IDE0063
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //訊息 IDE0063 'using' 陳述式可簡化 MicroServiceCoreLibrary
#pragma warning disable S2053 // Hashes should include an unpredictable salt
    #endregion

    /// <summary>
    /// EncoderType
    /// </summary>
    public enum EncoderType
    {
        //呼叫其他混合加解密
        //[EnDeCryptionV1Security]
        AES_MD5_SHA256,
        //[EnDeCryptionV4Security]
        AES_MD5_SHA384,
        //[EnDeCryptionV5Security]
        AES_MD5_SHA512,

        //[EnDeCryptionV2Security]
        AES_SHA256,

        DES_SHA256,

        //[EnDeCryptionV3Security]
        AES_MD5_SHA256_SymmetricKey,

        //可逆編碼(對稱金鑰)
        AES,

        DES,
        RC2,
        TripleDES,

        //可逆編碼(非對稱金鑰)
        RSA,

        //不可逆編碼(雜湊值)
        MD5,

        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

    /// <summary>
    /// 整合加解密工具<br/><br/>
    /// 可逆編碼(對稱金鑰)<br/>
    /// AES、DES、RC2、TripleDES<br/>
    /// ░░░░░░░░░░░░░░░░░░<br/>
    /// 可逆編碼(非對稱金鑰)<br/>
    /// RSA<br/>
    /// ░░░░░░░░░░░░░░░░░░<br/>
    /// 不可逆編碼(雜湊值)<br/>
    /// MD5、SHA1、SHA256、SHA384、SHA512<br/>
    /// ░░░░░░░░░░░░░░░░░░<br/>
    /// 可逆混合編碼[金鑰取自Service/Configs/SecurityConfig/*.json]<br/>
    /// [EnDeCryptionV1Security]-<br/>
    ///             AES_MD5_SHA256<br/>
    /// [EnDeCryptionV4Security]-<br/>
    ///             AES_MD5_SHA384<br/>
    /// [EnDeCryptionV5Security]-<br/>
    ///             AES_MD5_SHA512<br/>
    /// [EnDeCryptionV2Security]-<br/>
    ///            AES_SHA256<br/>
    ///            DES_SHA256<br/>
    /// [EnDeCryptionV3Security]-<br/>
    ///            AES_MD5_SHA256_SymmetricKey<br/>
    /// <br/>備註<br/>
    /// Encoder<br/>
    /// 單純依EncoderType選用
    /// </summary>
    public static class EnDeCryptionIntegrateSecurity
    {
        public static string? Key { get; set; }
        public static string? IV { get; set; }

        /// <summary>
        /// 產生新的KEY
        /// </summary>
        /// <param name="type">編碼器種類</param>
        public static void GenerateKey(EncoderType type)
        {
            switch (type)
            {
                //可逆編碼(對稱金鑰)
                case EncoderType.AES:
                    using (AesCryptoServiceProvider csp = new())
                    {
                        csp.GenerateIV();
                        IV = System.Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = System.Convert.ToBase64String(csp.Key);
                    }
                    break;

                case EncoderType.DES:
                    using (DESCryptoServiceProvider csp = new())
                    {
                        csp.GenerateIV();
                        IV = System.Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = System.Convert.ToBase64String(csp.Key);
                    }
                    break;

                case EncoderType.RC2:
                    using (RC2CryptoServiceProvider csp = new())
                    {
                        csp.GenerateIV();
                        IV = System.Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = System.Convert.ToBase64String(csp.Key);
                    }
                    break;

                case EncoderType.TripleDES:
                    using (TripleDESCryptoServiceProvider csp = new())
                    {
                        csp.GenerateIV();
                        IV = System.Convert.ToBase64String(csp.IV);
                        csp.GenerateKey();
                        Key = System.Convert.ToBase64String(csp.Key);
                    }
                    break;
                //可逆編碼(非對稱金鑰)
                case EncoderType.RSA:
                    using (RSACryptoServiceProvider csp = new())
                    {
                        IV = "";
                        Key = csp.ToXmlString(true);
                    }
                    break;
            }
        }
        /// <summary>
        /// Encrypts the specified clear text.
        /// </summary>
        /// <param name="clearText">The clear text.</param>
        /// <param name="sCryptoKey">The s crypto key.</param>
        /// <returns></returns>
        public static string Encrypt(string clearText, string sCryptoKey = "")
        {
            string encryptionKey = sCryptoKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="type">編碼器種類</param>
        /// <param name="encrypt">加密前字串</param>
        /// <param name="sCryptoKey">加密金鑰
        /// 1.單純加解密可不叫用，保持預設空值<br/>
        /// 2.呼叫其他混合加解密金鑰必須帶入
        /// </param>
        /// <returns>加密後字串</returns>
        public static string Encrypt(EncoderType type, string encrypt, string sCryptoKey = "")
        {
            string ret = "";

            try
            {
                if (string.IsNullOrEmpty(sCryptoKey))
                {
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(encrypt);
                    /*
                    * 編輯作者：ADD BY CALVIN AT 2022/12/29
                    * 說　　明：加密前取得Key、IV屬性值
                    * 備　　註：呼叫GenerateKey(type)
                    * ░░░░░░░░░
                    * 修改歷程：
                    * 2022/12/29 初版
                    * YYYY/MM/DD [ACTION] BY [AUTHOR]
                    * 	說明：...
                    * 	備註：...
                    */
                    GenerateKey(type);
                    switch (type)
                    {
                        //可逆編碼(對稱金鑰)
                        case EncoderType.AES:
                            using (AesCryptoServiceProvider csp = new())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new())
                                using (CryptoStream cs = new(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                {
                                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                                    cs.FlushFinalBlock();
                                    ret = System.Convert.ToBase64String(ms.ToArray());
                                }
                            }
                            break;

                        case EncoderType.DES:
                            using (DESCryptoServiceProvider csp = new())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = System.Convert.ToBase64String(ms.ToArray());
                                    }
                                }
                            }
                            break;

                        case EncoderType.RC2:
                            using (RC2CryptoServiceProvider csp = new())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = System.Convert.ToBase64String(ms.ToArray());
                                    }
                                }
                            }
                            break;

                        case EncoderType.TripleDES:
                            using (TripleDESCryptoServiceProvider csp = new TripleDESCryptoServiceProvider())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = System.Convert.ToBase64String(ms.ToArray());
                                    }
                                }
                            }
                            break;
                        //可逆編碼(非對稱金鑰)
                        case EncoderType.RSA:
                            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
                            {
                                csp.FromXmlString(Key);
                                ret = System.Convert.ToBase64String(csp.Encrypt(inputByteArray, false));
                            }
                            break;
                        //不可逆編碼(雜湊值)
                        case EncoderType.MD5:
                            using (MD5CryptoServiceProvider csp = new())
                            {
                                ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                            }
                            break;

                        case EncoderType.SHA1:
                            using (SHA1CryptoServiceProvider csp = new())
                            {
                                ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                            }
                            break;

                        case EncoderType.SHA256:
                            using (SHA256CryptoServiceProvider csp = new())
                            {
                                ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                            }
                            break;

                        case EncoderType.SHA384:
                            using (SHA384CryptoServiceProvider csp = new())
                            {
                                ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                            }
                            break;

                        case EncoderType.SHA512:
                            using (SHA512CryptoServiceProvider csp = new())
                            {
                                ret = BitConverter.ToString(csp.ComputeHash(inputByteArray)).Replace("-", string.Empty);
                            }
                            break;
                        /*
                        * 編輯作者：ADD BY CALVIN AT 2022/12/29
                        * 說明：加入混合加解密避免金鑰值不為空值[防呆]
                        */
                        //呼叫其他混合加解密
                        case EncoderType.AES_MD5_SHA256:
                            //EnDeCryptionV1Security
                            ret = EnDeCryptionV1Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA384:
                            //EnDeCryptionV4Security
                            ret = EnDeCryptionV4Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA512:
                            //EnDeCryptionV5Security
                            ret = EnDeCryptionV4Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.AesEncrypt(sCryptoKey, encrypt);
                            break;

                        case EncoderType.DES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.DesEncrypt(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA256_SymmetricKey:
                            //EnDeCryptionV3Security
                            ret = EnDeCryptionV3Security.EncryptString(sCryptoKey, encrypt);
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        //呼叫其他混合加解密
                        case EncoderType.AES_MD5_SHA256:
                            //EnDeCryptionV1Security
                            ret = EnDeCryptionV1Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA384:
                            //EnDeCryptionV4Security
                            ret = EnDeCryptionV1Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA512:
                            //EnDeCryptionV5Security
                            ret = EnDeCryptionV1Security.AesEncryptBase64(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.AesEncrypt(sCryptoKey, encrypt);
                            break;

                        case EncoderType.DES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.DesEncrypt(sCryptoKey, encrypt);
                            break;

                        case EncoderType.AES_MD5_SHA256_SymmetricKey:
                            //EnDeCryptionV3Security
                            ret = EnDeCryptionV3Security.EncryptString(sCryptoKey, encrypt);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            return ret ?? throw new Exception("呼叫加密程序，但是加密未完成，請檢查加密參數是否錯誤");
        }
        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="sCryptoKey">The s crypto key.</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string sCryptoKey = "")
        {
            string encryptionKey = sCryptoKey;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="type">編碼器種類</param>
        /// <param name="decrypt">解密前字串</param>
        /// <param name="sCryptoKey">解密金鑰</param>
        /// <returns>解密後字串</returns>
        public static string Decrypt(EncoderType type, string decrypt, string sCryptoKey = "")
        {
            string ret = "";

            try
            {
                if (string.IsNullOrEmpty(sCryptoKey))
                {
                    byte[] inputByteArray = System.Convert.FromBase64String(decrypt);

                    switch (type)
                    {
                        //可逆編碼(對稱金鑰)
                        case EncoderType.AES:
                            using (AesCryptoServiceProvider csp = new())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new())
                                using (CryptoStream cs = new(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                {
                                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                                    cs.FlushFinalBlock();
                                    ret = Encoding.UTF8.GetString(ms.ToArray());
                                }
                            }
                            break;

                        case EncoderType.DES:
                            using (DESCryptoServiceProvider csp = new())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = Encoding.UTF8.GetString(ms.ToArray());
                                    }
                                }
                            }
                            break;

                        case EncoderType.RC2:
                            using (RC2CryptoServiceProvider csp = new RC2CryptoServiceProvider())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = Encoding.UTF8.GetString(ms.ToArray());
                                    }
                                }
                            }
                            break;

                        case EncoderType.TripleDES:
                            using (TripleDESCryptoServiceProvider csp = new TripleDESCryptoServiceProvider())
                            {
                                byte[] rgbKey = System.Convert.FromBase64String(Key);
                                byte[] rgbIV = System.Convert.FromBase64String(IV);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                                    {
                                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                                        cs.FlushFinalBlock();
                                        ret = Encoding.UTF8.GetString(ms.ToArray());
                                    }
                                }
                            }
                            break;
                        //可逆編碼(非對稱金鑰)
                        case EncoderType.RSA:
                            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
                            {
                                csp.FromXmlString(Key);
                                ret = Encoding.UTF8.GetString(csp.Decrypt(inputByteArray, false));
                            }
                            break;
                        /*
                        * 編輯作者：ADD BY CALVIN AT 2022/12/29
                        * 說明：加入混合加解密避免金鑰值不為空值[防呆]
                        */
                        //呼叫其他混合加解密
                        case EncoderType.AES_MD5_SHA256:
                            //EnDeCryptionV1Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA384:
                            //EnDeCryptionV4Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA512:
                            //EnDeCryptionV5Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.AesDecrypt(sCryptoKey, decrypt);
                            break;

                        case EncoderType.DES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.DesDecrypt(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA256_SymmetricKey:
                            //EnDeCryptionV3Security
                            ret = EnDeCryptionV3Security.DecryptString(sCryptoKey, decrypt);
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        //呼叫其他混合加解密
                        case EncoderType.AES_MD5_SHA256:
                            //EnDeCryptionV1Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA384:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA512:
                            //EnDeCryptionV5Security
                            ret = EnDeCryptionV1Security.AesDecryptBase64(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.AesDecrypt(sCryptoKey, decrypt);
                            break;

                        case EncoderType.DES_SHA256:
                            //EnDeCryptionV2Security
                            ret = EnDeCryptionV2Security.DesDecrypt(sCryptoKey, decrypt);
                            break;

                        case EncoderType.AES_MD5_SHA256_SymmetricKey:
                            //EnDeCryptionV3Security
                            ret = EnDeCryptionV3Security.DecryptString(sCryptoKey, decrypt);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            return ret ?? throw new Exception("呼叫解密程序，但是解密未完成，請檢查解密參數是否錯誤");
        }
    }
}