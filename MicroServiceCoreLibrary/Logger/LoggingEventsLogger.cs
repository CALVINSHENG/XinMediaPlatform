namespace MicroServiceCoreLibrary.Logger
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S1118 // Utility classes should not have public constructors
    #endregion

    public partial class LoggingEventsLogger
    {
        /// <summary>
        /// 異動查詢
        /// </summary>
        public const int CreateAction = 1000;
        public const int EditAction = 1001;
        public const int GetAction = 1002;
        public const int DeleteAction = 1003;

        /// <summary>
        /// 錯誤類型
        /// </summary>
        public const int DBWarning = 1004;
        public const int DBWarning2 = 1005;
        public const int DBWarning3 = 1006;
        public const int DBWarning4 = 1007;
    }
}