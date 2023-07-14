#region SonarLint Disabled 放置區域
#pragma warning disable IDE1006 // 命名樣式
#pragma warning disable VSSpell001 // Spell Check
#endregion

namespace XinMedia.Models
{
    /// <summary>
    /// Model資料表
    /// </summary>
    public class TArticleEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the no.
        /// </summary>
        /// <value>
        /// The no.
        /// </value>
        public string? @no { get; set; }
        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public int? member_id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string? title { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string? image { get; set; }
        /// <summary>
        /// Gets or sets the brief.
        /// </summary>
        /// <value>
        /// The brief.
        /// </value>
        public string? brief { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string? content { get; set; }
    }
}