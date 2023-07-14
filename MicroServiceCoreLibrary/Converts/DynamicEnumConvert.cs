namespace MicroServiceCoreLibrary.Converts
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// DynamicEnumConvert
    /// </summary>
    public static class DynamicEnumConvert
    {
        /// <summary>
        /// Stringses to enums.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strs">The STRS.</param>
        /// <returns></returns>
        public static IEnumerable<T> StringsToEnums<T>(this IEnumerable<string> strs) where T : struct, IConvertible
        {
            Type t = typeof(T);

            var ret = new List<T>();

            if (t.IsEnum)
            {
                T outStr;
                foreach (var str in strs)
                {
                    if (Enum.TryParse(str, out outStr))
                    {
                        ret.Add(outStr);
                    }
                }
            }

            return ret;
        }
    }
}
