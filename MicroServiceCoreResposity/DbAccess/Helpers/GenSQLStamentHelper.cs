#region SonarLint Disabled 放置區域
#pragma warning disable CA2254
//訊息 CA2254  記錄訊息範本不應在與
//'LoggerExtensions.LogError(ILogger, string?, params object?[])' 通話期間改變
#pragma warning disable S1066 // Collapsible "if" statements should be merged
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Common;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    /// <summary>
    /// GenSqlStamentHelper
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
    public class GenSqlStamentHelper : DoBase
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
		public GenSqlStamentHelper(ILogger<BaseLogger> baselogger) : base(baselogger)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(2)
		/// </summary>
		/// <param name="baselogger"></param>
		/// <param name="ConnectionString"></param>
		/// <param name="EnvironmentVal"></param>
		public GenSqlStamentHelper(ILogger<BaseLogger> baselogger, string ConnectionString, int EnvironmentVal) : base(baselogger, ConnectionString, EnvironmentVal)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(3)
		/// </summary>
		public GenSqlStamentHelper()
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
		public ILogger? Get_baselogger()
		{
			return _baselogger;
		}

		#endregion

		/// <summary>
		/// <br/>動態產生SQL語法
		/// <br/>░░░░░░░░░░░░░░░░░░
		/// 組成參數值前<br/>
		/// 1.動態產生SQL語法<br/>
		/// 2.加入組合Dapper資料庫欄位所需要前置修飾字元<br/><br/>
		/// SqlOperatorDateType 提供<br/>
		/// 》》》CREATE<br/>
		/// 》》》READ<br/>
		/// 》》》UPDATE<br/>
		/// 》》》DELETE<br/>
		/// 語法<br/>
		/// </summary>
		/// <param name="operatorType">SQL語法類型</param>
		/// <param name="tableName">資料表名稱</param>
		/// <param name="dynObj">資料模型(資料)</param>
		/// <param name="props">特性集合</param>
		/// <param name="fieldsPrefixSymbol">前置修飾字元</param>
		/// <returns></returns>
		public string Get(
			SqlOperatorDateType operatorType
			, string tableName
			, dynamic dynObj
			, PropertyInfo[] props
			, string? fieldsPrefixSymbol = "@")
		{
			string result = string.Empty;
			try
			{
				/*
				* 編輯作者：REMARK BY CALVIN AT 2023/03/09
				* 說明：避免第一次","被加入CREATE欄位
				*/
				bool FirstExeclude = true;
				StringBuilder sqlCmdHeader = new StringBuilder();
				StringBuilder sqlCmdTail = new StringBuilder();

				switch (operatorType)
				{
					case SqlOperatorDateType.CREATE:
						{
							sqlCmdHeader.AppendLine("INSERT INTO [DBO].[" + tableName.ToLower().Trim() + "] (");
							sqlCmdTail.AppendLine(" VALUES (");
						}
						break;
					case SqlOperatorDateType.READ:
						{
							sqlCmdHeader.AppendLine("SELECT * FROM [DBO].[" + tableName.ToLower().Trim() + "]");
						}
						break;
				}

				var resourceNames = new List<string>();
				bool forceBreak = true;

				foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
				{
					/*
					* 編輯作者：ADD BY CALVIN AT 2023/01/03
					* 說明：第一層(資料模型：欄位名稱+欄位值)
					*/
					foreach (PropertyInfo prop in props)
					{
						if (forceBreak)
						{
							/*
							* 編輯作者：ADD BY CALVIN AT 2023/01/03
							* 說明：幫篩選到重複的欄位時，強制跳出第二層返回第一層取下一個欄位名稱進行比對
							*/
							forceBreak = false;
							break;
						}
						/*
						* 編輯作者：ADD BY CALVIN AT 2023/01/03
						* 說明：第二層(特性組合：欄位名稱+欄位描述)
						* 備註：所有資料模型欄位有掛載的特性都會被引入
						*/
						object[] attrs = prop.GetCustomAttributes(true);

						foreach (object attr in attrs)
						{
							if (attr is ColumnsParametersAttribute attriField)
							{
								/*
								* 編輯作者：ADD BY CALVIN AT 2023/01/03
								* 說明：第三層(特性指定：欄位名稱+僅針對加解密的布林值特性)
								* 備註：使用　if (attr is NeedEnDecriptAttribute attriField)　進行篩選
								*/
								/*
								* 編輯作者：ADD BY CALVIN AT 2023/01/03
								* 說明：裝載 Dictionary<String, Object>
								*/
								if (SearchTargetCommon.FindListDuplicates(resourceNames, propertyDescriptor.Name.ToLower()))
								{
									if (attriField.Name.ToLower().Equals(propertyDescriptor.Name.ToLower()))
									{
										switch (operatorType)
										{
											case SqlOperatorDateType.CREATE:
												{
													if (!FirstExeclude)
													{
														sqlCmdHeader.Append(", ");
														sqlCmdTail.Append(", ");
													}
													sqlCmdHeader.AppendLine("[" + attriField.Name.ToLower() + "]");
													sqlCmdTail.AppendLine(fieldsPrefixSymbol + attriField.Name.ToLower());
													/*
													* 編輯作者：REMARK BY CALVIN AT 2023/03/09
													* 說明：設定為false，讓後續欄位加入","
													*/
													FirstExeclude = false;
												}
												break;
											case SqlOperatorDateType.READ:
												{
													sqlCmdHeader.AppendLine("");
													sqlCmdTail.AppendLine("");
												}
												break;
										}
										resourceNames.Add(propertyDescriptor.Name.ToLower());
										forceBreak = true;
										break;
									}
								}
							}
						}
					}
				}

				switch (operatorType)
				{
					case SqlOperatorDateType.CREATE:
						{
							return sqlCmdHeader.AppendLine(")")
									.AppendLine
									(
										sqlCmdTail
										.AppendLine(
											");"
										)
										.ToString()
									)
									.ToString();
						}
					case SqlOperatorDateType.READ:
						{
							return sqlCmdHeader.AppendLine("")
									.AppendLine
									(
										sqlCmdTail
										.AppendLine(
											""
										)
										.ToString()
									)
									.ToString();
						}
				}
				result = "";
				return result ?? throw new Exception("" +
								"\r\n已記錄Log且建立錯誤日誌：\r\n\r\n" +
								"\r\n無法產生SQL指令\r\n" +
								"請檢查設定命令是否正確");
			}
			catch (Exception ex)
			{
				StringBuilder ExceptionMessage = new(
						NLogHelper.FetchCompleteMessage()
					);
				_baselogger?.LogError(ex, ExceptionMessage.ToString());

				return "";
			}
		}
	}
}