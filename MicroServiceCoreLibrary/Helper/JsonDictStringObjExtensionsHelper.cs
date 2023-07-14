using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域
#pragma warning disable IDE0059 // 指派了不必要的值
#pragma warning disable S1854 // Unused assignments should be removed
    #endregion

    /// <summary>
    /// JsonDictStringObjExtensionsHelper
    /// </summary>
    public static class JsonDictStringObjExtensionsHelper
    {
        /// <summary>
        /// Converts to stringobjectdictionary.
        /// </summary>
        /// <param name="JsonStringStatement">The json string statement.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">results maybe null</exception>
        public static Dictionary<string, object> ToStringObjectDictionary(string JsonStringStatement = "")
        {
            Dictionary<string, object>? results = new();

            results = JsonConvert.DeserializeObject<Dictionary<string, object>?>(JsonStringStatement);
            return results ?? throw new Exception("results maybe null");
        }

        /// <summary>
        /// Converts to stringobjectdictionary.
        /// </summary>
        /// <param name="jsonObject">The json object.</param>
        /// <returns></returns>
        public static Dictionary<string, object> ToStringObjectDictionary(this JsonObject jsonObject)
        {
            var dict = new Dictionary<string, object>();
            foreach (var prop in jsonObject)
            {
                object value;
                if (prop.Value == null) value = null!;
                else if (prop.Value is JsonArray) value = prop.Value.AsArray();
                else if (prop.Value is JsonObject) value = prop.Value.AsObject();
                else
                {
                    var v = prop.Value.AsValue();
                    var t = prop.Value.ToJsonString();
                    if (t.StartsWith('"'))
                    {
                        if (v.TryGetValue<DateTime>(out var d)) value = d;
                        else if (v.TryGetValue<Guid>(out var g)) value = g;
                        else value = v.GetValue<string>();
                    }
                    else value = v.GetValue<decimal>();
                }
                dict.Add(prop.Key, value);
            }
            return dict;
        }
    }
}