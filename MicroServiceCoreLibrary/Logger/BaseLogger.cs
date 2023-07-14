using Microsoft.Extensions.Logging;

namespace MicroServiceCoreLibrary.Logger
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// Logging Level 的優先順序
    /// ALL < TRACE < DEBUG < INFO < WARN < ERROR < FATAL < OFF
    /// 進行檔案上分流，將 log 檔分為 service.log 跟 service-critical.log，
    /// 當你開啟 INFO level 或者 DEBUG level，可以特別將 WARN 跟 ERROR 放在 critical，
    /// 才不會被大量的 DEBUG log 洗掉 WARN 跟 ERROR
    /// </summary>
    public class BaseLogger
    {
        #region 建構子、物件宣告區(Log物件)        
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BaseLogger(ILogger<BaseLogger> logger)
        {
            _logger = logger;
        }

        #endregion

        /// <summary>
        /// Recodings the log.
        /// </summary>
        /// <param name="RecordingLevel">The recording level.</param>
        /// <param name="recodeType">Type of the recode.</param>
        protected void RecodingLog(int RecordingLevel, int recodeType = 0)
        {
            _logger.LogInformation("", "");
        }
        /// <summary>
        /// Gets the logger power.
        /// </summary>
        /// <returns></returns>
        public ILogger GetLoggerPower()
        {
            return _logger;
        }
    }
}