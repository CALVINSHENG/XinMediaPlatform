#region SonarLint Disabled 放置區域
#pragma warning disable S125
//警告 S125 Remove this commented out code.
#pragma warning disable IDE0066
//訊息 IDE0066 使用 'switch' 運算式
#pragma warning disable CA2254
//訊息 CA2254  記錄訊息範本不應在與
//'LoggerExtensions.LogError(ILogger, string?, params object?[])' 通話期間改變
#pragma warning disable S112
//警告 S112 'System.Exception' should not be thrown by user code
#pragma warning disable S1854
//警告 S1854 Remove this useless assignment to local variable '_preposition'.
#pragma warning disable IDE0059
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//訊息 IDE0059 對 'NewID' 指派了不必要的值 MicroServiceCoreResposity   C:\Users\CalvinSheng\source\repos\Dev\V1\DEV_ENVIR\MEMBER\CALVIN\DEVELOPMENT\CloudServicePlatform_20230222\MicroServiceCoreResposity\DbAccess\Helpers\GenSerialNumberHelper.cs	137	作用中
#pragma warning disable VSSpell001 // Spell Check
#endregion

using Dapper;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
	/// <summary>
	/// GenSerialNumberHelper
	/// </summary>
	/// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
	public class GenSerialNumberHelper : DoBase
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
		public GenSerialNumberHelper(ILogger<BaseLogger> baselogger) : base(baselogger)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(2)
		/// </summary>
		/// <param name="baselogger"></param>
		/// <param name="ConnectionString"></param>
		/// <param name="EnvironmentVal"></param>
		public GenSerialNumberHelper(ILogger<BaseLogger> baselogger, string ConnectionString, int EnvironmentVal) : base(baselogger, ConnectionString, EnvironmentVal)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(3)
		/// </summary>
		public GenSerialNumberHelper()
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
		/// <br/>取得系統流水編號共用工具
		/// <br/>░░░░░░░░░░░░░░░░░░
		/// <br/>exeSPModel：執行底層方式
		/// <br/>tableName：資料庫資料表名稱
		/// <br/>preposition：前置詞名稱
		/// <br/>jointDateCode：是否加入日期產生流水號
		///         <br/>》》》預設true
		///         <br/>》》》0：不加入日期；1：加入日期
		/// <br/>CompanyCode：個體代碼
		///         <br/>》》》預設-1：代表不使用特殊流水號產生程序
		///         <br/>》》》公司編號("0"-"A"->個人；"1"-"B"->公司)
		/// <br/>CompanyCategory：公司編號大類
		/// <br/>CompanySubcategory：公司編號中類
		/// <br/>serialNumberLength：流水號長度限制
		/// <br/>resetIDTimestamp：重製流水號編碼從1開始時間戳記
		///         <br/>》》》預設-3：每日重置
		///         <br/>》》》重置取號時間點(1：年度重置；2：月份重置；3：每日重置)
		/// <br/>
		/// </summary>
		/// <param name="exeSPModel">執行底層方式</param>
		/// <param name="tableName">資料庫資料表名稱</param>
		/// <param name="preposition">前置詞名稱</param>
		/// <param name="jointDateCode">是否加入日期產生流水號</param>
		/// <param name="CompanyCode">個體代碼</param>
		/// <param name="CompanyCategory">公司編號大類</param>
		/// <param name="CompanySubcategory">公司編號中類</param>
		/// <param name="serialNumberLength">流水號長度限制</param>
		/// <param name="resetIDTimestamp">重置流水號編碼從1開始時間戳記</param>
		/// <returns></returns>
		public string Generate(
			ExecuteStoreProcedueType exeSPModel
			, out string feedbackMessage
			, string tableName
			, bool jointDateCode = true
			, int companyCode = -1
			, int serialNumberLength = 4
			, int resetIDTimestamp = 3
		)
		{
			var serialNumber = "";
			var newID = "";
			var executionMessage = "";
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

				var _preposition = "";
				var _prefixCompanyCode = "";
				var _companyCategory = "H";    //companyCategory;
				var _companySubcategory = "49";    //companySubcategory;
				if (companyCode > -1 && companyCode < 2)
				{
					switch (companyCode)
					{
						case 0:
							//個人
							_prefixCompanyCode = "A";
							break;
						case 1:
							//企業
							_prefixCompanyCode = "B";
							break;
						default:
							throw new Exception("個體代碼參數輸入錯誤");
					}
					if (string.IsNullOrEmpty(_companyCategory) || string.IsNullOrEmpty(_companySubcategory))
					{
						throw new Exception("個體代碼大類或是中類參數未輸入");
					}
					else
					{
						_preposition = @"" +
									_prefixCompanyCode +
									_companyCategory +
									_companySubcategory;
					}
				}
				else if (companyCode == -1)
				{
					foreach (PrepositionMapping item in Enum.GetValues(typeof(PrepositionMapping)))
					{
						if (item.ToString() == _tableName.ToUpper())
						{
							_preposition = item.GetDescription();
						}
					}
				}
				else
				{
					throw new Exception("參數錯誤：CompanyCode僅允許-1,0,1");
				}

				var _serialNumberLength = (serialNumberLength < 2 || serialNumberLength > 4)
											? throw new Exception("流水號長度不正確")
											: serialNumberLength;

				var _resetIDTimestamp = (resetIDTimestamp > 3 || resetIDTimestamp < 0)
											? throw new Exception("重置取號時間點")
											: resetIDTimestamp;

				var _jointDateCode = (jointDateCode)
										? 1
										: 0;

				var parameters = new DynamicParameters();
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：定義傳入參數
				* 1. 傳入參數
				* 2. 順序依照USP的參數順序
				*/
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：必填參數
				*/
				parameters.Add(
					"@KeyType"
					, _tableName.ToUpper()
					, DbType.String
					, ParameterDirection.Input);
				parameters.Add(
					"@Prefix"
					, _preposition.ToUpper()
					, DbType.String
					, ParameterDirection.Input);
				parameters.Add(
					"@NumberLen"
					, _serialNumberLength
					, DbType.Decimal
					, ParameterDirection.Input);
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：具Optional必填參數
				*/
				parameters.Add(
					"@NeedApplyDate"
					, _jointDateCode
					, DbType.Decimal
					, ParameterDirection.Input);
				parameters.Add(
					"@ResetType"
					, _resetIDTimestamp
					, DbType.Decimal
					, ParameterDirection.Input);
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：具Optional非必填參數
				* 1.CompanyCategory和CompanySubcategory相依CompanyCode
				* 2.CompanyCode有值(0：個人；1：企業) CompanyCategory和CompanySubcategory為必填
				* 3.CompanyCode有值(0：個人；1：企業) CompanyCategory和CompanySubcategory為非必填  
				*/
				int number = companyCode;
				bool conversionSuccessful = int.TryParse(_prefixCompanyCode, out number);
				if (conversionSuccessful)
				{
					parameters.Add(
					"@CompanyCode"
					, number
					, DbType.Int32
					, ParameterDirection.Input);
				}
				else
				{
					parameters.Add(
					"@CompanyCode"
					, companyCode
					, DbType.Int32
					, ParameterDirection.Input);
				}
				parameters.Add(
					"@CompanyCategory"
					, _companyCategory
					, DbType.String
					, ParameterDirection.Input);
				parameters.Add(
					"@CompanySubcategory"
					, _companySubcategory
					, DbType.String
					, ParameterDirection.Input);
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/02/03
				* 說明：定義回傳參數
				* 1. 回傳參數
				* 2. 順序依照USP的參數順序
				* 3. 依據預存程序的回傳變數名稱
				*/
				parameters.Add(
					"@NewID"
					, dbType: DbType.String
					, direction: ParameterDirection.ReturnValue);

				var result = base.ExecuteProcedure<DynamicParameters>(
							"sp_GenIDToSerialNumber"
							, parameters
							, exeSPModel
						);
				if (result.IsSuccess)
				{
					/*
					* 編輯作者：REMARK BY CALVIN AT 2023/02/03
					* 說明：取得預存程序回傳組合資訊
					* 1. 編碼流水號
					* 2. 預存程序執行結果
					*/
					newID = result.ReturnCombinationResult.Split('|')[0].Trim();
					executionMessage = result.ReturnCombinationResult.ToString().Split('|')[1].Trim();
					if (string.IsNullOrEmpty(newID))
					{
						/*
						* 編輯作者：REMARK BY CALVIN AT 2023/02/03
						* 說明：預存程序執行失敗
						*/
						result.IsSuccess = false;
						serialNumber = newID ?? "";
						throw new Exception(executionMessage);
					}
					else
					{
						/*
						* 編輯作者：REMARK BY CALVIN AT 2023/02/03
						* 說明：二次防呆
						* 備註：
						* resultModel.ReturnCombinationResult = dtViaQuery.Rows[0]["NewID"].ToString() ?? "";
						* resultModel.ReturnCombinationResult = dtViaExecuteReader.Rows[0]["NewID"].ToString() ?? "";
						*/
						if (string.IsNullOrEmpty(result.ReturnCombinationResult))
						{
							throw new Exception("取號失敗：流水號目前無法取得，請稍後再行嘗試操作");
						}
						else
						{
							serialNumber = newID ?? "";
						}
					}
				}
				//return parameters.Get<string>("@NewID") ?? "";
			}
			catch (Exception ex)
			{
				StringBuilder ExceptionMessage = new(
						NLogHelper.FetchCompleteMessage()
					);
				_baselogger?.LogError(ex, ExceptionMessage.ToString());
			}

			feedbackMessage = executionMessage;
			return !string.IsNullOrEmpty(serialNumber)
										? serialNumber
										: string.Empty;
		}
	}
}
