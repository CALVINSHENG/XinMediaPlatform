using Newtonsoft.Json;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text.RegularExpressions;
using System.Web;

namespace MicroServiceCoreLibrary.Transform
{
    #region SonarLint Disabled 放置區域
    //#pragma warning disable CS8600
#pragma warning disable S125
    //警告  S125 Remove this commented out code.
#pragma warning disable S3456
    //警告 S3456   Remove this redundant 'ToCharArray' call.
#pragma warning disable CS8603
    //警告 CS8603  可能有 Null 參考傳回。

    #endregion

    /// <summary>
    /// CommonUtilityTransForm
    /// </summary>
    public static class CommonUtilityTransForm
    {
        /// <summary>
        /// Appends the folder character.
        /// </summary>
        /// <param name="psPath">The ps path.</param>
        /// <returns></returns>
        public static string AppendFolderChar(string psPath)
        {
            int ln_Length = psPath.Length;
            string ls_NewPath = psPath;
            string ls_LastChar = psPath.Substring(ln_Length - 1);
            if (ls_LastChar != "\\" && ls_LastChar != "/") ls_NewPath += "\\";
            return ls_NewPath;
        }

        /// <summary>
        /// URL 編碼
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string Escape(string inString)
        {
            return HttpUtility.UrlDecode(inString);
        }

        /// <summary>
        /// 將字串轉為保密文字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static SecureString ToSecureString(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in source.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }

        /// <summary>
        /// 取得 Server IP
        /// </summary>
        /// <returns></returns>
        public static string GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Eliminates the invalid nodes.
        /// </summary>
        /// <param name="refModel">The reference model.</param>
        /// <param name="isRemoveNullNode">if set to <c>true</c> [is remove null node].</param>
        /// <returns></returns>
        public static string EliminateInvalidNodes(
            IEnumerable refModel
            , bool isRemoveNullNode = false)
        {
            var jsonData = JsonConvert.SerializeObject(refModel);

            var removeEmpty = new Regex("\\s*\"[^\"]+\":\\s*\\[\\]\\,?");
            var removeComma = new Regex(",(?=\\s*})");
            var jsonRsult = removeEmpty
                                .Replace(jsonData, "");
            jsonRsult = removeComma
                            .Replace(jsonRsult, "") ?? string.Empty;

            if (isRemoveNullNode)
            {
                var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var jsonResultOnExcludeNullNode =
                            Regex.Unescape
                            (
                                JsonConvert.SerializeObject(jsonRsult, Formatting.Indented, jsonSetting)
                            );

                jsonRsult = jsonResultOnExcludeNullNode.TrimStart('"').TrimEnd('"');
            }

            return jsonRsult;

            //string _newJsonString = string.Empty;
            //if (!string.IsNullOrEmpty(removeNodeName))
            //{
            //    //反序列化成JObject對象
            //    JObject jObject = JObject.Parse(jsonData);
            //    //移除指定鍵
            //    jObject.Remove(removeNodeName);
            //    //將JObject轉換為JSON字符串
            //    _newJsonString = jObject.ToString();
            //}

            //if (!string.IsNullOrEmpty(removeNodeName))
            //{
            //    // Step 01: Parse json text
            //    JObject jo = JObject.Parse(jsonRsult);

            //    // Step 02: Find Token in JSON object
            //    JToken tokenFound = jo.Descendants()
            //        .Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == removeNodeName)
            //        .Select(p => ((JProperty)p).Value)
            //        .FirstOrDefault();

            //    // Step 03: if the token was found select it and then remove it
            //    if (tokenFound != null)
            //    {
            //        var token = jo.SelectToken(tokenFound.Path);

            //        token.Parent.Remove();
            //    }

            //    jsonRsult = jo.ToString();
            //}

            //return jsonRsult;
        }
        /// <summary>
        /// Forces the eliminate invalid nodes.
        /// </summary>
        /// <param name="refModel">The reference model.</param>
        /// <returns></returns>
        public static string ForceEliminateInvalidNodes(IEnumerable refModel)
        {
            var jsonData = JsonConvert.SerializeObject(refModel);

            var removeEmpty = new Regex("\\s*\"[^\"]+\":\\s*\\[\\]\\,?");
            var removeComma = new Regex(",(?=\\s*})");
            var jsonRsult = removeEmpty
                                .Replace(jsonData, "");
            jsonRsult = removeComma
                            .Replace(jsonRsult, "") ?? string.Empty;

            var jsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var jsonResultOnExcludeNullNode =
                        Regex.Unescape
                        (
                            JsonConvert.SerializeObject(jsonRsult, Formatting.Indented, jsonSetting)
                        );

            jsonRsult = jsonResultOnExcludeNullNode.TrimStart('"').TrimEnd('"');

            return jsonRsult;
        }
    }
}
