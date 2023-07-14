namespace MicroServiceCoreLibrary.Models
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// Token底層設定
    /// </summary>
    public class TokenSettings
    {
        /// <summary>
        /// 發行人
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// 讀者
        /// </summary>
        public string? Audience { get; set; }

        /// <summary>
        /// 金鑰
        /// </summary>
        public string? Key { get; set; }
    }
}
