using System.Data;

namespace MicroServiceCoreResposity.Interface
{
    /// <summary>
    /// IResultModel<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MicroServiceCoreResposity.Interface.IResult" />
    public interface IResultModel<T> : IResult
    {
        /// <summary>
        /// Gets or sets the data list.
        /// </summary>
        /// <value>
        /// The data list.
        /// </value>
        IEnumerable<T> DataList { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        T Data { get; set; }
    }

    /// <summary>
    /// IResultModel
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Interface.IResult" />
    public interface IResultModel : IResult
    {
        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        DataTable DataTable { get; set; }
    }
}