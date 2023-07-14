using DnsClient.Protocol;
using DocumentFormat.OpenXml.Bibliography;
using MicroServiceCoreResposity.Interface;
using System.Data;

namespace MicroServiceCoreResposity.Entity
{
    #region SonarLint Disabled 放置區域
#pragma warning disable CS8618
    //警告 CS8618  退出建構函式時，不可為 Null 的 屬性 'dataTable'
    //必須包含非 Null 值。請考慮將 屬性 宣告為可為 Null。
#pragma warning disable S2190
    //警告 S2190   Add a way to break out of this property accessor's
    //recursion.

    #endregion

    /// <summary>
    /// ResultModel<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="MicroServiceCoreResposity.Interface.IResultModel&lt;T&gt;" />
    public class ResultModel<T> : IResultModel<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultModel{T}"/> class.
        /// </summary>
        public ResultModel()
        {
            IsSuccess = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// Gets or sets the return result.
        /// </summary>
        /// <value>
        /// The return result.
        /// </value>
        public string ReturnResult { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the return combination result.
        /// </summary>
        /// <value>
        /// The return combination result.
        /// </value>
        public string ReturnCombinationResult { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the affect count.
        /// </summary>
        /// <value>
        /// The affect count.
        /// </value>
        public int AffectCount { get; set; }

        /// <summary>
        /// Gets or sets the affect count type long.
        /// </summary>
        /// <value>
        /// The affect count type long.
        /// </value>
        public long AffectCountTypeLong { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; } = new Exception("未知錯誤");

        /// <summary>
        /// Gets or sets the data list.
        /// </summary>
        /// <value>
        /// The data list.
        /// </value>
        public IEnumerable<T> DataList { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data
        {
            get
            {
                if (Data == null)
                {
                    Data = System.Activator.CreateInstance<T>();
                }
                return this.Data;
            }
            set
            {
                this.Data = value;
            }
        }
    }

    /// <summary>
    /// ResultModel
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Interface.IResultModel&lt;T&gt;" />
    public class ResultModel : IResultModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultModel"/> class.
        /// </summary>
        public ResultModel()
        {
            IsSuccess = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// Gets or sets the return result.
        /// </summary>
        /// <value>
        /// The return result.
        /// </value>
        public string ReturnResult { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the return combination result.
        /// </summary>
        /// <value>
        /// The return combination result.
        /// </value>
        public string ReturnCombinationResult { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the affect count.
        /// </summary>
        /// <value>
        /// The affect count.
        /// </value>
        public int AffectCount { get; set; }

        /// <summary>
        /// Gets or sets the affect count type long.
        /// </summary>
        /// <value>
        /// The affect count type long.
        /// </value>
        public long AffectCountTypeLong { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; } = new Exception("位置錯誤");

        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        public DataTable DataTable { get; set; }
    }
}