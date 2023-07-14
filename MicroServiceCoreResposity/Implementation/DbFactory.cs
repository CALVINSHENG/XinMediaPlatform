#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.DbAccess.Helpers;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.SqlClient;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.Implementation
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S1450 // Private fields only used as local variables in methods should become local variables
#pragma warning disable S112 // General exceptions should never be thrown
    #endregion

    public static class DbFactory
    {
        /// <summary>
        /// The baselogger
        /// </summary>
        private static ILogger<BaseLogger>? _baselogger;

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="baselogger">The baselogger.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="environmentVal">The environment value.</param>
        /// <returns></returns>
        public static IDbConnection GetConnection(ILogger<BaseLogger> baselogger, string connectionString, int environmentVal)
        {
            _baselogger = baselogger;

            MSGetConfig? ConfigSettings = new(baselogger);
            connectionString = ConfigSettings.GetConnectionDBConfig(connectionString, environmentVal);

            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            _baselogger?.LogInformation("Database ConnectionString Opening Success");

            return connection;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="baselogger">The baselogger.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">無法取得本機開發人員對應</exception>
        public static IDbConnection GetConnection(ILogger<BaseLogger> baselogger, int path = 3)
        {
            _baselogger = baselogger;

            string connectionString;

            try
            {
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
                            "ITTC-04509-0088" => "Data Source=ITTC-04509-0088; Initial Catalog=ELDPLAT; User ID=sa;Password=!qaz#EDCLionTravel789",
                            //江柏宏
                            "ITTC-04509-0041" => "Server=ITTC-04509-0041\\SQLEXPRESS;Database=EldPlat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true",
                            //呂軒宇
                            "ITTC-04509-0033" => "Server=ITTC-04509-0033\\SQLEXPRESS;Database=EldPlat;User ID=sa;Password=ssmsLion220123",
                            //盧珈潁
                            "ITTC-04509-0090" => "Server=ITTC-04509-0090;Database=Eldplat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true",
                            //姜昱光
                            "ITTC-04509-0055" => "ITTC-04509-0055\\SQLEXPRESS;Database=EldPlat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true",
                            //邱上庭
                            "ITTC-04509-0096" => "Server=127.0.0.1;Database=EldPlat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=True",
                            //魏傳駿
                            "ITTC-04509-0043" => "Server=ITTC-04509-0043\\SQLEXPRESS;Database=Eldplat;Encrypt=False;Trusted_Connection=True;MultipleActiveResultSets=true",
                            //倪楷翔
                            "ITTC-04509-0074" => "Server=ITTC-04509-0074;Database=ELDPLAT;User ID=sa;Password=paulLion00F822",
                            //張家馨
                            "ITTC-04509-0095" => "Server=ITTC-04509-0074;Database=ELDPLAT;User ID=sa;Password=paulLion00F822",
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
                                                    , "ConnectionStrings:Local:" + ServerUtilityHelper.GetLocalMachineName()
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
                        throw new Exception("無法取得本機開發人員對應");
                }
            }
            catch
            {
                throw new Exception("列舉識別取得連線資訊無效，設定檔取得連線資訊也無建立設定");
            }

            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            _baselogger?.LogInformation("Database ConnectionString Opening Success");

            return connection;
        }
    }
}