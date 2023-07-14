#region SonarLint Disabled 放置區域
#pragma warning disable S1121
//警告 S1121   Extract the assignment of 'pageModel.OrderBy' from this expression.MicroServiceCoreResposity
#pragma warning disable CA2254
//CA2254	記錄訊息範本不應在與 'LoggerExtensions.LogCritical(ILogger, EventId, string?, params object?[])' 通話期間改變	AuthorizationService
#pragma warning disable S4144
//警告 S4144 Update this method so that its implementation is not identical to 'Update'.	MicroServiceCoreResposity
#pragma warning disable S125
//警告 S125  Remove this commented out code.MicroServiceCoreResposity
#pragma warning disable S4136
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S4136   All 'Query' method overloads should be adjacent.MicroServiceCoreResposity C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\Implementation\DoBase.cs	118	作用中
#pragma warning disable S112
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S112    'System.Exception' should not be thrown by user code.MicroServiceCoreResposity C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\Implementation\DoBase.cs	695	作用中
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S1006 // Method overrides should not change parameter defaults
#endregion

using Dapper;
using Dapper.Contrib.Extensions;
using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Entity;
using MicroServiceCoreResposity.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.Implementation
{
    /// <summary>
    /// 資料CRUD via Dapper底層
    /// </summary>
    public class DoBase : IDoBase
    {
        /// <summary>
        /// 日誌紀錄底層
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;
        /// <summary>
        /// 連線字串
        /// </summary>
        protected readonly string connectionString = "";
        /// <summary>
        /// 開發環境代碼
        /// </summary>
        protected readonly int environmentVal = -1;
        /// <summary>
        /// 建構子初始化模式(1)
        /// </summary>
        /// <param name="baselogger"></param>
        /// <param name="ConnectionString"></param>
        /// <param name="EnvironmentVal"></param>
        public DoBase(ILogger<BaseLogger>? baselogger, string ConnectionString, int EnvironmentVal)
        {
            connectionString = ConnectionString;
            environmentVal = EnvironmentVal;
            IsSuccess = true;
            _baselogger = baselogger;
        }
        /// <summary>
        /// 建構子初始化模式(2)
        /// </summary>
        /// <param name="baselogger"></param>
        public DoBase(ILogger<BaseLogger> baselogger)
        {
            if (baselogger is not null)
            {
                IsSuccess = true;
                _baselogger = baselogger;
            }
            else
            {
                throw new Exception("DoBase 底層 baselogger來源發生錯誤。");
            }
        }
        /// <summary>
        /// 建構子初始化模式(3)
        /// </summary>
        public DoBase()
        {
            IsSuccess = true;
        }
        /// <summary>
        /// 資料庫查詢是否成功
        /// </summary>
        public bool? IsSuccess { get; set; }
        /// <summary>
        /// 查詢回傳訊息
        /// </summary>
        public string? Message { get; set; }

        /// 異動類型影響筆數
        /// </summary>
        public int AffectCount { get; set; }
        /// <summary>
        /// 異動類型影響筆數(Dapper.Contrib)
        /// </summary>
        public long AffectCountTypeLong { get; set; }
        /// <summary>
        /// 查詢總筆數
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 例外錯誤Container
        /// </summary>
        public Exception? Exception { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd">SQL語法</param>
        /// <returns></returns>
        public List<dynamic> Query(string cmd)
        {
            var result = new List<dynamic>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                result = conn.Query(cmd).AsList();

                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            return result;
        }
        /// <summary>
        /// 回傳單一欄位列表
        /// </summary>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <returns></returns>
        public List<dynamic> Query(string cmd, IDictionary<string, object> parameters)
        {
            var result = new List<dynamic>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                result = conn.Query(cmd, new DynamicParameters(parameters)).AsList();

                IsSuccess = true;
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            return result;
        }

        /// <summary>
        /// 回傳Model類別資料
        /// 回傳DataTable類型資料
        /// </summary>
        /// <typeparam name="T">多Model列表表示</typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <returns></returns>
        public IResultModel QueryDataTable(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel resultModel = new ResultModel();
            var dt = new DataTable();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                dt.Load(conn.ExecuteReader(cmd, new DynamicParameters(parameters)));

                if (dt.Rows.Count > 0)
                {
                    resultModel.IsSuccess = true;
                    resultModel.DataTable = dt;
                }
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }

        /// <summary>
        /// 回傳Model類別(全部資料)
        /// </summary>
        /// <typeparam name="T">多Model列表表示</typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <returns></returns>
        public IResultModel<T> Query<T>(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.DataList = conn.Query<T>(cmd, new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 回傳Model類別(全部資料)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <param name="forceConnectionString">帶入指定連線字串</param>
        /// <returns></returns>
        public IResultModel<T> Query<T>(string cmd, IDictionary<string, object> parameters, string forceConnectionString)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.DataList = conn.Query<T>(cmd, new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 回傳Model類別(全部資料)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <param name="forceConnectionString">帶入指定連線字串</param>
        /// <param name="forceEnvironment">帶入指定執行環境</param>
        /// <returns></returns>
        public IResultModel<T> Query<T>(string cmd, IDictionary<string, object> parameters, string forceConnectionString, int forceEnvironment)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"), forceConnectionString, forceEnvironment);
                //using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.DataList = conn.Query<T>(cmd, new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 回傳Model類別(單筆資料)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <returns></returns>
        public IResultModel<T> QuerySingle<T>(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.Data = conn.QueryFirstOrDefault<T>(cmd, new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 回傳Model類別(依頁數)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">SQL語法</param>
        /// <param name="parameters">SQL參數值</param>
        /// <param name="pageModel">分頁頁數</param>
        /// <returns></returns>
        public IResultModel<T> QueryPaged<T>(string cmd, IDictionary<string, object> parameters, IPageModel pageModel)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                //using var conn = MSGetConfig.AutoEstablishConnection();
                var pagedCmd = GetPagedCommand(cmd, pageModel.OrderBy = "ASC", pageModel.PageSize, pageModel.PageIndex).Split(';');
                resultModel.DataList = conn.Query<T>(pagedCmd[0], new DynamicParameters(parameters));
                resultModel.TotalCount = conn.ExecuteScalar<int>(pagedCmd[1], new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 新增資料表紀錄
        /// 單一資料表
        /// 1.未引入Trans資料庫交易
        /// 2.會發生執行程序終止現象(請改用Execute...)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel<T> Insert<T>(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                if (!cmd.ToUpper().Contains("SCOPE_IDENTITY") ||
               !cmd.ToUpper().Contains("IDENT_CURRENT") ||
               !cmd.ToUpper().Contains("@@IDENTITY"))
                {
                    if (!cmd.Contains(';'))
                        cmd += ";";

                    cmd += "SELECT SCOPE_IDENTITY();";
                }

                resultModel.Data = conn.ExecuteScalar<T>(cmd, parameters);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 更新單一資料表
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel Update(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.AffectCount = conn.Execute(cmd, parameters);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 刪除單一資料表
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel Delete(string cmd, IDictionary<string, object> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.AffectCount = conn.Execute(cmd, parameters);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Executes the transation.
        /// 多表同時異動(方法一)
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="tran">The tran.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception"></exception>
        public IResultModel ExecuteTransation(List<Tuple<string, string, object>> list, IDbConnection? conn = null, IDbTransaction? tran = null)
        {
            IResultModel resultModel = new ResultModel();
            IDbTransaction transaction;

            //if (conn is null)
            //{
            //    conn = MSGetConfig.AutoEstablishConnection();
            //}

            //if (tran is null)
            //{
            //    transaction = conn.BeginTransaction();
            //}
            //else
            //{
            //    transaction = tran;
            //}
            /*
            * 編輯作者：REMARK BY CALVIN AT 2023/02/19
            * 說明：conn 使用複合指派
            *           transaction更新寫法
            * 備註：
            */
            conn ??= MSGetConfig.AutoEstablishConnection();
            transaction = (tran is null) ? conn.BeginTransaction() : tran;

            using (transaction)
            {
                try
                {
                    var result = 0;
                    foreach (var one in list)
                    {
                        result = conn.Execute(one.Item2, one.Item3, transaction);
                        if (result < 0)
                        {
                            transaction.Rollback();
                            resultModel.IsSuccess = false;
                            var message = resultModel.Message = $"寫入 {one.Item1} 資料表失敗，作業終止";
                            _baselogger?.LogError(message, NLogHelper.FetchCompleteMessage(true));
                            throw new Exception(message);
                        }
                    }
                    if (result >= 0)
                    {
                        transaction.Commit();
                        resultModel.IsSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    resultModel.IsSuccess = false;
                    resultModel.Exception = ex;
                    _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
                }
                finally
                {
                    /*
                    * 編輯作者：REMARK BY CALVIN AT 2023/02/19
                    * 說明：關閉並釋放交易連線
                    * 備註：
                    */
                    conn.Close();
                    conn.Dispose();
                }
            }
            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Executes the transation SQL bulk.
        /// </summary>
        /// <param name="entityList"></param>
        /// <param name="conn">The connection.</param>
        /// <param name="tran">The tran.</param>
        /// <returns></returns>
        public IResultModel ExecuteTransationSQLBulk(
            List<Tuple<string, string, object>> entityList
            , IDbConnection? conn = null
            , IDbTransaction? tran = null)
        {
            IResultModel resultModel = new ResultModel();
            IDbTransaction transaction;

            try
            {
                conn ??= MSGetConfig.AutoEstablishConnection();
                transaction = (tran is null) ? conn.BeginTransaction() : tran;

                using (transaction)
                {
                    resultModel = new ResultModel()
                    {
                        IsSuccess = true,
                    };
                }
            }
            catch (Exception ex)
            {
                resultModel = new ResultModel()
                {
                    IsSuccess = false,
                    Exception = ex
                };
                //resultModel.IsSuccess = false;
                //resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        ///// <summary>
        ///// Executes the transation.
        ///// 多表同時異動(方法二)
        ///// </summary>
        ///// <param name="list">The list.</param>
        ///// <param name="isEraseSubList">if set to <c>true</c> [is erase sub list].</param>
        ///// <param name="conn">The connection.</param>
        ///// <param name="tran">The tran.</param>
        ///// <returns></returns>
        ///// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception"></exception>
        //public IResultModel ExecuteTransation(List<Tuple<string, string, object>> list, bool isEraseSubList, IDbConnection? conn = null, IDbTransaction? tran = null)
        //{
        //    IResultModel resultModel = new ResultModel();
        //    IDbTransaction transaction;

        //    if (conn is null)
        //    {
        //        conn = MSGetConfig.AutoEstablishConnection();
        //    }

        //    if (tran is null)
        //    {
        //        transaction = conn.BeginTransaction();
        //    }
        //    else
        //    {
        //        transaction = tran;
        //    }

        //    using (transaction)
        //    {
        //        try
        //        {
        //            var result = 0;
        //            foreach (var one in list)
        //            {
        //                var parameters = ObjectTransformExtensions
        //                                            .DynamictoDictionaryExcludeList(
        //                                                one.Item3, "@");
        //                result = conn.Execute(one.Item2, parameters, transaction);
        //                if (result < 0)
        //                {
        //                    transaction.Rollback();
        //                    resultModel.IsSuccess = false;
        //                    var message = resultModel.Message = $"寫入 {one.Item1} 資料表失敗，作業終止";
        //                    _baselogger?.LogError(message, NLogHelper.FetchCompleteMessage(true));
        //                    throw new Exception(message);
        //                }
        //            }
        //            if (result > 0)
        //            {
        //                transaction.Commit();
        //                resultModel.IsSuccess = true;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            resultModel.IsSuccess = false;
        //            resultModel.Exception = ex;
        //            _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
        //        }
        //        finally
        //        {
        //            /*
        //            * 編輯作者：REMARK BY CALVIN AT 2023/02/19
        //            * 說明：關閉並釋放交易連線
        //            * 備註：
        //            */
        //            conn.Close();
        //            conn.Dispose();
        //        }
        //    }
        //    SetResult(resultModel);
        //    return resultModel;
        //}
        /// <summary>
        /// 執行異動類型(POST、UPDATE、DELETE)
        /// 單一資料表
        /// 未引入Trans資料庫交易
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel Execute(string cmd, Dictionary<string, object> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.AffectCount = conn.Execute(cmd, new DynamicParameters(parameters));
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 執行異動類型(POST、UPDATE、DELETE)
        /// 多張資料表
        /// 未引入Trans資料庫交易
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel Execute(string cmd, List<Dictionary<string, object>> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using IDbConnection conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();

                List<DynamicParameters> dynamicParameters = new List<DynamicParameters>();
                parameters.ForEach(delegate (Dictionary<string, object> p)
                {
                    dynamicParameters.Add(new DynamicParameters(p));
                });
                resultModel.AffectCount = conn.Execute(cmd, dynamicParameters);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 執行異動類型(POST、UPDATE、DELETE)
        /// 單一資料表
        /// Trans資料庫交易
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel ExecuteTrans(string cmd, Dictionary<string, object> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using (var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤")))
                using (var conn = MSGetConfig.AutoEstablishConnection())
                {
                    using (var trans = conn.BeginTransaction())
                    {
                        resultModel.AffectCount = conn.Execute(cmd, parameters, trans);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 執行異動類型(POST、UPDATE、DELETE)
        /// 多張資料表
        /// Trans資料庫交易
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel ExecuteTrans(string cmd, List<Dictionary<string, object>> parameters)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using (var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤")))
                using (var conn = MSGetConfig.AutoEstablishConnection())
                {
                    using (var trans = conn.BeginTransaction())
                    {
                        var dynamicParameters = new List<DynamicParameters>();
                        parameters.ForEach(p =>
                        {
                            dynamicParameters.Add(new DynamicParameters(p));
                        });
                        resultModel.AffectCount = conn.Execute(cmd, dynamicParameters, trans);
                        trans.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 執行異動類型(POST、UPDATE、DELETE)
        /// 單一資料表
        /// 為引入Trans資料庫交易
        /// 可以取代Insert程序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel<T> ExecuteScalar<T>(string cmd, Dictionary<string, object> parameters)
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                //using (var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤")))
                using (var conn = MSGetConfig.AutoEstablishConnection())
                {
                    resultModel.Data = conn.ExecuteScalar<T>(cmd, new DynamicParameters(parameters));
                }
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// 執行預存程序類型
        /// </summary>
        /// <typeparam name="DynamicParameters"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IResultModel<DynamicParameters> ExecuteProcedure<DynamicParameters>(string cmd, DynamicParameters parameters)
        {
            IResultModel<DynamicParameters> resultModel = new ResultModel<DynamicParameters>();
            try
            {
                //using (var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤")))
                using (var conn = MSGetConfig.AutoEstablishConnection())
                {
                    resultModel.AffectCount = conn.Execute(cmd, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    resultModel.Data = parameters;
                }
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }

        /// <summary>
        /// 執行預存程序類型
        /// </summary>
        /// <typeparam name="DynamicParameters">The type of the ynamic parameters.</typeparam>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="exeSPModel">The via query.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Implementation.DoBase.Exception">_baselogger 日誌記錄發生錯誤</exception>
        public IResultModel ExecuteProcedure<DynamicParameters>(string cmd, DynamicParameters parameters, ExecuteStoreProcedueType exeSPModel)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using (var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤")))
                using (var conn = MSGetConfig.AutoEstablishConnection())
                {
                    switch (exeSPModel)
                    {
                        case ExecuteStoreProcedueType.ViaQuery:
                            var resultViaQuery = conn.Query(cmd, parameters, commandType: CommandType.StoredProcedure);
                            var json = JsonConvert.SerializeObject(resultViaQuery);
                            var dtViaQuery = JsonConvert.DeserializeObject<DataTable>(json);
                            if (dtViaQuery is not null)
                            {
                                if (dtViaQuery.Rows.Count > 0)
                                {
                                    resultModel.ReturnCombinationResult = dtViaQuery.Rows[0]["NewID"].ToString() ?? "";
                                }
                            }
                            else
                            {
                                throw new Exception("ExecuteStoreProcedueType.ViaQuery\r\n取號模式發生NULL錯誤\r\n作業已終止。");
                            }
                            break;
                        case ExecuteStoreProcedueType.ViaExecuteReader:
                            var resultViaExecuteReader = conn.ExecuteReader(cmd, parameters, commandType: CommandType.StoredProcedure);
                            var dtViaExecuteReader = new DataTable();
                            dtViaExecuteReader.Load(resultViaExecuteReader);
                            if (dtViaExecuteReader.Rows.Count > 0)
                            {
                                resultModel.ReturnCombinationResult = dtViaExecuteReader.Rows[0]["NewID"].ToString() ?? "";
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                resultModel.ReturnCombinationResult = ex.Message;
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }

        /// <summary>
        /// 產生分頁 SQL
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        private static string GetPagedCommand(string cmd, string orderBy, int pageSize, int pageIndex)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "1";
            }

            pageIndex = pageIndex == 0 ? 0 : pageIndex - 1;
            int pageStart = pageIndex * pageSize;
            string queryCmd = $"SELECT Paged.* FROM (SELECT ROW_NUMBER() OVER " +
                            $"(ORDER BY {orderBy}) AS Row, Query.* " +
                            $"FROM ({cmd}) as Query) AS Paged WHERE Row>{pageStart} " +
                            $"AND Row<={pageStart + pageSize} ;";
            queryCmd += $"select count(*) as TotalCount from ({cmd}) as paged";
            return queryCmd;
        }

        /// <summary>
        /// 設定結果
        /// </summary>
        /// <param name="result"></param>
        public void SetResult(IResult result)
        {
            IsSuccess = result.IsSuccess;
            Message = result.Message;
            Exception = result.Exception;
            TotalCount = result.TotalCount;
            AffectCount = result.AffectCount;
        }

        /*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
        * 編輯作者：REMARK BY CALVIN
        * 說明：Dapper.Controlib CRUD
        * 備註：
        * ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
        */

        /// <summary>
        /// Dapper.Controlib CRUD - Update Single Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Implementation.DoBase.Exception">_baselogger 日誌記錄發生錯誤</exception>
        public IResultModel ContribUpdateTrans<T>(T obj) where T : class
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.IsSuccess = conn.Update<T>(obj);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Update List Entitys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Implementation.DoBase.Exception">_baselogger 日誌記錄發生錯誤</exception>
        public IResultModel ContribUpdateTrans<T>(IEnumerable<T> list)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.IsSuccess = conn.Update(list);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Insert Single Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IResultModel ContribCreateTrans<T>(T obj) where T : class
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.AffectCountTypeLong = conn.Insert<T>(obj);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Insert List Entitys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public IResultModel ContribCreateTrans<T>(IEnumerable<T> list)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.AffectCountTypeLong = conn.Insert(list);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Delete Single Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IResultModel ContribDeleteTrans<T>(T obj) where T : class
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.IsSuccess = conn.Delete<T>(obj);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Delete List Entitys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public IResultModel ContribDeleteTrans<T>(IEnumerable<T> list)
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.IsSuccess = conn.Delete(list);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Delete All Target Entitys
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IResultModel ContribDeleteAllTrans<T>() where T : class
        {
            IResultModel resultModel = new ResultModel();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.IsSuccess = conn.DeleteAll<T>();
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Dapper.Controlib CRUD - Read Target Entity With id Condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResultModel<T> ContribQuery<T>(string id) where T : class
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.Data = conn.Get<T>(id);
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
        /// <summary>
        /// Contribs the query all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">_baselogger 日誌記錄發生錯誤</exception>
        public IResultModel<T> ContribQueryAll<T>() where T : class
        {
            IResultModel<T> resultModel = new ResultModel<T>();
            try
            {
                //using var conn = DbFactory.GetConnection(_baselogger ?? throw new Exception("_baselogger 日誌記錄發生錯誤"));
                using var conn = MSGetConfig.AutoEstablishConnection();
                resultModel.DataList = conn.GetAll<T>();
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Exception = ex;

                _baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage(true));
            }

            SetResult(resultModel);
            return resultModel;
        }
    }
}