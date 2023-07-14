using System.Text;

namespace MicroServiceCoreLibrary.Converts
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// BasicDataConvert
    /// </summary>
    public class BasicDataConvert
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicDataConvert"/> class.
        /// </summary>
        protected BasicDataConvert()
        {
        }

        /// <summary>
        /// Base 64 轉碼
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string EncodeBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Base 64 解碼
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string DecodeBase64(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Base 64 Url 轉碼
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncodeBase64Url(string input)
        {
            byte[] b = Encoding.UTF8.GetBytes(input);
            var output = System.Convert.ToBase64String(b);

            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding

            return output;
        }

        /// <summary>
        /// Base 64 Url 解碼
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DecodeBase64Url(string input)
        {
            var output = input;

            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(input), "Illegal base64url string!");
            }

            byte[] converted = System.Convert.FromBase64String(output); // Standard base64 decoder

            string str = Encoding.UTF8.GetString(converted);

            return str;
        }
    }
}