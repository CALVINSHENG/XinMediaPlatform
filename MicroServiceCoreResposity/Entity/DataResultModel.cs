#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
#pragma warning disable IDE0044 // 新增唯讀修飾元
#pragma warning disable IDE0051 // 刪除未使用的私用成員

#endregion

namespace MicroServiceCoreResposity.Entity
{
    /// <summary>
    /// 回傳結果-List<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResultModel<T>
    {
        /// <summary>
        ///  🔖狀態碼
        /// </summary>
        public string StatusCode { get; set; } = "200";

        /// <summary>
        ///  🔖錯誤訊息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        ///  🔖資料
        /// </summary>
        public IEnumerable<T> DataList { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        ///  🔖回傳前端 true / false 訊息
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///  🔖回傳前端字串訊息
        /// 前端工程師檢視錯誤訊息
        /// </summary>
        public string? ResultString { get; set; }

        /// <summary>
        ///  🔖回傳前端整數訊息
        /// </summary>
        public int ResultInt { get; set; }
    }

    /// <summary>
    /// 回傳結果
    /// </summary>
    public class DataResultModel
    {
        /// <summary>
        ///  🔖Gets or sets the status code.
        ///  🔖狀態碼
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public string StatusCode { get; set; } = "200";

        /// <summary>
        ///  🔖回傳訊息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        ///  🔖是否成功
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///  🔖回傳前端字串訊息
        /// 前端工程師檢視錯誤訊息
        /// </summary>
        public string? ResultString { get; set; }

        /// <summary>
        ///  🔖回傳前端整數訊息
        /// </summary>
        public int? ResultInt { get; set; }
    }

    public class DataResultObjectModel
    {
        /// <summary>
        ///  🔖狀態碼
        /// </summary>
        public string StatusCode { get; set; } = "200";

        /// <summary>
        ///  🔖回傳訊息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        ///  🔖是否成功
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///  🔖回傳前端資料
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        ///  🔖回傳前端字串訊息
        /// 前端工程師檢視錯誤訊息
        /// </summary>
        public string ResultString { get; set; } = string.Empty;

        /// <summary>
        ///  🔖回傳前端整數訊息
        /// </summary>
        public int ResultInt { get; set; } = -1;
    }
}
