#region SonarLint Disabled 放置區域
// Disable the warning.
#pragma warning disable S112
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S112    'System.Exception' should not be thrown by user code.BusService C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\BusService\Services\BusRepository.cs	546	作用中
#pragma warning disable CS0414
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS0414  已指派欄位 'MSGetConfig._loggerProcess'，但從未使用過其值 MicroServiceCoreConfiguration   C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\GIT\CloudServicePlatform\MicroServiceCoreConfiguration\Configuration\MSGetConfig.cs	25	作用中
//警告 S1854   Remove this useless assignment to local variable 'connectionString'.	MicroServiceCoreConfiguration C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreConfiguration\Configuration\MSGetConfig.cs   233	作用中
#pragma warning disable IDE0079
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//訊息 IDE0079 移除非必要的隱藏項目 MicroServiceCoreConfiguration   C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreConfiguration\Configuration\MSGetConfig.cs	27	作用中
#pragma warning disable S125
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S125    Remove this commented out code.MicroServiceCoreConfiguration C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreConfiguration\Configuration\MSGetConfig.cs   274	作用中
#pragma warning disable S4136 // Method overloads should be grouped together
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreLibrary.Models;
using MicroServiceCoreResposity.DbAccess.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreConfiguration.Configuration
{
    /// <summary>
    /// 設定檔
    /// 　　1.底層日誌紀錄
    /// 　　2.DAO中介設定
    /// 　　3.驗證ToKen設定
    /// </summary>
    /// <param></praram>
    /// <returns></returns>
    /// <remarks></remarks>
    public class MSGetConfig
    {
        #region 建構子、物件宣告區(Log物件、驗證物件、區隔符號)
        /// <summary>
        /// 底層日誌紀錄
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;
        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        public string? ConnectionString { get; set; }
        /// <summary>
        /// 站台字串
        /// </summary>
        public string? SiteMSMembership { get; set; }
        /// <summary>
        /// 建構子初始化
        /// </summary>
        /// <param name="baselogger"></param>
        public MSGetConfig(ILogger<BaseLogger> baselogger)
        {
            _baselogger = baselogger;
        }

        public MSGetConfig()
        {
        }
        #endregion

        #region 依微服務環境取得連線字串(已廢棄)
        /// <summary>
        /// 依微服務環境取得連線字串
        /// </summary>
        /// <param name="connectionString">連線字串</param>
        /// <param name="environmentVal">
        /// 微服務環境<Para>
        /// 　　代碼 1、無法辨識代碼：本機環境<Para>
        /// 　　代碼 2　　　　　　　：開發環境<Para>
        /// 　　代碼 3　　　　　　　：線上環境<Para>
        /// </param>
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

            _baselogger?.LogInformation("Get ConnectionString Success and Database ConnectionString is {ConnectionString}", ConnectionString);

            return ConnectionString ?? string.Empty;
        }
        #endregion

        #region Establishes the connection.(已廢棄)
        /// <summary>
        /// Establishes the connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="environmentVal">The environment value.</param>
        /// <returns></returns>
        public static string EstablishConnection(string connectionString = "", int environmentVal = 4)
        {
            /*
            * 編輯作者：REMARK BY CALVIN AT 2023/02/12
            * 說明：僅自動取得連線字串提供呼叫端運用
            * 備註：
            */
            MSGetConfig? ConfigSettings = new();
            return ConfigSettings.GetConnectionDBConfig(connectionString, environmentVal) ?? string.Empty;
        }

        /// <summary>
        /// Automatics the establish connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="environmentVal">The environment value.</param>
        /// 微服務環境<Para>
        /// 　　代碼 1、無法辨識代碼：本機環境<Para>
        /// 　　代碼 2　　　　　　　：開發環境<Para>
        /// 　　代碼 3　　　　　　　：線上環境<Para>
        /// 　　代碼 4　　　　　　　：本機環境<Para>
        /// </param>
        /// <returns></returns>
        public static IDbConnection AutoEstablishConnection(string connectionString, int environmentVal)
        {
            /*
            * 編輯作者：REMARK BY CALVIN AT 2023/02/12
            * 說明：自動取得連線字串後進行開啟資料連線
            *       提供呼叫端運用
            * 備註：
            */
            MSGetConfig? ConfigSettings = new();
            SqlConnection connection =
                new(
                    ConfigSettings.GetConnectionDBConfig(connectionString, environmentVal)
                );
            connection.Open();

            return connection;
        }
        #endregion

        #region 取得ToKen設定值
        public static TokenSettings GetTokenSettings()
        {
            var config = new ConfigurationBuilder()
                                .AddInMemoryCollection()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            var tokenSettings = config.GetSection("TokenSettings").Get<TokenSettings>();

            return tokenSettings;
        }
        #endregion

        #region 其他函式
        /// <summary>
        /// 取得站台資訊
        /// </summary>
        /// <param name="Configuration"></param>
        public void InitFromConfiguration(IConfiguration Configuration)
        {
            SiteMSMembership = Configuration["ConnectionStrings:DefaultConnectionString"];
        }
        /// <summary>
        /// JSON檔案操作
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileJson(string filepath)
        {
            string json;
            using FileStream fs = new(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            using StreamReader sr = new(fs, Encoding.GetEncoding("LIONTRAVEL"));
            json = sr.ReadToEnd().ToString();

            return json;
        }
        #endregion

        #region 自動建立資料庫連線(已優化上線使用中)        
        /// <summary>
        /// Automatics the establish connection.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">
        /// 無法取得本機開發人員對應
        /// or
        /// 列舉識別取得連線資訊無效，設定檔取得連線資訊也無建立設定
        /// </exception>
        public static IDbConnection AutoEstablishConnection(int path = 3)
        {
            /*
            * 編輯作者：REMARK BY CALVIN AT 2023/02/12
            * 說明：自動取得連線字串後進行開啟資料連線
            *       提供呼叫端運用
            * 備註：
            */
            string connectionString;

            try
            {
                /*
                * 編輯作者：REMARK BY CALVIN AT 2023/02/12
                * 說明：
                * path = 1 ；HardCode對應
                * path = 2；列舉對應，屏蔽非名單人員連線(失敗採用appsetting.json連線)
                * path = 2；JSON設定檔(彈性控管依專案設置)對應(appsetting.json連線)，(失敗採用列舉對應連線)
                * 備註：
                */
                switch (path)
                {
                    case 1:
                        /*
                        * 編輯作者：REMARK BY CALVIN AT 2023/04/06
                        * 說明：HardCode對應
                        * 備註：
                        */
                        connectionString = ServerUtilityHelper.GetLocalMachineName() switch
                        {
                            //盛鉦凱
                            "ITTC-04509-0088" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //江柏宏
                            "ITTC-04509-0041" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //呂軒宇
                            "ITTC-04509-0033" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //盧珈潁
                            "ITTC-04509-0090" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //姜昱光
                            "ITTC-04509-0055" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //邱上庭
                            "ITTC-04509-0096" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //魏傳駿
                            "ITTC-04509-0043" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //倪楷翔
                            "ITTC-04509-0074" => "Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP",
                            //張家馨
                            "ITTC-04509-0095" => "Server=localhost;Database=EldPlat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true",
                            //無法識別
                            _ => throw new Exception("無法取得本機開發人員對應"),
                        };
                        break;
                    case 2:
                        try
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/04/06
                            * 說明：列舉對應
                            * 備註：列舉字串連結字元不能是"-"
                            *           所以需進行"_"取代"-"流程作業
                            */
                            connectionString =
                                EnumExtenstion.GetDescription(
                                    (CodingMembers)Enum.Parse(
                                        typeof(CodingMembers)
                                        , ServerUtilityHelper.GetLocalMachineName().Replace('-', '_')
                                    )
                                );
                        }
                        catch
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/04/06
                            * 說明：JSON設定檔(彈性控管依專案設置)對應
                            * 備註：
                            */
                            connectionString =
                                        new ServerConfigHelper()
                                                .GetConfig(
                                                    ConfigTargetType.ServiceDefault
                                                    , "ConnectionStrings:Development"
                                                );
                        }
                        break;
                    case 3:
                        try
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/04/06
                            * 說明：JSON設定檔(彈性控管依專案設置)對應
                            * 備註：
                            */
                            connectionString =
                                        new ServerConfigHelper()
                                                .GetConfig(
                                                    ConfigTargetType.ServiceDefault
                                                    , "ConnectionStrings:Development"
                                                );
                        }
                        catch
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/04/06
                            * 說明：列舉對應
                            * 備註：列舉字串連結字元不能是"-"
                            *           所以需進行"_"取代"-"流程作業
                            */
                            connectionString =
                                    EnumExtenstion.GetDescription(
                                        (CodingMembers)Enum.Parse(
                                            typeof(CodingMembers)
                                            , ServerUtilityHelper.GetLocalMachineName().Replace('-', '_')
                                        )
                                    );
                        }
                        break;
                    default:
                        throw new Exception("無法建立資料庫連線");
                }
            }
            catch
            {
                throw new Exception("列舉識別取得連線資訊無效，設定檔取得連線資訊也無法建立連線");
            }

            //MSGetConfig? ConfigSettings = new();
            //SqlConnection connection =
            //    new(
            //        ConfigSettings.GetConnectionDBConfig(connectionString)
            //    );
            //connection.Open();

            MySqlConnection connection = new(connectionString);
            connection.Open();

            return connection;
        }
        #endregion
    }
}
