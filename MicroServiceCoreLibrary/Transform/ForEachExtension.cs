namespace MicroServiceCoreLibrary.Transform
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// ForEachExtension
    /// </summary>
    public static class ForEachExtension
    {
        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration">The enumeration.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}
