using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Logging;
using System.Text;

namespace MicroServiceCoreResposity.DbAccess
{
    #region SonarLint Disabled 放置區域
#pragma warning disable CA2254
    //訊息 CA2254  記錄訊息範本不應在與
    //'LoggerExtensions.LogInformation
    //(ILogger, EventId, string?, params object?[])' 通話期間改變
    //MicroServiceCoreResposity
#pragma warning disable IDE0028
    //訊息 IDE0028 集合初始化可簡化 MicroServiceCoreResposity

    #endregion

    /// <summary>
    /// 資料庫操作相關
    /// </summary>
    public class DatabaseOperationDbAccess : DoBase
    {
        #region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
        /// <summary>
        /// 底層日誌紀錄
        /// </summary>
        private readonly ILogger<BaseLogger> _baselogger;
        /// <summary>
        /// 建構子初始化
        /// </summary>
        /// <param name="baselogger"></param>
        public DatabaseOperationDbAccess(ILogger<BaseLogger> baselogger)
        {
            _baselogger = baselogger;
        }

        #endregion

        /// <summary>
		/// 查詢欄位表名
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public List<string> QueryColumnName(string tableName)
        {
            var list = new List<string>();
            var parameters = new Dictionary<string, object>();
            parameters.Add("tableName", tableName);

            try
            {
                string sql = @"SELECT column_name
								FROM information_schema.columns
								WHERE table_name=@tableName;";

                var result = Query<string>(sql, parameters);
                if (result.IsSuccess && result.DataList != null)
                {
                    list = result.DataList.ToList();
                }
                _baselogger?.LogInformation(string.Format("查詢資料表 {0} 欄位表名完成", tableName));
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Message = ex.Message;
                StringBuilder ExceptionMessage = new(
                            NLogHelper.FetchCompleteMessage()
                        );
                _baselogger?.LogError(ex, ExceptionMessage.ToString());
            }
            /*
            * 編輯作者：ADD BY CALVIN AT 2022/01/06
            * 說明：回傳指定資料表的所有欄位
            */
            return list;
        }
    }
}
