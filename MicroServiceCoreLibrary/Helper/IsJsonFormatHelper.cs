using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable IDE0051 // 刪除未使用的私用成員
#pragma warning disable S1481 // Unused local variables should be removed
    #endregion

    /// <summary>
    /// IsJsonFormatHelper
    /// </summary>
    public static class IsJsonFormatHelper
    {
        /// <summary>
        /// Determines whether [is json format] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is json format] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsJsonFormat(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if ((value.StartsWith("{") && value.EndsWith("}")) ||
                (value.StartsWith("[") && value.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}