namespace MicroServiceCoreResposity.Entity
{
    /// <summary>
    /// FilterList<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MicroServiceCoreResposity.Entity.DataResultModel" />
    public class FilterList<T> : DataResultModel
    {
        /// <summary>
        /// Gets or sets the content list.
        /// </summary>
        /// <value>
        /// The content list.
        /// </value>
        public List<T>? ContentList { get; set; } = new();
        /// <summary>
        /// Gets or sets the condition list.
        /// 一個欄位名稱
        /// 配一組條件
        /// </summary>
        /// <value>
        /// The condition list.
        /// </value>
        public List<ConditionModel>? ConditionList { get; set; } = new();
    }
}
