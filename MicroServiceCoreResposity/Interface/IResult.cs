namespace MicroServiceCoreResposity.Interface
{
    /// <summary>
    /// IResult
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        bool IsSuccess { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        int StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the return result.
        /// </summary>
        /// <value>
        /// The return result.
        /// </value>
        string ReturnResult { get; set; }
        /// <summary>
        /// Gets or sets the return combination result.
        /// </summary>
        /// <value>
        /// The return combination result.
        /// </value>
        string ReturnCombinationResult { get; set; }
        /// <summary>
        /// Gets or sets the affect count.
        /// </summary>
        /// <value>
        /// The affect count.
        /// </value>
        int AffectCount { get; set; }
        /// <summary>
        /// Gets or sets the affect count type long.
        /// </summary>
        /// <value>
        /// The affect count type long.
        /// </value>
        long AffectCountTypeLong { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        Exception Exception { get; set; }
    }
}