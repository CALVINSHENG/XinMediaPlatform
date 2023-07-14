namespace MicroServiceCoreLibrary.Models
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// PageInfo
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        ///  第幾頁
        /// </summary>
        public int? Page_Index { get; set; }
        /// <summary>
        ///  一頁幾個
        /// </summary>
        public int? Page_Size { get; set; }
        /// <summary>
        ///  排序依據
        /// </summary>
        public string? Orderby { get; set; }
        /// <summary>
        ///  升冪降冪
        /// </summary>
        public string? Arrangement { get; set; } = "desc";
        /// <summary>
        ///  總頁數
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        ///  最後一頁
        /// </summary>
        public int? Last_Page { get; set; }
    }
}
