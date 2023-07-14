using Dapper;
using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Logging;
using System.Data;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
	#region SonarLint Disabled 放置區域
	//#pragma warning disable CS8600
#pragma warning disable S112
	//警告 S112    'System.Exception' should not be thrown by user code.
#pragma warning disable S1481
	//警告 S1481   Remove the unused local variable 'ExecutionMessage'.
#pragma warning disable CA2254
	//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
	//訊息 CA2254  記錄訊息範本不應在與 'LoggerExtensions.LogError(ILogger, Exception?, string?, params object?[])' 通話期間改變 MicroServiceCoreResposity   C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GenDataViaStoreProcedureHelper.cs	157	作用中

	#endregion

	/// <summary>
	/// GenDataViaStoreProcedureHelper
	/// </summary>
	/// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
	public class GenDataViaStoreProcedureHelper : DoBase
	{
		#region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
		/// <summary>
		/// The baselogger
		/// </summary>
		private readonly ILogger<BaseLogger>? _baselogger;

		/// <summary>
		/// 建構子初始化方式(1)
		/// </summary>
		/// <param name="baselogger"></param>
		public GenDataViaStoreProcedureHelper(ILogger<BaseLogger> baselogger) : base(baselogger)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(2)
		/// </summary>
		/// <param name="baselogger"></param>
		/// <param name="ConnectionString"></param>
		/// <param name="EnvironmentVal"></param>
		public GenDataViaStoreProcedureHelper(ILogger<BaseLogger> baselogger, string ConnectionString, int EnvironmentVal) : base(baselogger, ConnectionString, EnvironmentVal)
		{
			_baselogger = baselogger;
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
		/// Genenators the dynamic class.
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		/// <returns></returns>
		/// <exception cref="MicroServiceCoreResposity.Entity.ResultModel`1.Exception">
		/// 請輸入資料表名稱
		/// or
		/// 存取預存程序失敗
		/// </exception>
		public string GenenatorDynamicClass(string tableName)
		{
			var classModelResult = "";
			try
			{
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：參數防呆
				*/
				var _tableName = tableName;
				_tableName = string.IsNullOrEmpty(tableName)
								? throw new Exception("請輸入資料表名稱")
								: tableName;

				var parameters = new DynamicParameters();
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：具Optional必填參數
				*/
				parameters.Add(
					"@TableName"
					, _tableName
					, DbType.String
					, ParameterDirection.Input);
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：具Optional非必填參數
				* 1.CompanyCategory和CompanySubcategory相依CompanyCode
				* 2.CompanyCode有值(0：個人；1：企業) CompanyCategory和CompanySubcategory為必填
				* 3.CompanyCode有值(0：個人；1：企業) CompanyCategory和CompanySubcategory為非必填  
				*/
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：定義回傳參數
				* 1. 回傳參數
				* 2. 順序依照USP的參數順序
				* 3. 依據預存程序的回傳變數名稱
				*/
				parameters.Add(
					"@Result"
					, dbType: DbType.String
					, direction: ParameterDirection.ReturnValue);

				/*
					* 編輯作者：REMARK BY CALVIN AT 2023/02/10
					* 說明：手動實體化資料連線
					* 備註：底層不得有非共用的私有寫法
					*/
				using var conn = MSGetConfig.AutoEstablishConnection();
				var result = conn.ExecuteReader("sp_GenDBColumnToClass", parameters, commandType: CommandType.StoredProcedure);
				var dt = new DataTable();
				dt.Load(result);
				if (dt.Rows.Count > 0)
				{
					classModelResult = dt.Rows[0]["Result"].ToString() ?? "";
					if (string.IsNullOrEmpty(classModelResult))
					{
						throw new Exception("存取預存程序失敗");
					}
					else
					{
						var Class = classModelResult.Split('|')[0].Trim();
						var ExecutionMessage = classModelResult.Split('|')[1].Trim();
						classModelResult = Class;
					}
				}
			}
			catch (Exception ex)
			{
				_baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage());
			}

			return classModelResult ?? throw new Exception("存取預存程序失敗");
		}
	}
}
