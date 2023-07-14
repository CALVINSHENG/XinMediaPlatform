using Microsoft.Extensions.Configuration;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// ReadAppsettingHelper
    /// </summary>
    public static class ReadAppsettingHelper
    {
        /// <summary>
        /// Gets the dapper fields prefix character.
        /// 組合Dapper資料庫欄位所需要前置修飾字元
        /// </summary>
        /// <returns></returns>
        public static string GetDapperFieldsPrefixCharacter()
        {
            var config = new ConfigurationBuilder()
                                .AddInMemoryCollection()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            return config.GetSection("DapperFieldsPrefixCharacter").Value ?? string.Empty;
        }
    }
}
