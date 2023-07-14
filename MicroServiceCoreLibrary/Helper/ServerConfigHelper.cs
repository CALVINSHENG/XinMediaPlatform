#region SonarLint Disabled 放置區域
#pragma warning disable S1481
//警告 S1481   Remove the unused local variable '_configRootFolder'.
#pragma warning disable CS0219
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS0219  已指派變數 '_configRootFolder'，但是從未使用過它的值 MicroServiceCoreResposity   C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\CloudServicePlatform_20230222\MicroServiceCoreResposity\DbAccess\Helpers\GetConfigHelper.cs	115	作用中
#pragma warning disable S112
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S112    'System.Exception' should not be thrown by user code.MicroServiceCoreResposity C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\CloudServicePlatform_20230222\MicroServiceCoreResposity\DbAccess\Helpers\GetConfigHelper.cs	138	作用中
#pragma warning disable CS8604
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS8604  'GetConfigHelper.GetConfigHelper(ILogger<BaseLogger> baselogger)' 中的參數 'baselogger' 可能有 Null 參考引數。	DashBoardService C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\CloudServicePlatform_20230222\DashBoardService\Services\DashBoardServiceRepository.cs	641	作用中
#pragma warning disable IDE0059
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//訊息 IDE0059 對 '_configRootFolder' 指派了不必要的值 MicroServiceCoreResposity   C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\CloudServicePlatform_20230222\MicroServiceCoreResposity\DbAccess\Helpers\GetConfigHelper.cs	124	作用中
#pragma warning disable VSSpell001 // Spell Check
#endregion

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    /// <summary>
    /// ServerConfigHelper
    /// </summary>
    public class ServerConfigHelper
    {
        #region 建構子、物件宣告區
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerConfigHelper"/> class.
        /// 建構子初始化方式(1)
        /// </summary>
        public ServerConfigHelper()
        {
        }

        /// <summary>
        /// 設定檔資料
        /// </summary>
        public static string? ConfigResult { get; set; }
        /// <summary>
        /// 設定檔根目錄
        /// </summary>
        public const string? ConfigRootFolder = "\\Configs\\";
        #endregion

        /// <summary>
        /// 取得微服務設定檔(共用程序)
        /// </summary>
        /// <param name="jsonSource">設定檔指定模式：ProjectDefaultDirectory:讀取appsettings.json；SpecificDirectory:自訂路徑讀取自訂設定檔</param>
        /// <param name="jsonPathCommand">JSON檔節點資料路徑指令</param>
        /// <param name="jsonFileName">JSON檔名稱</param>
        /// <param name="jsonPrefixPath">設定檔前置路徑以及路徑組合</param>
        /// <returns>
        /// 取得JSON檔指定路徑的節點資料
        /// </returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">無法取得設定資訊，請檢查服務路徑設定是否正確</exception>
        public string GetConfig(
            ConfigTargetType jsonSource
            , string? jsonPathCommand = ""
            , string? jsonFileName = "appsettings.json"
            , string? jsonPrefixPath = "")
        {
            switch (jsonSource)
            {
                case ConfigTargetType.ServiceDefault:
                    try
                    {
                        string? currentDirectoryPath = Directory.GetCurrentDirectory();
                        var configRoot = new ConfigurationBuilder()
                                    .AddInMemoryCollection()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile(jsonFileName, optional: true, reloadOnChange: true)
                                    .Build();

                        JsonConfigurationSource source = new();
                        source.FileProvider = new PhysicalFileProvider(currentDirectoryPath);
                        source.Path = jsonFileName ??
                                            throw new Exception(
                                                string.Format(
                                                    "查無設定檔名稱：{0}{1}：{2}"
                                                    , currentDirectoryPath
                                                    , jsonFileName
                                                    , jsonPathCommand
                                                )
                                            );
                        JsonConfigurationProvider provider = new(source);
                        provider.Load();
                        if (provider.TryGet((jsonPathCommand ?? "").ToLower(), out string? configVal))
                        {
                            if (string.IsNullOrEmpty(configVal))
                            {
                                throw new Exception("" +
                                    "\r\n無法取得 appsettings.json 設定資訊\r\n" +
                                    "請檢查設定命令是否正確\r\n：" +
                                    jsonPathCommand);
                            }
                            else
                            {
                                ConfigResult = configVal;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("\r\n無法取得設定檔資訊\r\n：\r\n{0}", ex.Message));
                    }
                    break;
                case ConfigTargetType.CustomDefinition:
                    string? _configRootFolder = ConfigRootFolder;
                    try
                    {
                        string? currentDirectoryPath = Directory.GetCurrentDirectory();
                        var config = new ConfigurationBuilder()
                                        .AddInMemoryCollection()
                                        .SetBasePath(currentDirectoryPath)
                                        .AddJsonFile((jsonFileName ?? ""), optional: true, reloadOnChange: true)
                                        .Build();

                        JsonConfigurationSource source = new();
                        source.FileProvider = new PhysicalFileProvider(currentDirectoryPath + jsonPrefixPath);
                        source.Path = jsonFileName ??
                                            throw new Exception(
                                                string.Format("查無設定檔名稱：{0}{1}{2}：{3}"
                                                    , currentDirectoryPath
                                                    , jsonPrefixPath
                                                    , jsonFileName
                                                    , jsonPathCommand
                                                )
                                            );
                        JsonConfigurationProvider provider = new(source);
                        provider.Load();
                        if (provider.TryGet((jsonPathCommand ?? "").ToLower(), out string? configVal))
                        {
                            if (string.IsNullOrEmpty(configVal))
                            {
                                throw new Exception("" +
                                    "\r\n無法取得 " + jsonFileName + " 設定資訊\r\n" +
                                    "請檢查設定命令是否正確\r\n：" +
                                    jsonPathCommand);
                            }
                            else
                            {
                                ConfigResult = configVal;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("\r\n無法取得設定檔資訊\r\n：\r\n{0}", ex.Message));
                    }
                    break;
            }

            return ConfigResult ?? throw new Exception("" +
                                    "\r\n無法取得設定檔資訊\r\n" +
                                    "請檢查設定命令是否正確");
        }
    }
}
