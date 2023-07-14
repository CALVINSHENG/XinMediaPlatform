#region SonarLint Disabled 放置區域
//#pragma warning disable CS8600
#pragma warning disable S125
//警告  S125 Remove this commented out code.
// Code that uses obsolete API.
#pragma warning disable S1481
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S1481   Remove the unused local variable 'dictionary'.	MicroServiceCoreResposity C:\Users\calvinsheng\source\repos\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GetTryParseHelper.cs	88	作用中
#pragma warning disable S3063
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S3063   Remove this "StringBuilder"; ".ToString()" is never called.	MicroServiceCoreResposity C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GetTryParseHelper.cs	125	作用中
#pragma warning disable CS8604
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 CS8604  'PropertyInfo? Type.GetProperty(string name)' 中的參數 'name' 可能有 Null 參考引數。	MicroServiceCoreResposity C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GetTryParseHelper.cs	132	作用中
#pragma warning disable S1751
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//警告 S1751   Refactor the containing loop to do more than one iteration.MicroServiceCoreResposity   C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GetTryParseHelper.cs  141	作用中
#pragma warning disable CA2254
//嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
//訊息 CA2254  記錄訊息範本不應在與 'LoggerExtensions.LogError(ILogger, Exception?, string?, params object?[])' 通話期間改變 MicroServiceCoreResposity   C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreResposity\DbAccess\Helpers\GetTryParseHelper.cs	153	作用中
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.Implementation;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Numerics;
using System.Reflection;
using System.Text;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
	public class GetTryParseHelper : DoBase
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
		public GetTryParseHelper(ILogger<BaseLogger> baselogger) : base(baselogger)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(2)
		/// </summary>
		/// <param name="baselogger"></param>
		/// <param name="ConnectionString"></param>
		/// <param name="EnvironmentVal"></param>
		public GetTryParseHelper(ILogger<BaseLogger> baselogger, string ConnectionString, int EnvironmentVal) : base(baselogger, ConnectionString, EnvironmentVal)
		{
			_baselogger = baselogger;
		}

		/// <summary>
		/// 建構子初始化方式(3)
		/// </summary>
		public GetTryParseHelper()
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
		/// Checks the table.
		/// </summary>
		/// <param name="refModel"></param>
		/// <param name="props"></param>
		/// <returns></returns>
		public string Check(IEnumerable refModel, PropertyInfo[] props)
		{
			try
			{
				var dictionary = new Dictionary<string, object>();
				var resourceNames = new List<string>();

				foreach (var item in refModel)
				{
					foreach (PropertyInfo prop in props)
					{
						object[] attrs = prop.GetCustomAttributes(true);

						foreach (object attr in attrs)
						{
							if (attr is ColumnsAttribute attriField)
							{
								/*
								* 編輯作者：ADD BY CALVIN AT 2023/01/05
								* 說明：取得資料庫原始欄位值
								*/
								var fieldTypeName = attriField.TypeName.ToString();
								StringBuilder sb = new StringBuilder();
								foreach (DataTypeCollection enumType in Enum.GetValues(typeof(DataTypeCollection)))
								{
									//var enumText = GetExtensionHelper.RoleItemPlace(enumType);
									var fieldValues = item.GetType().GetProperty(attriField.Name)
														.GetValue(item, null).ToString().Trim() ?? "";

									DataTypeCollection op = new DataTypeCollection();
									var result = MappingDataType(fieldValues, op);
									sb.Append(result);
									break;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				_baselogger?.LogError(ex, NLogHelper.FetchCompleteMessage());
			}

			return "";
		}
		/// <summary>
		/// Mappings the type of the data.
		/// </summary>
		/// <param name="fieldValues">The field values.</param>
		/// <param name="op">The op.</param>
		/// <returns></returns>
		public string MappingDataType(string fieldValues, DataTypeCollection op) =>
		op switch
		{
			DataTypeCollection.BigIntType =>
				fieldValues.ParseTo<BigInteger>().ToString() ?? "",
			DataTypeCollection.DecimalType =>
				fieldValues.ParseTo<Decimal>().ToString() ?? "",
			DataTypeCollection.DateTimeType =>
				fieldValues.ParseTo<DateTime>().ToString() ?? "",
			_ => throw new Exception("發生未知錯誤")
		};
	}
}
