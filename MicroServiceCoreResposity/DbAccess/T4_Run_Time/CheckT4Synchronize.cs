using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreResposity.DbAccess.T4_Design_Time;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MicroServiceCoreResposity.DbAccess.T4_Run_Time
{
    // Disable the warning.
#pragma warning disable S1481
#pragma warning disable IDE0051
    //訊息 IDE0051 未使用 Private 成員 'CheckT4Synchronize.removeSign'	
    //MicroServiceCoreResposity
#pragma warning disable S1144
    //訊息 S1144   Remove the unused private method 'removeSign'.	
    //MicroServiceCoreResposity
#pragma warning disable CA1822
    //訊息 CA1822  成員 'GetModel' 不會存取執行個體資料，
    //因而可標記為靜態 MicroServiceCoreResposity
#pragma warning disable IDE0090
    //訊息 IDE0090 'new' 運算式可簡化 MicroServiceCoreResposity
#pragma warning disable IDE0063
    //訊息 IDE0063 'using' 陳述式可簡化 MicroServiceCoreResposity
#pragma warning disable S125
    //警告 S125 Remove this commented out code.
#pragma warning disable S3267
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //警告 S3267   Loops should be simplified with "LINQ" expressions MicroServiceCoreResposity   C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\RunTimeT4\CheckT4Synchronize.cs	119	作用中


    //
    // Code that uses obsolete API.
    // ...

    // Re-enable the warning.
    //#pragma warning restore SYSLIB0021
    /// <summary>
    /// 檢查T4文字範本是否與
    /// DataBase指定資料表資料同步
    /// </summary>
    public class CheckT4Synchronize
    {
        public CheckT4Synchronize()
        {
        }
        /// <summary>
        /// Gets the model.
        /// 呼叫執行階段 T4 執行同步比對
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            /*
            * 編輯作者：REMARK BY CALVIN AT 2023/01/16
            * 說明：
            * 傳入目前 T4 系統代碼表的
            * 1.資料筆數
            * 2.資料表欄位數
            */
            GenModelT4 t = new GenModelT4(
                        CheckIsSync(
                            GenerateEventCodeModelRowsCountsTtFile.DataCount
                            , GenerateEventCodeModelRowsCountsTtFile.FieldCount
                            , GenerateEventCodeModelRowsCountsTtFile.LackSummary
                            )
                        );
            return t.TransformText();
        }
        /// <summary>
        /// Checks the is synchronize.
        /// 1.資料表筆數比對
        /// 2.欄位數比對
        /// 3.是否缺少代碼表註解檢查
        /// </summary>
        /// <param name="dataCount">The data count.</param>
        /// <param name="fieldCount">The field count.</param>
        /// <param name="lackSummary">The lackSummary.</param>
        /// <returns>
        /// 1:需執行同步作業
        /// -1:不需執行同步作業
        /// </returns>
        public static string CheckIsSync(
            int dataCount = -1
            , int fieldCount = -1
            , bool lackSummary = false)
        {
            StringBuilder result = new();
            try
            {
                //MSGetConfig? ConfigSettings = new();
                //string connectionString = ConfigSettings.GetConnectionDBConfig();

                using (SqlConnection conn = new SqlConnection())
                {
                    string table = "MESSAGE";
                    string sql = @"SELECT * FROM @table";
                    string sqlSFC = @"
                                        SELECT 
                                          column_name 
                                        FROM 
                                          information_schema.columns 
                                        WHERE 
                                          table_name = @tableName
                                    ;";
                    conn.ConnectionString = MSGetConfig.EstablishConnection();
                    conn.Open();
                    sql = sql.Replace("@table", table);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Clear();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    //if(dt.Rows is null)
                    //{
                    //    /*
                    //            * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                    //            * 說明：
                    //            */
                    //    result.Append("8| 資料筆數：0-0 | 欄位筆數：0-0 |");
                    //}
                    var runTimeCheckSummary = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        /*
                        * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                        * 說明：執行階段檢查註解填寫是否有遺漏欄位
                        */
                        if (string.IsNullOrEmpty(row["SUMMARY"].ToString()))
                        {
                            runTimeCheckSummary = true;
                            break;
                        }
                    }

                    sqlSFC = sqlSFC.Replace("@tableName", table);
                    SqlCommand cmdSFC = new SqlCommand(sqlSFC, conn);
                    cmd.Parameters.Clear();
                    SqlDataReader drSFC = cmd.ExecuteReader();
                    DataTable dtSFC = new DataTable();
                    dtSFC.Load(drSFC);

                    if (dataCount.Equals(-1) || fieldCount.Equals(-1))
                    {
                        /*
                        * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                        * 說明：資料筆數或是資料表欄位數量參數不完整
                        */
                        result.Append("2| 資料筆數：0-0 | 欄位筆數：0-0 |");
                    }
                    else
                    {
                        if (dt.Rows.Count != dataCount
                            || dtSFC.Columns.Count != fieldCount)
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                            * 說明：需進行同步作業
                            */
                            if (runTimeCheckSummary)
                            {
                                result.Append("1| 資料筆數：" + dataCount + " / " + dt.Rows.Count + " | 欄位筆數：" + fieldCount + " / " + dtSFC.Columns.Count + " | SUMMARY註解欄位有欄位填寫不完整");
                            }
                            else
                            {
                                result.Append("1| 資料筆數：" + dataCount + " / " + dt.Rows.Count + " | 欄位筆數：" + fieldCount + " / " + dtSFC.Columns.Count + " | SUMMARY註解欄位填寫：欄位完整填寫");
                            }
                        }
                        else
                        {
                            /*
                            * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                            * 說明：比對數量一致
                            */
                            if (runTimeCheckSummary)
                            {
                                /*
                                * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                                * 說明：缺少註解
                                */
                                result.Append("7| 資料筆數：" + dataCount + " / " + dt.Rows.Count + " | 欄位筆數：" + fieldCount + " / " + dtSFC.Columns.Count + " | SUMMARY註解欄位有欄位填寫不完整");
                            }
                            else
                            {
                                /*
                                * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                                * 說明：註解填寫完整(放行)
                                */
                                result.Append("3| 資料筆數：" + dataCount + " / " + dt.Rows.Count + " | 欄位筆數：" + fieldCount + " / " + dtSFC.Columns.Count + " | SUMMARY註解欄位填寫：欄位完整填寫");
                            }
                        }
                    }

                    conn.Close();
                    conn.Dispose();

                    return result.ToString();
                }
            }
            catch (SqlException sqlexp)
            {
                /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                    * 說明：發生例外錯誤
                    */
                return result.Append("6|" + sqlexp.Message + "|資料庫發生錯誤|").ToString();
            }
            catch (Exception ex)
            {
                if (dataCount.Equals(0) || fieldCount.Equals(0))
                {
                    /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                    * 說明：發生例外錯誤
                    */
                    return result.Append("4|" + ex.Message + "|T4發生錯誤錯誤|").ToString();
                }
                else
                {
                    /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/01/16
                    * 說明：發生例外錯誤
                    */
                    return result.Append("5|" + ex.Message + "|發生執行錯誤|").ToString();
                }
            }
        }
        private static string RemoveSign(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("/", "");
            str = str.Replace("\r\n", "");

            return str;
        }
    }
}