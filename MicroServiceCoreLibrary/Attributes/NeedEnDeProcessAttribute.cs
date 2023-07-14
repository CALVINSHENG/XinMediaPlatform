namespace MicroServiceCoreLibrary.Attributes
{
    #region SonarLint Disabled 放置區域
#pragma warning disable CS8618
    //警告 CS8618  退出建構函式時，不可為 Null 的 屬性 'displayType' 必須包含非 Null 值。請考慮將 屬性 宣告為可為 Null。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Attributes\NeedEnDeProcessAttribute.cs	44	作用中
    #endregion

    /// <summary>
    /// 屬性值定義操作
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    /// <summary>
    /// 加解密操作
    /// </summary>
    public sealed class NeedEnDecriptAttribute : Attribute
    {
        public string? FieldName { get; set; }
        public bool EnDeSignal { get; set; }
    }
    /// <summary>
    /// Filter過濾器操作
    /// </summary>
    public sealed class ColumnsAttribute : Attribute
    {
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public bool IsCondition { get; set; }
        //Filter 呈現形式
        public string displayType { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageBrief { get; set; }
    }

    /// <summary>
    /// 資料表SQL語法操作
    /// </summary>
    public sealed class ColumnsSqlStatementAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string? TypeName { get; set; }
    }
    /// <summary>
    /// 資料表參數值操作
    /// </summary>
    public sealed class ColumnsParametersAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is optional.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is optional; otherwise, <c>false</c>.
        /// </value>
        public bool IsOptional { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [need default].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [need default]; otherwise, <c>false</c>.
        /// </value>
        public bool NeedDefault { get; set; }
        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string? TypeName { get; set; }
    }
    /// <summary>
    /// 欄位長度操作
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public sealed class MaxLengthAttribute : Attribute
    {
        /// <summary>The _alias.</summary>
        private readonly int _return;

        /// <summary>Gets the alias.</summary>
        public int FeedBack
        {
            get
            {
                return _return;
            }
        }
        /// <summary>Initializes a new instance of the <see cref="MaxLengthAttribute"/> class.</summary>
        /// <param name="alias">The alias.</param>
        public MaxLengthAttribute(int alias)
        {
            _return = alias;
        }
    }
    /// <summary>
    /// 多國語系
    /// </summary>
    /// <seealso cref="System.Attribute" />
    public sealed class ColumnsLanguageAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string? TypeName { get; set; }
        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        public string? DefaultValue { get; set; }

    }
}
