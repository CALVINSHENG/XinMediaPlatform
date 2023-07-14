#region SonarLint Disabled 放置區域
//#pragma warning disable CS8600
#pragma warning disable CA2254
//訊息 CA2254  記錄訊息範本不應在與 'LoggerExtensions.LogError
//(ILogger, Exception?, string?, params object?[])' 通話期間改變
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
#pragma warning disable S3458 // Empty "case" clauses that fall through to the "default" should be omitted
#endregion

using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
	/// <summary>
	/// GetConfigHelper
	/// </summary>
	/// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
	public class GetConfigHelper : DoBase
	{
		#region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
		/// <summary>
		/// The baselogger
		/// </summary>
		private readonly ILogger<BaseLogger>? _baselogger;

		/// <summary>
		/// 設定檔資料
		/// </summary>
		public string? ConfigResult { get; set; }
		/// <summary>
		/// 設定檔根目錄
		/// </summary>
		public const string? ConfigRootFolder = "\\Configs\\";
		/// <summary>
		/// 站台連線資料
		/// </summary>
		public string? SiteMSShipConnection { get; set; }

		/// <summary>
		/// 建構子初始化方式(1)
		/// </summary>
		/// <param name="baselogger"></param>
		public GetConfigHelper(ILogger<BaseLogger> baselogger) : base(baselogger)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(2)
		/// </summary>
		/// <param name="baselogger"></param>
		/// <param name="ConnectionString"></param>
		/// <param name="EnvironmentVal"></param>
		public GetConfigHelper(ILogger<BaseLogger> baselogger, string ConnectionString, int EnvironmentVal) : base(baselogger, ConnectionString, EnvironmentVal)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(3)
		/// </summary>
		public GetConfigHelper()
		{
		}

		/// <summary>
		/// MongoDB底層共用Log紀錄
		/// </summary>
		/// <returns></returns>
		/*
		* 編輯作者：ADD BY CALVIN AT 2022/12/13
		* 說　　明：解決_baselogger為null警告問題
		* 備　　註：
		* 引　　用：
		* ░░░░░░░░░
		* 修改歷程：
		* 2022/12/13 初版
		*/
		public ILogger? Get_BaseLogger()
		{
			return _baselogger;
		}

		#endregion

		/// <summary>
		/// Gets the configuration.
		/// 取得微服務設定檔(共用程序)
		/// </summary>
		/// <param name="jsonSource">
		///		The json source.
		///		設定檔指定模式
		///			❶ ProjectDefaultDirectory:讀取appsettings.json
		///			❷ SpecificDirectory:自訂路徑讀取自訂設定檔
		/// </param>
		/// <param name="jsonPathCommand">
		///		The json path command.
		///		JSON檔節點資料路徑指令
		/// </param>
		/// <param name="jsonFileName">
		///		Name of the json file.
		///		JSON檔名稱
		/// </param>
		/// <param name="jsonPrefixPath">
		///		The json prefix path.
		///		設定檔前置路徑以及路徑組合
		/// </param>
		/// <returns>
		///		1.取得JSON檔指定路徑的節點資料
		///		2.ConfigTargetType為Global時強迫讀取GlobalExternalConfig.json檔案
		/// </returns>
		/// <exception cref="MicroServiceCoreResposity.Entity.ResultModel.Exception"></exception>
		public string GetConfig(
			ConfigTargetType jsonSource
			, string? jsonPathCommand = ""
			, string? jsonFileName = "appsettings.json"
			, string? jsonPrefixPath = "./configs/ExternalConfigs/")
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
						source.Path = jsonFileName ?? throw new Exception(string.Format("查無設定檔名稱：{0}{1}：{2}", currentDirectoryPath, jsonFileName, jsonPathCommand));
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
						StringBuilder ExceptionMessage = new(
								NLogHelper.FetchCompleteMessage()
							);
						_baselogger?.LogError(ex, ExceptionMessage.ToString());
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
						source.Path = jsonFileName ?? throw new Exception(string.Format("查無設定檔名稱：{0}{1}{2}：{3}", currentDirectoryPath, jsonPrefixPath, jsonFileName, jsonPathCommand));
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
						StringBuilder ExceptionMessage = new(
								NLogHelper.FetchCompleteMessage()
							);
						_baselogger?.LogError(ex, ExceptionMessage.ToString());
					}
					break;
				default:
				case ConfigTargetType.Global:
					string? _configRootFolderGlobal = ConfigRootFolder;
					try
					{
						jsonFileName = "GlobalExternalConfig.json";
						string? currentDirectoryPath = Directory.GetCurrentDirectory();
						var config = new ConfigurationBuilder()
										.AddInMemoryCollection()
										.SetBasePath(currentDirectoryPath)
										.AddJsonFile((jsonFileName ?? ""), optional: true, reloadOnChange: true)
										.Build();

						JsonConfigurationSource source = new();
						source.FileProvider = new PhysicalFileProvider(currentDirectoryPath + jsonPrefixPath);
						source.Path = jsonFileName ?? throw new Exception(string.Format("查無設定檔名稱：{0}{1}{2}：{3}", currentDirectoryPath, jsonPrefixPath, jsonFileName, jsonPathCommand));
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
						StringBuilder ExceptionMessage = new(
								NLogHelper.FetchCompleteMessage()
							);
						_baselogger?.LogError(ex, ExceptionMessage.ToString());
					}
					break;
			}

			return ConfigResult ?? throw new Exception("" +
									"\r\n已記錄Log且建立錯誤日誌：\r\n\r\n" +
									"\r\n無法取得設定檔資訊\r\n" +
									"請檢查設定命令是否正確");
		}

		/// <summary>
		/// Initializes from configuration.
		/// </summary>
		/// <param name="Configuration">The configuration.</param>
		public void InitFromConfiguration(IConfiguration Configuration)
		{
			SiteMSShipConnection = Configuration["ConnectionStrings:DefaultConnectionString"];
		}

		/// <summary>
		/// Gets the file json.
		/// </summary>
		/// <param name="filepath">The filepath.</param>
		/// <returns></returns>
		public static string GetFileJson(string filepath)
		{
			string? json;
			using FileStream fs = new(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
			using StreamReader sr = new(fs, Encoding.GetEncoding("gb2312"));
			json = sr.ReadToEnd().ToString();

			return json;
		}
	}
}
