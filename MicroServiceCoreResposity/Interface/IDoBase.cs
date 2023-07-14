#region SonarLint Disabled 放置區域
#pragma warning disable S4136 // Method overloads should be grouped together
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S125 // Sections of code should not be commented out
#endregion

using Microsoft.Diagnostics.Runtime;
using System.Data;

namespace MicroServiceCoreResposity.Interface
{
    /// <summary>
    /// IDoBase
    /// </summary>
    public interface IDoBase
    {
        /// <summary>
        /// Gets or sets the is success.
        /// </summary>
        /// <value>
        /// The is success.
        /// </value>
        bool? IsSuccess { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string? Message { get; set; }
        /// <summary>
        /// Gets or sets the affect count.
        /// </summary>
        /// <value>
        /// The affect count.
        /// </value>
        int AffectCount { get; set; }
        /// <summary>
        /// Gets or sets the affect count type long.
        /// </summary>
        /// <value>
        /// The affect count type long.
        /// </value>
        long AffectCountTypeLong { get; set; }
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        Exception? Exception { get; set; }
        /// <summary>
        /// Queries the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns></returns>
        List<dynamic> Query(string cmd);
        /// <summary>
        /// Queries the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        List<dynamic> Query(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Queries the data table.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel QueryDataTable(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Queries the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel<T> Query<T>(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Queries the single.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel<T> QuerySingle<T>(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Queries the paged.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="pageModel">The page model.</param>
        /// <returns></returns>
        IResultModel<T> QueryPaged<T>(string cmd, IDictionary<string, object> parameters, IPageModel pageModel);
        /// <summary>
        /// Inserts the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel<T> Insert<T>(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Updates the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel Update(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Deletes the specified command.
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IResultModel Delete(string cmd, IDictionary<string, object> parameters);
        /// <summary>
        /// Executes the transation.
        /// 多表同時異動(方法一)
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="tran">The tran.</param>
        /// <returns></returns>
        IResultModel ExecuteTransation(
            List<Tuple<string, string, object>> list
            , IDbConnection? conn = null
            , IDbTransaction? tran = null);
        /// <summary>
        /// Executes the transation SQL bulk.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="conn">The connection.</param>
        /// <param name="tran">The tran.</param>
        /// <returns></returns>
        IResultModel ExecuteTransationSQLBulk(
            List<Tuple<string, string, object>> entityList
            , IDbConnection? conn = null
            , IDbTransaction? tran = null);
        ///// <summary>
        ///// Executes the transation.
        ///// 多表同時異動(方法二)
        ///// </summary>
        ///// <param name="list">The list.</param>
        ///// <param name="isEraseSubList">if set to <c>true</c> [is erase sub list].</param>
        ///// <param name="conn">The connection.</param>
        ///// <param name="tran">The tran.</param>
        ///// <returns></returns>
        //IResultModel ExecuteTransation(
        //    List<Tuple<string, string, object>> list
        //    , bool isEraseSubList = false
        //    , IDbConnection? conn = null
        //    , IDbTransaction? tran = null);
        /*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
        * 編輯作者：REMARK BY CALVIN
        * 說明：Dapper.Controlib CRUD
        * 備註：
        * ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
        */
        /// <summary>
        /// Contribs the update trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        IResultModel ContribUpdateTrans<T>(T obj) where T : class;
        /// <summary>
        /// Contribs the update trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        IResultModel ContribUpdateTrans<T>(IEnumerable<T> list);
        /// <summary>
        /// Contribs the create trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        IResultModel ContribCreateTrans<T>(T obj) where T : class;
        /// <summary>
        /// Contribs the create trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        IResultModel ContribCreateTrans<T>(IEnumerable<T> list);
        /// <summary>
        /// Contribs the delete trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        IResultModel ContribDeleteTrans<T>(T obj) where T : class;
        /// <summary>
        /// Contribs the delete trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        IResultModel ContribDeleteTrans<T>(IEnumerable<T> list);
        /// <summary>
        /// Contribs the delete all trans.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IResultModel ContribDeleteAllTrans<T>() where T : class;
        /// <summary>
        /// Contribs the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IResultModel<T> ContribQuery<T>(string id) where T : class;
        /// <summary>
        /// Contribs the query all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IResultModel<T> ContribQueryAll<T>() where T : class;
    }
}