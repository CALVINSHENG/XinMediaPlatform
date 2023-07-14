//這 assembly指令使指定程序集可用於您的模板代碼
//其方式與 Visual Studio 項目的引用部分相同。
//您不需要包含對 System.dll 的引用，它會自動引用。 
//這 import指令允許您使用類型而不使用它們的完全限定名稱，
//方式與 using普通程序文件中的指令。

// 直接引入命名空間T4會視為有效套件
// 這部分的引入是給成為有效物件時使用
// 檢視 .cs 文件如果有發生錯誤，VS也會提示

#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable IDE1006 // 命名樣式
#pragma warning disable S101 // Types should be named in PascalCase
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
#endregion

using Dapper.Contrib.Extensions;
using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreResposity.Entity;
using System;
using System.ComponentModel;

namespace MicroServiceCoreResposity.DbAccess.T4_Design_Time
{
    /// <summary>
    /// 資料檢核
    /// ① 資料筆數檢核
    /// ② 欄位數量檢核
    /// ①②		檢核多語系資料模型類別
    /// ②		檢核Model、列舉...etc模型類別
    /// </summary>
    public static class DataCheck_TTemplateExample
    {
        ///<summary>
        /// 資料表筆數
        ///</summary>
        public const int DataCount_TTemplateExample = 54;
        ///<summary>
        /// 資料表欄位數
        ///</summary>
        public const int FieldCount_TTemplateExample = 25;
        ///<summary>
        /// 註解有(false)無(true)填寫
        ///</summary>
        public const bool LackSummary_TTemplateExample = false;
    }
    /// <summary>
    /// 📒資料模型說明：這是TTemplateExample的功能說明
    /// 📒資料模型名稱：TTemplateExample
    /// </summary>
    [Table("'quotation'")]
    public class TTemplateExample
    {
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column no
        ///📝欄位簡述：序號
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：NO
        ///</summary>
        [Columns(Name = "no", TypeName = "int")]
        public int no { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///🔑為索引鍵
        ///📝英文說明：Gets or Sets The Column quote_no
        ///📝欄位簡述：詢價號碼,例: ORD202302020001
        ///📝欄位型態：varchar(15)　🔖預設值：　🔖是否允許空值：NO
        ///</summary>
        [Key]
        [Columns(Name = "quote_no", TypeName = "varchar")]
        [MaxLength(15)]
        public string quote_no { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column customer_no
        ///📝欄位簡述：客戶號碼
        ///📝欄位型態：varchar(15)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "customer_no", TypeName = "varchar")]
        [MaxLength(15)]
        public string? customer_no { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column company_no
        ///📝欄位簡述：車公司編號
        ///📝欄位型態：varchar(20)　🔖預設值：　🔖是否允許空值：NO
        ///</summary>
        [Columns(Name = "company_no", TypeName = "varchar")]
        [MaxLength(20)]
        public string company_no { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column quote_type
        ///📝欄位簡述：服務種類,1: 客製包車 2: 機場接送
        ///📝欄位型態：varchar(1)　🔖預設值：　🔖是否允許空值：NO
        ///</summary>
        [Columns(Name = "quote_type", TypeName = "varchar")]
        [MaxLength(1)]
        public string quote_type { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column departure_date
        ///📝欄位簡述：出發日期,日期
        ///📝欄位型態：date　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "departure_date", TypeName = "date")]
        public DateTime? departure_date { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column return_date
        ///📝欄位簡述：回程日期,日期
        ///📝欄位型態：date　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "return_date", TypeName = "date")]
        public DateTime? return_date { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column purpose
        ///📝欄位簡述：訂車用途,例: 下拉代號"01"
        ///📝欄位型態：varchar(2)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "purpose", TypeName = "varchar")]
        [MaxLength(2)]
        public string? purpose { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column pickup_date
        ///📝欄位簡述：接送日期,日期時間
        ///📝欄位型態：date　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "pickup_date", TypeName = "date")]
        public DateTime? pickup_date { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column dropoff_time
        ///📝欄位簡述：接送時間,日期時間
        ///📝欄位型態：nvarchar(10)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "dropoff_time", TypeName = "nvarchar")]
        [MaxLength(10)]
        public string? dropoff_time { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column flight_date
        ///📝欄位簡述：航班日期,日期
        ///📝欄位型態：date　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "flight_date", TypeName = "date")]
        public DateTime? flight_date { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column flight_number
        ///📝欄位簡述：航班編號,例: CI680 (航班編號)
        ///📝欄位型態：varchar(10)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "flight_number", TypeName = "varchar")]
        [MaxLength(10)]
        public string? flight_number { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column airport
        ///📝欄位簡述：機場名稱,
        ///📝欄位型態：nvarchar(20)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "airport", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string? airport { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column terminal
        ///📝欄位簡述：航廈,
        ///📝欄位型態：nvarchar(20)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "terminal", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string? terminal { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column flight_departure_time
        ///📝欄位簡述：航班出發時間,日期時間
        ///📝欄位型態：nvarchar(10)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "flight_departure_time", TypeName = "nvarchar")]
        [MaxLength(10)]
        public string? flight_departure_time { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column airline
        ///📝欄位簡述：航空公司,
        ///📝欄位型態：nvarchar(20)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "airline", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string? airline { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column adult
        ///📝欄位簡述：成人,數字
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "adult", TypeName = "int")]
        public int? adult { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column child
        ///📝欄位簡述：兒童,數字
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "child", TypeName = "int")]
        public int? child { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column infant
        ///📝欄位簡述：嬰兒,數字
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "infant", TypeName = "int")]
        public int? infant { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column check_in_luggage
        ///📝欄位簡述：托運行李,數字
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "check_in_luggage", TypeName = "int")]
        public int? check_in_luggage { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column carry_on_luggage
        ///📝欄位簡述：手提行李,數字
        ///📝欄位型態：int　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "carry_on_luggage", TypeName = "int")]
        public int? carry_on_luggage { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column creid
        ///📝欄位簡述：新增人員,放入 user_no (使用者編號)
        ///📝欄位型態：varchar(15)　🔖預設值：　🔖是否允許空值：NO
        ///</summary>
        [Columns(Name = "creid", TypeName = "varchar")]
        [MaxLength(15)]
        public string creid { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column credate
        ///📝欄位簡述：新增時間,current_timestamp()
        ///📝欄位型態：datetime　🔖預設值：(getdate())　🔖是否允許空值：NO
        ///</summary>
        [Columns(Name = "credate", TypeName = "datetime")]
        public DateTime credate { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column updid
        ///📝欄位簡述：修改人員,放入 user_no (使用者編號)
        ///📝欄位型態：varchar(15)　🔖預設值：　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "updid", TypeName = "varchar")]
        [MaxLength(15)]
        public string? updid { get; set; }
        ///<summary>
        ///📖資料欄位資訊　
        ///📝英文說明：Gets or Sets The Column upddate
        ///📝欄位簡述：修改時間,current_timestamp()
        ///📝欄位型態：datetime　🔖預設值：(getdate())　🔖是否允許空值：YES
        ///</summary>
        [Columns(Name = "upddate", TypeName = "datetime")]
        public DateTime? upddate { get; set; }
    }
}

