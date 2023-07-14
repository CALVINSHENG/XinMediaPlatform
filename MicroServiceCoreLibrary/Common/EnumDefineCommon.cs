using System.ComponentModel;

namespace MicroServiceCoreLibrary.Common
{
    #region SonarLint Disabled 放置區域
#pragma warning disable IDE0079
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //訊息 IDE0079 移除非必要的隱藏項目 MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Common\EnumDefineCommon.cs	14	作用中
#pragma warning disable VSSpell001 // Spell Check
    #endregion

    public enum ConditionForCommon
    {

        /*
		* 編輯作者：Modify BY CALVIN AT 2023/03/30
		* 說　　明：調整過濾器的欄位位置
		* 備　　註：
		* 引　　用：
		* ░░░░░░░░░░░░░░░░░░░░░░░░░░░
		* 修改歷程：
		* 2023/03/30 初版
		*/
        /// <summary>
        /// The is less than
        /// </summary>
        is_less_than,
        /// <summary>
        /// The is less than or equal to
        /// </summary>
        is_less_than_or_equal_to,
        /// <summary>
        /// The is great than
        /// </summary>
        is_great_than,
        /// <summary>
        /// The is great than or equal to
        /// </summary>
        is_great_than_or_equal_to,
    }

    public enum ConditionForDateType
    {
        /// <summary>
        /// The between/
        /// </summary>
        between,
        /// <summary>
        /// The before
        /// </summary>
        before,
        /// <summary>
        /// The after
        /// </summary>
        after,
    }

    public enum ConditionForStringType
    {
        /// <summary>
        /// LIKE
        /// </summary>
        like,
        /// <summary>
        /// equal
        /// </summary>
        equal,
    }
    /*░░░░░░░░░░░░░░░░░░░░░░░░░░░*/

    /// <summary>
    /// 公共定義區
    /// </summary>
    public static class EnumDefineCommon
    {
        /// <summary>
        /// 使用加密或是解密
        /// </summary>
        public enum SecurityType
        {
            /// <summary>
            /// 執行加密程序
            /// </summary>
            EnCryiption,
            /// <summary>
            /// 執行解密程序
            /// </summary>
            DeCryiption
        }

        /// <summary>
        /// SQLBULK設定
        /// </summary>
        public enum SQlBulkSetting
        {
            /// <summary>
            /// 批量筆數
            /// </summary>
            BatchSize = 1000000,
            /// <summary>
            /// 逾時秒數
            /// </summary>
            TimeOutSecond = 10
        }

        /// <summary>
        /// 執行預存程序的方式
        /// </summary>
        public enum ExecuteStoreProcedueType
        {
            /*░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
			* 編輯作者：REMARK BY CALVIN
			* 說明：資料處理程序
			* 備註：
			* ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
			*/
            /// <summary>
            /// The via query
            /// </summary>
            ViaQuery,
            /// <summary>
            /// The via execute reader
            /// </summary>
            ViaExecuteReader,
        }

        public enum ConfigTargetType
        {
            /// <summary>
            /// The specific directory
            /// </summary>
            CustomDefinition,
            /// <summary>
            /// The project default directory
            /// </summary>
            ServiceDefault,
            /// <summary>
            /// The global
            /// </summary>
            Global
        }

        /// <summary>
        /// 產生SQL語法的動作對應
        /// </summary>
        public enum SqlOperatorDateType
        {
            /// <summary>
            /// The create
            /// </summary>
            CREATE,
            /// <summary>
            /// The read
            /// </summary>
            READ,
            /// <summary>
            /// The update
            /// </summary>
            UPDATE,
            /// <summary>
            /// The delete
            /// </summary>
            DELETE
        }

		public enum PrepositionMapping
		{
			/// <summary>
			/// USER_NO：使用者編號
			/// </summary>
			[Description("USR")] ACCOUNT,
			/// <summary>
			/// GROUP_NO：群組代號
			/// </summary>
			[Description("GUP")] GROUP,
			/// <summary>
			/// MENU_NO：選單編號
			/// </summary>
			[Description("MNU")] MENU,
			/// <summary>
			/// BUTTON_NO：按鈕編號
			/// </summary>
			[Description("BTN")] BUTTON,
			/// <summary>
			/// DRIVER_NO：駕駛編號
			/// </summary>
			[Description("DRV")] DRIVER,
			/// <summary>
			/// DRV_SCHEDULE_NO：駕駛排班號
			/// </summary>
			[Description("DSD")] DRIVER_SCHEDULE,
			/// <summary>
			/// BUS_NO：車輛編號
			/// </summary>
			[Description("BUS")] BUS,
			/// <summary>
			/// VENDOR_NO：供應商編號
			/// </summary>
			[Description("VDR")] VENDOR,
			/// <summary>
			/// CUSTOMER_NO：客戶編號
			/// </summary>
			[Description("CTM")] CUSTOMER,
			/// <summary>
			/// COMMON_LABEL：標籤
			/// </summary>
			[Description("LAB")] COMMON_LABEL,
			/// <summary>
			/// REMINDERS : 通知
			/// </summary>
			[Description("RMD")] REMINDERS,
			/// <summary>
			/// bus_assignment：派車
			/// </summary>
			[Description("BAM")] BUS_ASSIGNMENT,
			/// <summary>
			/// driver_assignment：派工
			/// </summary>
			[Description("DAM")] DRIVER_ASSIGNMENT,
			/// <summary>
			/// MAINTENANCE：維保
			/// </summary>
			[Description("MTC")] MAINTENANCE,    
            /// <summary>
            /// QUOTE_NO：詢價單號
            /// </summary>
            [Description("ORD")] QUOTE,
            /// <summary>
            /// COSTS_NO：報價單號
            /// </summary>
            [Description("CST")] COSTS
        }

        /// <summary>
        /// 資料格式
        /// </summary>
        public enum DataTypeCollection
        {
            /*
			* 編輯作者：REMARK BY CALVIN AT 2023/03/25
			* 說明：Exact Numerics
			* 備註：精確數字
			*/
            /// <summary>
            /// 
            /// </summary>
            [Description("bigint")] BigIntType,
            /// <summary>
            /// The decimal type
            /// </summary>
            [Description("decimal")] DecimalType,
            /// <summary>
            /// The date time type
            /// </summary>
            [Description("datetime")] DateTimeType,
        }

        /// <summary>
        ///  編輯作者：REMARK BY CALVIN AT 2023/04/06
        ///  說明：列舉對應
        ///  備註：列舉字串連結字元不能是"-"
        ///			所以需進行"_"取代"-"流程作業
        /// </summary>
        public enum CodingMembers
        {
            //盛鉦凱
            //本機
            //[Description("Data Source=ITTC-04509-0088; Initial Catalog=ELDPLAT; User ID=sa;Password=!qaz#EDCLionTravel789")]
            //測試機
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0088,
            //江柏宏
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0041,
            //呂軒宇
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0033,
            //盧珈潁
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0090,
            //姜昱光
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0055,
            //邱上庭
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0096,
            //魏傳駿
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0043,
            //張家馨
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0095,
            //倪楷翔
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0074,
            //鍾佳哲
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0032,
            //張元豪
            [Description("Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP")]
            ITTC_04509_0050
        }
    }
}
