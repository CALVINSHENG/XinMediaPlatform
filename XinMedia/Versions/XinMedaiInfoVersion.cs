#region SonarLint Disabled 放置區域
#pragma warning disable IDE1006 // 命名樣式
#pragma warning disable VSSpell001 // Spell Check
#endregion

namespace XinMediaService.Versions
{
    /// <summary>
    /// 登入者驗證授權微服務新增功能版號
    /// 
    /// 重要：
    /// 要配合Select a definition
    /// 下拉選單的版本功能配號
    /// </summary>
    public class XinMedaiInfoVersion
    {
        /// <summary>
        /// Gets or sets the v1.
        /// 前台SWAGGER
        /// </summary>
        /// <value>
        /// The v1.
        /// </value>
        public string? v1 { get; set; }
        /// <summary>
        /// Gets or sets the v2.
        /// 後台SWAGGER
        /// </summary>
        /// <value>
        /// The v2.
        /// </value>
        public string? v2 { get; set; }
    }

    /// <summary>
    /// Swagger方法衝突命名
    /// </summary>
    public static class ConflictNaming
    {
        /// <summary>
        /// Naming
        /// </summary>
        public static string? X { get; set; } = "api/GetBusResult";
    }
}

