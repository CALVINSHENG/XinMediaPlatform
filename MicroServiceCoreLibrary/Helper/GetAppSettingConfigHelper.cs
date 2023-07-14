using MicroServiceCoreLibrary.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// GetAppSettingConfigHelper
    /// </summary>
    public class GetAppSettingConfigHelper
    {
        #region 建構子、物件宣告區(Log物件、驗證物件、區隔符號)
        /// <summary>
        /// 底層日誌紀錄
        /// </summary>
        private readonly ILogger<BaseLogger> _baselogger;
        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        public string? ConnectionString { get; set; }
        /// <summary>
        /// 建構子初始化
        /// </summary>
        /// <param name="baselogger"></param>
        public GetAppSettingConfigHelper(ILogger<BaseLogger> baselogger)
        {
            _baselogger = baselogger;
        }
        #endregion

        /// <summary>
        /// Gets the connection database configuration.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="environmentVal">The environment value.</param>
        /// <returns></returns>
        public string GetConnectionDBConfig(string connectionString = "", int environmentVal = 4)
        {
            var config = new ConfigurationBuilder()
                                .AddInMemoryCollection()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            string envirIdentify;

            if (environmentVal.Equals(1))
            {
                //本機環境
                envirIdentify = "LocalConnectionString";
            }
            else if (environmentVal.Equals(2))
            {
                //開發環境
                envirIdentify = "DevelopConnectionString";
            }
            else if (environmentVal.Equals(3))
            {
                //正式環境
                envirIdentify = "ProductionConnectionString";
            }
            else
            {
                //本機環境
                envirIdentify = "DefaultConnectionString";
            }
            ConnectionString = config.GetSection("ConnectionStrings:" + envirIdentify).Value ?? connectionString;

            _baselogger.LogInformation("Get ConnectionString Success and Database ConnectionString is {ConnectionString}", ConnectionString);

            return ConnectionString ?? string.Empty;
        }
    }
}
