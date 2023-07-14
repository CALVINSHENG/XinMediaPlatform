using Dapper;
using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Models;
using MicroServiceCoreResposity.Implementation;
using MicroServiceCoreResposity.Models.CommonLabel;
using MicroServiceCoreResposity.Models.CommonLabel.Entity;
using MicroServiceCoreResposity.Models.CommonLabel.InputType;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text;
using BaseLogger = MicroServiceCoreLibrary.Logger.BaseLogger;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    #region SonarLint Disabled 放置區域
#pragma warning disable CS8604 // 可能有 Null 參考引數。
#pragma warning disable S3626 // Jump statements should not be redundant
#pragma warning disable S112 // General exceptions should never be thrown

    #endregion

    /// <summary>
    /// CommonLabelHelper
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
    public class CommonLabelHelper : DoBase
    {
        #region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
        /// <summary>
        /// The baselogger
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonLabelHelper"/> class.
        /// 建構子(一)
        /// </summary>
        /// <param name="baselogger"></param>
        public CommonLabelHelper(ILogger<BaseLogger>? baselogger)
        {
            _baselogger = baselogger;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonLabelHelper"/> class.
        /// 建構子(二)
        /// </summary>
        public CommonLabelHelper() { }

        #endregion

        /// <summary>
        /// Updates the common label dt.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="function_no">The function no.</param>
        /// <param name="labellist">The labellist.</param>
        /// <param name="function_type">Type of the function.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">修改 標籤關聯表 失敗，作業終止。</exception>
        public TCommonLabelConnection UpdateCommonLabelDT(ClaimsUserData principal, string function_no, List<CommonLabelInputType> labellist, string function_type)
        {
            IsSuccess = false;
            var result = new TCommonLabelConnection();
            var conn = MSGetConfig.AutoEstablishConnection();
            var trans = conn.BeginTransaction();

            try
            {
                var function_result = DeleteLabelDT(conn, trans, function_no);

                if (function_result)
                {
                    if (labellist.FirstOrDefault() is null)
                    {
                        result = new TCommonLabelConnection
                        {
                            issuccess = true,
                            conn = conn,
                            trans = trans
                        };
                        return result;
                    }
                    
                    function_result = CheckLabelExisted(conn, trans, labellist, principal, function_no, function_type);
                    if (function_result)
                    {
                        IsSuccess = true;
                    }
                }
                else
                {
                    IsSuccess = false;
                    trans.Rollback();
                    throw new Exception("修改 標籤關聯表 失敗，作業終止。");
                }

                if (IsSuccess == true)
                {
                    result = new TCommonLabelConnection
                    {
                        issuccess = true,
                        conn = conn,
                        trans = trans
                    };
                    return result;
                }
            }
            catch (Exception ex)
            {
                StringBuilder ExceptionMessage = new(
                            NLogHelper.FetchCompleteMessage()
                        );
                _baselogger?.LogError(ex, ExceptionMessage.ToString());
            }

            conn.Close();
            conn.Dispose();

            result = new TCommonLabelConnection
            {
                issuccess = false,
                conn = conn,
                trans = trans
            };
            return result;
        }

        /// <summary>
        /// Updates the common label dt.
        /// </summary>
        /// <param name="principal">The principal.</param>
        /// <param name="function_no">The function no.</param>
        /// <param name="labellist">The labellist.</param>
        /// <param name="function_type">Type of the function.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="trans">The trans.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">修改 標籤關聯表 失敗，作業終止。</exception>
        public TCommonLabelConnection UpdateCommonLabelDT(ClaimsUserData principal, string function_no, List<CommonLabelInputType> labellist, string function_type, IDbConnection conn, IDbTransaction trans)
        {
            IsSuccess = false;
            var result = new TCommonLabelConnection();

            try
            {
                var function_result = DeleteLabelDT(conn, trans, function_no);

                if (function_result)
                {
                    if (labellist is null)
                    {
                        result = new TCommonLabelConnection
                        {
                            issuccess = true,
                            conn = conn,
                            trans = trans
                        };
                        return result;
                    }

                    function_result = CheckLabelExisted(conn, trans, labellist, principal, function_no, function_type);
                    if (function_result)
                    {
                        IsSuccess = true;
                    }
                }
                else
                {
                    IsSuccess = false;
                    trans.Rollback();
                    throw new Exception("修改 標籤關聯表 失敗，作業終止。");
                }

                if (IsSuccess == true)
                {
                    result = new TCommonLabelConnection
                    {
                        issuccess = true,
                        conn = conn,
                        trans = trans
                    };
                    return result;
                }
            }
            catch (Exception ex)
            {
                StringBuilder ExceptionMessage = new(
                            NLogHelper.FetchCompleteMessage()
                        );
                _baselogger?.LogError(ex, ExceptionMessage.ToString());
            }

            result = new TCommonLabelConnection
            {
                issuccess = false,
                conn = conn,
                trans = trans
            };
            return result;

        }

        /// <summary>
        /// Deletes the label dt.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="trans">The trans.</param>
        /// <param name="function_no">The function no.</param>
        /// <returns></returns>
        internal bool DeleteLabelDT(IDbConnection conn, IDbTransaction trans, string function_no)
        {
            var delete_label_model = new TCommonDtLabel();
            delete_label_model.function_no = function_no;

            var labelDtdelete = @"
                        DELETE FROM
                            common_label_dt
                        WHERE
                            function_no = @function_no
                        ;";
            AffectCount = conn.Execute(labelDtdelete, delete_label_model, trans);

            if (AffectCount >= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks the label existed.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="trans">The trans.</param>
        /// <param name="labellist">The labellist.</param>
        /// <param name="principal">The principal.</param>
        /// <param name="function_no">The function no.</param>
        /// <param name="function_type">Type of the function.</param>
        /// <returns></returns>
        /// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">
        /// 修改 common_label 資料表失敗，作業終止。
        /// or
        /// 修改 common_label_dt 關聯表失敗，作業終止
        /// </exception>
        internal bool CheckLabelExisted(IDbConnection conn, IDbTransaction trans, List<CommonLabelInputType> labellist, ClaimsUserData principal, string function_no, string function_type)
        {
            for (int i = 0; i < labellist.Count; i++)
            {
                var md_label = new TCommonLabelEntity();
                var common_label_dt = new TCommonDtLabel();

                // 檢查標籤是否存在
                md_label.function_type = function_type;
                md_label.company_no = principal.company_no;
                md_label.label_name = labellist[i].label_name;

                var check_label_sql = @"
                                SELECT 
                                    label_no
                                FROM 
                                    common_label
                                WHERE
                                    label_name = @label_name
                                AND
                                    company_no = @company_no
                                AND
                                    function_type = @function_type
                                ;";
                var check_result = conn.Query<TCommonLabelEntity>(check_label_sql, md_label, trans).FirstOrDefault();

                if (check_result is null)
                {
                    // 標籤不存在，新增
                    string feedbackMessage;
                    md_label.label_no = new GenSerialNumberHelper(_baselogger).Generate(
                            MicroServiceCoreLibrary.Common.EnumDefineCommon.ExecuteStoreProcedueType.ViaExecuteReader,
                            out feedbackMessage,
                            "common_label"
                        );

                    md_label.company_no = principal.company_no;
                    md_label.function_no = function_no;
                    md_label.function_type = function_type;
                    md_label.label_name = labellist[i].label_name;
                    md_label.label_status = "1";
                    md_label.creid = principal.user_no;
                    md_label.updid = principal.user_no;
                    md_label.credate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    md_label.upddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    var newlabelsql = @"
                                    INSERT INTO
                                        common_label(label_no, company_no, function_type, label_name, label_status, creid, credate, updid, upddate)
                                    VALUES
                                        (@label_no, @company_no, @function_type, @label_name, @label_status, @creid, @credate, @updid, @upddate)
                                    ;";
                    AffectCount = conn.Execute(newlabelsql, md_label, trans);
                    if (AffectCount <= 0)
                    {
                        IsSuccess = false;
                        trans.Rollback();
                        throw new Exception("修改 common_label 資料表失敗，作業終止。");
                    }
                    common_label_dt.label_no = md_label.label_no;
                }
                else
                {
                    common_label_dt.label_no = check_result.label_no;
                }

                common_label_dt.function_no = function_no;

                // 插入標籤關聯表
                var labeldtsql = @"
                                    INSERT INTO
                                        common_label_dt(label_no, function_no)
                                    VALUES
                                        (@label_no, @function_no)
                                ;";
                AffectCount = conn.Execute(labeldtsql, common_label_dt, trans);
                if (AffectCount > 0)
                {
                    IsSuccess = true;
                    continue;
                }
                else
                {
                    IsSuccess = false;
                    trans.Rollback();
                    throw new Exception("修改 common_label_dt 關聯表失敗，作業終止");
                }
            }
            if (IsSuccess == true)
            {
                return true;
            }
            return false;
        }
    }
}
