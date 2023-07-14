///這 assembly指令使指定程序集可用於您的模板代碼
///其方式與 Visual Studio 項目的引用部分相同。
///您不需要包含對 System.dll 的引用，它會自動引用。 
///這 import指令允許您使用類型而不使用它們的完全限定名稱，
///方式與 using普通程序文件中的指令。


/// 直接引入命名空間T4會視為有效套件
/// 這部分的引入是給成為有效物件時使用
/// 檢視 .cs 文件如果有發生錯誤，VS也會提示
using MicroServiceCoreLibrary.Attributes;
using System;
using System.ComponentModel;
namespace MicroServiceCoreResposity.DbAccess.T4_Design_Time
{
	// Disable the warning.
#pragma warning disable S101
	//警告	S101 Rename class 'LanguageCultureT4' 
	//to match pascal case naming rules, 
	//consider using 'LanguageCultureT4'.	MicroServiceCoreLibrary

	//
	// Code that uses obsolete API.
	// ...

	// Re-enable the warning.
	//#pragma warning restore SYSLIB0021

	/// <summary>
	/// 訊息代碼資料表資訊
	/// 針對資料、以及欄位檢核
	/// </summary>
	public static class LanguageCultureT4DataCount
	{	/// <summary>
		/// 資料總筆數
		/// </summary>
		public const int DataCountForDataCheck = 262;
    
public const int FieldCountForDataCheck = 6;
    
public const bool LackSummaryForDataCheck = false;
	}
	/// <summary>
	/// 訊息代碼簡述<br/>
	/// 可以VendorLangModelTtFile.[代碼]時檢視
	/// </summary>
	///public class VendorLanguageCode
	public class VendorLanguageCode
	{
		///<summary>
/// 名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_1^array^vendor^名稱^Name")]
 public string vendorTitle_array_1 {get; set;} = "vendorTitle_1^array^vendor^名稱^Name";
    ///<summary>
/// 區域
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_2^array^vendor^區域^City")]
 public string vendorTitle_array_2 {get; set;} = "vendorTitle_2^array^vendor^區域^City";
    ///<summary>
/// 電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_3^array^vendor^電話^Phone")]
 public string vendorTitle_array_3 {get; set;} = "vendorTitle_3^array^vendor^電話^Phone";
    ///<summary>
/// 網站
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_4^array^vendor^網站^Website")]
 public string vendorTitle_array_4 {get; set;} = "vendorTitle_4^array^vendor^網站^Website";
    ///<summary>
/// 聯絡人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_5^array^vendor^聯絡人^Contact Person")]
 public string vendorTitle_array_5 {get; set;} = "vendorTitle_5^array^vendor^聯絡人^Contact Person";
    ///<summary>
/// 聯絡信箱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_6^array^vendor^聯絡信箱^Email")]
 public string vendorTitle_array_6 {get; set;} = "vendorTitle_6^array^vendor^聯絡信箱^Email";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendorTitle", TypeName = "array", DefaultValue = "vendorTitle^vendorTitle_7^array^vendor^標籤^Tags")]
 public string vendorTitle_array_7 {get; set;} = "vendorTitle_7^array^vendor^標籤^Tags";
    ///<summary>
/// 供應商
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "tableName_vendor", TypeName = "value", DefaultValue = "tableName_vendor^tableName_vendor_1^value^vendor^供應商^Vendor")]
 public string tableName_vendor_value_1 {get; set;} = "tableName_vendor_1^value^vendor^供應商^Vendor";
    ///<summary>
/// 列表
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "tableList", TypeName = "value", DefaultValue = "tableList^tableList_1^value^vendor^列表^List")]
 public string tableList_value_1 {get; set;} = "tableList_1^value^vendor^列表^List";
    ///<summary>
/// 操作
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "action", TypeName = "value", DefaultValue = "action^action_1^value^vendor^操作^Action")]
 public string action_value_1 {get; set;} = "action_1^value^vendor^操作^Action";
    ///<summary>
/// 新增
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "addText", TypeName = "value", DefaultValue = "addText^addText_1^value^vendor^新增^Add")]
 public string addText_value_1 {get; set;} = "addText_1^value^vendor^新增^Add";
    ///<summary>
/// 名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_name", TypeName = "value", DefaultValue = "vendor_name^vendor_name_1^value^vendor^名稱^Vendor Name")]
 public string vendor_name_value_1 {get; set;} = "vendor_name_1^value^vendor^名稱^Vendor Name";
    ///<summary>
/// 電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_phone", TypeName = "value", DefaultValue = "vendor_phone^vendor_phone_1^value^vendor^電話^Vendor Phone")]
 public string vendor_phone_value_1 {get; set;} = "vendor_phone_1^value^vendor^電話^Vendor Phone";
    ///<summary>
/// 網站
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_website", TypeName = "value", DefaultValue = "vendor_website^vendor_website_1^value^vendor^網站^Website")]
 public string vendor_website_value_1 {get; set;} = "vendor_website_1^value^vendor^網站^Website";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_label", TypeName = "value", DefaultValue = "vendor_label^vendor_label_1^value^vendor^標籤^Tags")]
 public string vendor_label_value_1 {get; set;} = "vendor_label_1^value^vendor^標籤^Tags";
    ///<summary>
/// 地址
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_address", TypeName = "value", DefaultValue = "vendor_address^vendor_address_1^value^vendor^地址^Address")]
 public string vendor_address_value_1 {get; set;} = "vendor_address_1^value^vendor^地址^Address";
    ///<summary>
/// 街道地址、郵政信箱等
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_address_hint", TypeName = "value", DefaultValue = "vendor_address_hint^vendor_address_hint_1^value^vendor^街道地址、郵政信箱等^street name or the mail box")]
 public string vendor_address_hint_value_1 {get; set;} = "vendor_address_hint_1^value^vendor^街道地址、郵政信箱等^street name or the mail box";
    ///<summary>
/// 地址第二列
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_address2", TypeName = "value", DefaultValue = "vendor_address2^vendor_address2_1^value^vendor^地址第二列^Second Address")]
 public string vendor_address2_value_1 {get; set;} = "vendor_address2_1^value^vendor^地址第二列^Second Address";
    ///<summary>
/// 套房、建築、大樓、樓層等
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_address_hint2", TypeName = "value", DefaultValue = "vendor_address_hint2^vendor_address_hint2_1^value^vendor^套房、建築、大樓、樓層等^suite, building, floor, etc.")]
 public string vendor_address_hint2_value_1 {get; set;} = "vendor_address_hint2_1^value^vendor^套房、建築、大樓、樓層等^suite, building, floor, etc.";
    ///<summary>
/// 城市
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_city", TypeName = "value", DefaultValue = "vendor_city^vendor_city_1^value^vendor^城市^City")]
 public string vendor_city_value_1 {get; set;} = "vendor_city_1^value^vendor^城市^City";
    ///<summary>
/// 州/省/地區
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_state", TypeName = "value", DefaultValue = "vendor_state^vendor_state_1^value^vendor^州/省/地區^state/province/region")]
 public string vendor_state_value_1 {get; set;} = "vendor_state_1^value^vendor^州/省/地區^state/province/region";
    ///<summary>
/// 郵遞區號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_zip", TypeName = "value", DefaultValue = "vendor_zip^vendor_zip_1^value^vendor^郵遞區號^Zip code")]
 public string vendor_zip_value_1 {get; set;} = "vendor_zip_1^value^vendor^郵遞區號^Zip code";
    ///<summary>
/// 國家
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_country", TypeName = "value", DefaultValue = "vendor_country^vendor_country_1^value^vendor^國家^Country")]
 public string vendor_country_value_1 {get; set;} = "vendor_country_1^value^vendor^國家^Country";
    ///<summary>
/// 台灣
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_country_tw", TypeName = "value", DefaultValue = "vendor_country_tw^vendor_country_tw_1^value^vendor^台灣^Taiwan")]
 public string vendor_country_tw_value_1 {get; set;} = "vendor_country_tw_1^value^vendor^台灣^Taiwan";
    ///<summary>
/// 日本
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_country_jp", TypeName = "value", DefaultValue = "vendor_country_jp^vendor_country_jp_1^value^vendor^日本^Japan")]
 public string vendor_country_jp_value_1 {get; set;} = "vendor_country_jp_1^value^vendor^日本^Japan";
    ///<summary>
/// 美國
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_country_us", TypeName = "value", DefaultValue = "vendor_country_us^vendor_country_us_1^value^vendor^美國^America")]
 public string vendor_country_us_value_1 {get; set;} = "vendor_country_us_1^value^vendor^美國^America";
    ///<summary>
/// 聯絡人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_contact_title", TypeName = "value", DefaultValue = "vendor_contact_title^vendor_contact_title_1^value^vendor^聯絡人^Contact Person")]
 public string vendor_contact_title_value_1 {get; set;} = "vendor_contact_title_1^value^vendor^聯絡人^Contact Person";
    ///<summary>
/// 聯絡人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_contact_name", TypeName = "value", DefaultValue = "vendor_contact_name^vendor_contact_name_1^value^vendor^聯絡人^Contact Person")]
 public string vendor_contact_name_value_1 {get; set;} = "vendor_contact_name_1^value^vendor^聯絡人^Contact Person";
    ///<summary>
/// 電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_contact_phone", TypeName = "value", DefaultValue = "vendor_contact_phone^vendor_contact_phone_1^value^vendor^電話^Phone")]
 public string vendor_contact_phone_value_1 {get; set;} = "vendor_contact_phone_1^value^vendor^電話^Phone";
    ///<summary>
/// 聯絡人的專線或手機號碼
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_contact_phone_hint", TypeName = "value", DefaultValue = "vendor_contact_phone_hint^vendor_contact_phone_hint_1^value^vendor^聯絡人的專線或手機號碼^contact persons phone number")]
 public string vendor_contact_phone_hint_value_1 {get; set;} = "vendor_contact_phone_hint_1^value^vendor^聯絡人的專線或手機號碼^contact persons phone number";
    ///<summary>
/// 信箱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "vendor_contact_email", TypeName = "value", DefaultValue = "vendor_contact_email^vendor_contact_email_1^value^vendor^信箱^Email")]
 public string vendor_contact_email_value_1 {get; set;} = "vendor_contact_email_1^value^vendor^信箱^Email";
    ///<summary>
/// 分類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "categoryTitle", TypeName = "value", DefaultValue = "categoryTitle^categoryTitle_1^value^vendor^分類^Category")]
 public string categoryTitle_value_1 {get; set;} = "categoryTitle_1^value^vendor^分類^Category";
    ///<summary>
/// 車輛名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_1^array^bus^車輛名稱^Vehilce Name")]
 public string busTitle_array_1 {get; set;} = "busTitle_1^array^bus^車輛名稱^Vehilce Name";
    ///<summary>
/// 車種
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_2^array^bus^車種^Vehicle Type")]
 public string busTitle_array_2 {get; set;} = "busTitle_2^array^bus^車種^Vehicle Type";
    ///<summary>
/// 品牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_3^array^bus^品牌^Make")]
 public string busTitle_array_3 {get; set;} = "busTitle_3^array^bus^品牌^Make";
    ///<summary>
/// 車型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_4^array^bus^車型^Model")]
 public string busTitle_array_4 {get; set;} = "busTitle_4^array^bus^車型^Model";
    ///<summary>
/// 車牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_5^array^bus^車牌^License Plate")]
 public string busTitle_array_5 {get; set;} = "busTitle_5^array^bus^車牌^License Plate";
    ///<summary>
/// 車齡
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_6^array^bus^車齡^Vehicle Age")]
 public string busTitle_array_6 {get; set;} = "busTitle_6^array^bus^車齡^Vehicle Age";
    ///<summary>
/// 車輛群組
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_7^array^bus^車輛群組^Vehicle Group")]
 public string busTitle_array_7 {get; set;} = "busTitle_7^array^bus^車輛群組^Vehicle Group";
    ///<summary>
/// 主要駕駛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_8^array^bus^主要駕駛^Primary Driver")]
 public string busTitle_array_8 {get; set;} = "busTitle_8^array^bus^主要駕駛^Primary Driver";
    ///<summary>
/// 狀態
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_9^array^bus^狀態^Status")]
 public string busTitle_array_9 {get; set;} = "busTitle_9^array^bus^狀態^Status";
    ///<summary>
/// 所有權
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_10^array^bus^所有權^Ownership")]
 public string busTitle_array_10 {get; set;} = "busTitle_10^array^bus^所有權^Ownership";
    ///<summary>
/// 操作
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "busTitle", TypeName = "array", DefaultValue = "busTitle^busTitle_11^array^bus^操作^Action")]
 public string busTitle_array_11 {get; set;} = "busTitle_11^array^bus^操作^Action";
    ///<summary>
/// 車輛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus", TypeName = "value", DefaultValue = "bus^bus_1^value^bus^車輛^Vehicle")]
 public string bus_value_1 {get; set;} = "bus_1^value^bus^車輛^Vehicle";
    ///<summary>
/// 細項
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_bookmark_detail", TypeName = "value", DefaultValue = "bus_bookmark_detail^bus_bookmark_detail_1^value^bus^細項^Details")]
 public string bus_bookmark_detail_value_1 {get; set;} = "bus_bookmark_detail_1^value^bus^細項^Details";
    ///<summary>
/// 維保
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_bookmark_maintenance", TypeName = "value", DefaultValue = "bus_bookmark_maintenance^bus_bookmark_maintenance_1^value^bus^維保^Maintenance")]
 public string bus_bookmark_maintenance_value_1 {get; set;} = "bus_bookmark_maintenance_1^value^bus^維保^Maintenance";
    ///<summary>
/// 生命週期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_bookmark_lifecycle", TypeName = "value", DefaultValue = "bus_bookmark_lifecycle^bus_bookmark_lifecycle_1^value^bus^生命週期^Lifecylce")]
 public string bus_bookmark_lifecycle_value_1 {get; set;} = "bus_bookmark_lifecycle_1^value^bus^生命週期^Lifecylce";
    ///<summary>
/// 財務
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_bookmark_finance", TypeName = "value", DefaultValue = "bus_bookmark_finance^bus_bookmark_finance_1^value^bus^財務^Financial")]
 public string bus_bookmark_finance_value_1 {get; set;} = "bus_bookmark_finance_1^value^bus^財務^Financial";
    ///<summary>
/// 規格
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_bookmark_format", TypeName = "value", DefaultValue = "bus_bookmark_format^bus_bookmark_format_1^value^bus^規格^Specifications")]
 public string bus_bookmark_format_value_1 {get; set;} = "bus_bookmark_format_1^value^bus^規格^Specifications";
    ///<summary>
/// 車輛名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_name", TypeName = "value", DefaultValue = "bus_name^bus_name_1^value^bus^車輛名稱^Vehilce Name")]
 public string bus_name_value_1 {get; set;} = "bus_name_1^value^bus^車輛名稱^Vehilce Name";
    ///<summary>
/// 車輛識別碼VIN
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_vin", TypeName = "value", DefaultValue = "bus_vin^bus_vin_1^value^bus^車輛識別碼VIN^VIN/SN")]
 public string bus_vin_value_1 {get; set;} = "bus_vin_1^value^bus^車輛識別碼VIN^VIN/SN";
    ///<summary>
/// 車種
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_category", TypeName = "value", DefaultValue = "bus_category^bus_category_1^value^bus^車種^Vehicle Type")]
 public string bus_category_value_1 {get; set;} = "bus_category_1^value^bus^車種^Vehicle Type";
    ///<summary>
/// 座位數
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_seats", TypeName = "value", DefaultValue = "bus_seats^bus_seats_1^value^bus^座位數^Seating Capacity")]
 public string bus_seats_value_1 {get; set;} = "bus_seats_1^value^bus^座位數^Seating Capacity";
    ///<summary>
/// 品牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_brand", TypeName = "value", DefaultValue = "bus_brand^bus_brand_1^value^bus^品牌^Make")]
 public string bus_brand_value_1 {get; set;} = "bus_brand_1^value^bus^品牌^Make";
    ///<summary>
/// 車牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_plate", TypeName = "value", DefaultValue = "bus_plate^bus_plate_1^value^bus^車牌^License Plate")]
 public string bus_plate_value_1 {get; set;} = "bus_plate_1^value^bus^車牌^License Plate";
    ///<summary>
/// 出廠年份
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_publish_year", TypeName = "value", DefaultValue = "bus_publish_year^bus_publish_year_1^value^bus^出廠年份^Year")]
 public string bus_publish_year_value_1 {get; set;} = "bus_publish_year_1^value^bus^出廠年份^Year";
    ///<summary>
/// 車輛群組
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_group", TypeName = "value", DefaultValue = "bus_group^bus_group_1^value^bus^車輛群組^Vehicle Group")]
 public string bus_group_value_1 {get; set;} = "bus_group_1^value^bus^車輛群組^Vehicle Group";
    ///<summary>
/// 主要駕駛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_main_driver", TypeName = "value", DefaultValue = "bus_main_driver^bus_main_driver_1^value^bus^主要駕駛^Primary Driver")]
 public string bus_main_driver_value_1 {get; set;} = "bus_main_driver_1^value^bus^主要駕駛^Primary Driver";
    ///<summary>
/// 狀態
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_status", TypeName = "value", DefaultValue = "bus_status^bus_status_1^value^bus^狀態^Status")]
 public string bus_status_value_1 {get; set;} = "bus_status_1^value^bus^狀態^Status";
    ///<summary>
/// 所有權
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_ownership", TypeName = "value", DefaultValue = "bus_ownership^bus_ownership_1^value^bus^所有權^Ownership")]
 public string bus_ownership_value_1 {get; set;} = "bus_ownership_1^value^bus^所有權^Ownership";
    ///<summary>
/// 身分識別
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_title_identity", TypeName = "value", DefaultValue = "bus_detail_title_identity^bus_detail_title_identity_1^value^bus^身分識別^VIN/SN")]
 public string bus_detail_title_identity_value_1 {get; set;} = "bus_detail_title_identity_1^value^bus^身分識別^VIN/SN";
    ///<summary>
/// 車輛編號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_number", TypeName = "value", DefaultValue = "bus_detail_number^bus_detail_number_1^value^bus^車輛編號^Vehicle Number")]
 public string bus_detail_number_value_1 {get; set;} = "bus_detail_number_1^value^bus^車輛編號^Vehicle Number";
    ///<summary>
/// 車型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_type", TypeName = "value", DefaultValue = "bus_detail_type^bus_detail_type_1^value^bus^車型^Model")]
 public string bus_detail_type_value_1 {get; set;} = "bus_detail_type_1^value^bus^車型^Model";
    ///<summary>
/// 車齡
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_age", TypeName = "value", DefaultValue = "bus_detail_age^bus_detail_age_1^value^bus^車齡^Vehicle Age")]
 public string bus_detail_age_value_1 {get; set;} = "bus_detail_age_1^value^bus^車齡^Vehicle Age";
    ///<summary>
/// 配置
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_configuration", TypeName = "value", DefaultValue = "bus_detail_configuration^bus_detail_configuration_1^value^bus^配置^Trim")]
 public string bus_detail_configuration_value_1 {get; set;} = "bus_detail_configuration_1^value^bus^配置^Trim";
    ///<summary>
/// 註冊州/省
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_register_state", TypeName = "value", DefaultValue = "bus_detail_register_state^bus_detail_register_state_1^value^bus^註冊州/省^Registration State/Province")]
 public string bus_detail_register_state_value_1 {get; set;} = "bus_detail_register_state_1^value^bus^註冊州/省^Registration State/Province";
    ///<summary>
/// 分類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_title_category", TypeName = "value", DefaultValue = "bus_detail_title_category^bus_detail_title_category_1^value^bus^分類^Classification")]
 public string bus_detail_title_category_value_1 {get; set;} = "bus_detail_title_category_1^value^bus^分類^Classification";
    ///<summary>
/// 其他細項
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_title_detail", TypeName = "value", DefaultValue = "bus_detail_title_detail^bus_detail_title_detail_1^value^bus^其他細項^Additional Details")]
 public string bus_detail_title_detail_value_1 {get; set;} = "bus_detail_title_detail_1^value^bus^其他細項^Additional Details";
    ///<summary>
/// 顏色
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_color", TypeName = "value", DefaultValue = "bus_detail_color^bus_detail_color_1^value^bus^顏色^Color")]
 public string bus_detail_color_value_1 {get; set;} = "bus_detail_color_1^value^bus^顏色^Color";
    ///<summary>
/// 車身類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_body_type", TypeName = "value", DefaultValue = "bus_detail_body_type^bus_detail_body_type_1^value^bus^車身類型^Body Type")]
 public string bus_detail_body_type_value_1 {get; set;} = "bus_detail_body_type_1^value^bus^車身類型^Body Type";
    ///<summary>
/// 車身子類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_body_subtype", TypeName = "value", DefaultValue = "bus_detail_body_subtype^bus_detail_body_subtype_1^value^bus^車身子類型^Body Subtype")]
 public string bus_detail_body_subtype_value_1 {get; set;} = "bus_detail_body_subtype_1^value^bus^車身子類型^Body Subtype";
    ///<summary>
/// 建議零售價
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_cost", TypeName = "value", DefaultValue = "bus_detail_cost^bus_detail_cost_1^value^bus^建議零售價^MSRP")]
 public string bus_detail_cost_value_1 {get; set;} = "bus_detail_cost_1^value^bus^建議零售價^MSRP";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_title_tags", TypeName = "value", DefaultValue = "bus_detail_title_tags^bus_detail_title_tags_1^value^bus^標籤^Labels")]
 public string bus_detail_title_tags_value_1 {get; set;} = "bus_detail_title_tags_1^value^bus^標籤^Labels";
    ///<summary>
/// 關聯資產
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_detail_title_assets", TypeName = "value", DefaultValue = "bus_detail_title_assets^bus_detail_title_assets_1^value^bus^關聯資產^Linked Vehicles")]
 public string bus_detail_title_assets_value_1 {get; set;} = "bus_detail_title_assets_1^value^bus^關聯資產^Linked Vehicles";
    ///<summary>
/// 維保計畫
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_title_plan", TypeName = "value", DefaultValue = "bus_maintenance_title_plan^bus_maintenance_title_plan_1^value^bus^維保計畫^Maintenance Schedule")]
 public string bus_maintenance_title_plan_value_1 {get; set;} = "bus_maintenance_title_plan_1^value^bus^維保計畫^Maintenance Schedule";
    ///<summary>
/// 維保序號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_1^array^bus^維保序號^Maintenance Serial Number")]
 public string bus_maintenance_table_heads_array_1 {get; set;} = "bus_maintenance_table_heads_1^array^bus^維保序號^Maintenance Serial Number";
    ///<summary>
/// 日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_2^array^bus^日期^Completed")]
 public string bus_maintenance_table_heads_array_2 {get; set;} = "bus_maintenance_table_heads_2^array^bus^日期^Completed";
    ///<summary>
/// 里程數
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_3^array^bus^里程數^Meter")]
 public string bus_maintenance_table_heads_array_3 {get; set;} = "bus_maintenance_table_heads_3^array^bus^里程數^Meter";
    ///<summary>
/// 供應商
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_4^array^bus^供應商^Vendor")]
 public string bus_maintenance_table_heads_array_4 {get; set;} = "bus_maintenance_table_heads_4^array^bus^供應商^Vendor";
    ///<summary>
/// 類別
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_5^array^bus^類別^Service Tasks")]
 public string bus_maintenance_table_heads_array_5 {get; set;} = "bus_maintenance_table_heads_5^array^bus^類別^Service Tasks";
    ///<summary>
/// 項目
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_6^array^bus^項目^Service Program")]
 public string bus_maintenance_table_heads_array_6 {get; set;} = "bus_maintenance_table_heads_6^array^bus^項目^Service Program";
    ///<summary>
/// 派工單
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_maintenance_table_heads", TypeName = "array", DefaultValue = "bus_maintenance_table_heads^bus_maintenance_table_heads_7^array^bus^派工單^Work Orders")]
 public string bus_maintenance_table_heads_array_7 {get; set;} = "bus_maintenance_table_heads_7^array^bus^派工單^Work Orders";
    ///<summary>
/// 服務中
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_title_servicing", TypeName = "value", DefaultValue = "bus_lifecycle_title_servicing^bus_lifecycle_title_servicing_1^value^bus^服務中^In-Service")]
 public string bus_lifecycle_title_servicing_value_1 {get; set;} = "bus_lifecycle_title_servicing_1^value^bus^服務中^In-Service";
    ///<summary>
/// 服務日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_service_date", TypeName = "value", DefaultValue = "bus_lifecycle_service_date^bus_lifecycle_service_date_1^value^bus^服務日期^In-Service Date")]
 public string bus_lifecycle_service_date_value_1 {get; set;} = "bus_lifecycle_service_date_1^value^bus^服務日期^In-Service Date";
    ///<summary>
/// 服務里程數
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_service_milage", TypeName = "value", DefaultValue = "bus_lifecycle_service_milage^bus_lifecycle_service_milage_1^value^bus^服務里程數^In-Service Odometer")]
 public string bus_lifecycle_service_milage_value_1 {get; set;} = "bus_lifecycle_service_milage_1^value^bus^服務里程數^In-Service Odometer";
    ///<summary>
/// 車輛壽命估計
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_title_life_estimate", TypeName = "value", DefaultValue = "bus_lifecycle_title_life_estimate^bus_lifecycle_title_life_estimate_1^value^bus^車輛壽命估計^Vehicle Life Estimates")]
 public string bus_lifecycle_title_life_estimate_value_1 {get; set;} = "bus_lifecycle_title_life_estimate_1^value^bus^車輛壽命估計^Vehicle Life Estimates";
    ///<summary>
/// 估計使用壽命(月)
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_estimate_month", TypeName = "value", DefaultValue = "bus_lifecycle_estimate_month^bus_lifecycle_estimate_month_1^value^bus^估計使用壽命(月)^Estimated Service Life in Months")]
 public string bus_lifecycle_estimate_month_value_1 {get; set;} = "bus_lifecycle_estimate_month_1^value^bus^估計使用壽命(月)^Estimated Service Life in Months";
    ///<summary>
/// 估計使用壽命(里程)
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_estimate_milage", TypeName = "value", DefaultValue = "bus_lifecycle_estimate_milage^bus_lifecycle_estimate_milage_1^value^bus^估計使用壽命(里程)^Estimated Service Life in Meter")]
 public string bus_lifecycle_estimate_milage_value_1 {get; set;} = "bus_lifecycle_estimate_milage_1^value^bus^估計使用壽命(里程)^Estimated Service Life in Meter";
    ///<summary>
/// 估計轉售價值
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_estimate_value", TypeName = "value", DefaultValue = "bus_lifecycle_estimate_value^bus_lifecycle_estimate_value_1^value^bus^估計轉售價值^Estimated Resale Value")]
 public string bus_lifecycle_estimate_value_value_1 {get; set;} = "bus_lifecycle_estimate_value_1^value^bus^估計轉售價值^Estimated Resale Value";
    ///<summary>
/// 終止服務
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_title_serviced", TypeName = "value", DefaultValue = "bus_lifecycle_title_serviced^bus_lifecycle_title_serviced_1^value^bus^終止服務^Out-of-Service")]
 public string bus_lifecycle_title_serviced_value_1 {get; set;} = "bus_lifecycle_title_serviced_1^value^bus^終止服務^Out-of-Service";
    ///<summary>
/// 停用日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_stop_date", TypeName = "value", DefaultValue = "bus_lifecycle_stop_date^bus_lifecycle_stop_date_1^value^bus^停用日期^Out-of-Service Date")]
 public string bus_lifecycle_stop_date_value_1 {get; set;} = "bus_lifecycle_stop_date_1^value^bus^停用日期^Out-of-Service Date";
    ///<summary>
/// 停用里程表數值
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_lifecycle_stop_milage", TypeName = "value", DefaultValue = "bus_lifecycle_stop_milage^bus_lifecycle_stop_milage_1^value^bus^停用里程表數值^Out-of-Service Odometer")]
 public string bus_lifecycle_stop_milage_value_1 {get; set;} = "bus_lifecycle_stop_milage_1^value^bus^停用里程表數值^Out-of-Service Odometer";
    ///<summary>
/// 購買詳情
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_title_purchase_detail", TypeName = "value", DefaultValue = "bus_finance_title_purchase_detail^bus_finance_title_purchase_detail_1^value^bus^購買詳情^Purchase Details")]
 public string bus_finance_title_purchase_detail_value_1 {get; set;} = "bus_finance_title_purchase_detail_1^value^bus^購買詳情^Purchase Details";
    ///<summary>
/// 採購供應商
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_purchase_vendor", TypeName = "value", DefaultValue = "bus_finance_purchase_vendor^bus_finance_purchase_vendor_1^value^bus^採購供應商^Purchase Vendor")]
 public string bus_finance_purchase_vendor_value_1 {get; set;} = "bus_finance_purchase_vendor_1^value^bus^採購供應商^Purchase Vendor";
    ///<summary>
/// 購買日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_purchase_date", TypeName = "value", DefaultValue = "bus_finance_purchase_date^bus_finance_purchase_date_1^value^bus^購買日期^Purchase Date")]
 public string bus_finance_purchase_date_value_1 {get; set;} = "bus_finance_purchase_date_1^value^bus^購買日期^Purchase Date";
    ///<summary>
/// 購買價格
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_purchase_price", TypeName = "value", DefaultValue = "bus_finance_purchase_price^bus_finance_purchase_price_1^value^bus^購買價格^Purchase Price")]
 public string bus_finance_purchase_price_value_1 {get; set;} = "bus_finance_purchase_price_1^value^bus^購買價格^Purchase Price";
    ///<summary>
/// 里程表
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_purchase_milage", TypeName = "value", DefaultValue = "bus_finance_purchase_milage^bus_finance_purchase_milage_1^value^bus^里程表^Odometer")]
 public string bus_finance_purchase_milage_value_1 {get; set;} = "bus_finance_purchase_milage_1^value^bus^里程表^Odometer";
    ///<summary>
/// 備註
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_purchase_note", TypeName = "value", DefaultValue = "bus_finance_purchase_note^bus_finance_purchase_note_1^value^bus^備註^Notes")]
 public string bus_finance_purchase_note_value_1 {get; set;} = "bus_finance_purchase_note_1^value^bus^備註^Notes";
    ///<summary>
/// 保固
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_title_warranty", TypeName = "value", DefaultValue = "bus_finance_title_warranty^bus_finance_title_warranty_1^value^bus^保固^Warranty")]
 public string bus_finance_title_warranty_value_1 {get; set;} = "bus_finance_title_warranty_1^value^bus^保固^Warranty";
    ///<summary>
/// 截止日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_warranty_deadline", TypeName = "value", DefaultValue = "bus_finance_warranty_deadline^bus_finance_warranty_deadline_1^value^bus^截止日期^Expiration Date")]
 public string bus_finance_warranty_deadline_value_1 {get; set;} = "bus_finance_warranty_deadline_1^value^bus^截止日期^Expiration Date";
    ///<summary>
/// 最大里程數值
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_warranty_milage", TypeName = "value", DefaultValue = "bus_finance_warranty_milage^bus_finance_warranty_milage_1^value^bus^最大里程數值^Max Meter Value")]
 public string bus_finance_warranty_milage_value_1 {get; set;} = "bus_finance_warranty_milage_1^value^bus^最大里程數值^Max Meter Value";
    ///<summary>
/// 貸款/租賃
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_title_loan", TypeName = "value", DefaultValue = "bus_finance_title_loan^bus_finance_title_loan_1^value^bus^貸款/租賃^Loan/Lease")]
 public string bus_finance_title_loan_value_1 {get; set;} = "bus_finance_title_loan_1^value^bus^貸款/租賃^Loan/Lease";
    ///<summary>
/// 貸款方
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_loaner", TypeName = "value", DefaultValue = "bus_finance_loan_loaner^bus_finance_loan_loaner_1^value^bus^貸款方^Lender")]
 public string bus_finance_loan_loaner_value_1 {get; set;} = "bus_finance_loan_loaner_1^value^bus^貸款方^Lender";
    ///<summary>
/// 貸款日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_date", TypeName = "value", DefaultValue = "bus_finance_loan_date^bus_finance_loan_date_1^value^bus^貸款日期^Date of Loan")]
 public string bus_finance_loan_date_value_1 {get; set;} = "bus_finance_loan_date_1^value^bus^貸款日期^Date of Loan";
    ///<summary>
/// 貸款金額
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_price", TypeName = "value", DefaultValue = "bus_finance_loan_price^bus_finance_loan_price_1^value^bus^貸款金額^Amount of Loan")]
 public string bus_finance_loan_price_value_1 {get; set;} = "bus_finance_loan_price_1^value^bus^貸款金額^Amount of Loan";
    ///<summary>
/// 至今總支付金額
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_paid", TypeName = "value", DefaultValue = "bus_finance_loan_paid^bus_finance_loan_paid_1^value^bus^至今總支付金額^Paid to Date")]
 public string bus_finance_loan_paid_value_1 {get; set;} = "bus_finance_loan_paid_1^value^bus^至今總支付金額^Paid to Date";
    ///<summary>
/// 年度百分比率(APR)
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_percentage", TypeName = "value", DefaultValue = "bus_finance_loan_percentage^bus_finance_loan_percentage_1^value^bus^年度百分比率(APR)^Annual Percentage Rate")]
 public string bus_finance_loan_percentage_value_1 {get; set;} = "bus_finance_loan_percentage_1^value^bus^年度百分比率(APR)^Annual Percentage Rate";
    ///<summary>
/// 首期付款
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_first_price", TypeName = "value", DefaultValue = "bus_finance_loan_first_price^bus_finance_loan_first_price_1^value^bus^首期付款^Down Payment")]
 public string bus_finance_loan_first_price_value_1 {get; set;} = "bus_finance_loan_first_price_1^value^bus^首期付款^Down Payment";
    ///<summary>
/// 首次付款日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_first_date", TypeName = "value", DefaultValue = "bus_finance_loan_first_date^bus_finance_loan_first_date_1^value^bus^首次付款日期^First Payment Date")]
 public string bus_finance_loan_first_date_value_1 {get; set;} = "bus_finance_loan_first_date_1^value^bus^首次付款日期^First Payment Date";
    ///<summary>
/// 月付金額
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_month_pay", TypeName = "value", DefaultValue = "bus_finance_loan_month_pay^bus_finance_loan_month_pay_1^value^bus^月付金額^Monthly Payment")]
 public string bus_finance_loan_month_pay_value_1 {get; set;} = "bus_finance_loan_month_pay_1^value^bus^月付金額^Monthly Payment";
    ///<summary>
/// 付款次數
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_times", TypeName = "value", DefaultValue = "bus_finance_loan_times^bus_finance_loan_times_1^value^bus^付款次數^Number of Payments")]
 public string bus_finance_loan_times_value_1 {get; set;} = "bus_finance_loan_times_1^value^bus^付款次數^Number of Payments";
    ///<summary>
/// 貸款結束日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_end_date", TypeName = "value", DefaultValue = "bus_finance_loan_end_date^bus_finance_loan_end_date_1^value^bus^貸款結束日期^Loan End Date")]
 public string bus_finance_loan_end_date_value_1 {get; set;} = "bus_finance_loan_end_date_1^value^bus^貸款結束日期^Loan End Date";
    ///<summary>
/// 帳號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_account", TypeName = "value", DefaultValue = "bus_finance_loan_account^bus_finance_loan_account_1^value^bus^帳號^Account Number")]
 public string bus_finance_loan_account_value_1 {get; set;} = "bus_finance_loan_account_1^value^bus^帳號^Account Number";
    ///<summary>
/// 備註
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_note", TypeName = "value", DefaultValue = "bus_finance_loan_note^bus_finance_loan_note_1^value^bus^備註^Notes")]
 public string bus_finance_loan_note_value_1 {get; set;} = "bus_finance_loan_note_1^value^bus^備註^Notes";
    ///<summary>
/// 加入報表計算
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_finance_loan_report", TypeName = "value", DefaultValue = "bus_finance_loan_report^bus_finance_loan_report_1^value^bus^加入報表計算^Adding report calculations")]
 public string bus_finance_loan_report_value_1 {get; set;} = "bus_finance_loan_report_1^value^bus^加入報表計算^Adding report calculations";
    ///<summary>
/// 尺寸
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_size", TypeName = "value", DefaultValue = "bus_format_title_size^bus_format_title_size_1^value^bus^尺寸^Dimensions")]
 public string bus_format_title_size_value_1 {get; set;} = "bus_format_title_size_1^value^bus^尺寸^Dimensions";
    ///<summary>
/// 寬度
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_width", TypeName = "value", DefaultValue = "bus_format_size_width^bus_format_size_width_1^value^bus^寬度^Width")]
 public string bus_format_size_width_value_1 {get; set;} = "bus_format_size_width_1^value^bus^寬度^Width";
    ///<summary>
/// 高度
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_height", TypeName = "value", DefaultValue = "bus_format_size_height^bus_format_size_height_1^value^bus^高度^Height")]
 public string bus_format_size_height_value_1 {get; set;} = "bus_format_size_height_1^value^bus^高度^Height";
    ///<summary>
/// 長度
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_longth", TypeName = "value", DefaultValue = "bus_format_size_longth^bus_format_size_longth_1^value^bus^長度^Length")]
 public string bus_format_size_longth_value_1 {get; set;} = "bus_format_size_longth_1^value^bus^長度^Length";
    ///<summary>
/// 內部容積
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_volume_inside", TypeName = "value", DefaultValue = "bus_format_size_volume_inside^bus_format_size_volume_inside_1^value^bus^內部容積^Interior Volume")]
 public string bus_format_size_volume_inside_value_1 {get; set;} = "bus_format_size_volume_inside_1^value^bus^內部容積^Interior Volume";
    ///<summary>
/// 載客量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_volume_customer", TypeName = "value", DefaultValue = "bus_format_size_volume_customer^bus_format_size_volume_customer_1^value^bus^載客量^Passenger Volume")]
 public string bus_format_size_volume_customer_value_1 {get; set;} = "bus_format_size_volume_customer_1^value^bus^載客量^Passenger Volume";
    ///<summary>
/// 貨物量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_volume_cargo", TypeName = "value", DefaultValue = "bus_format_size_volume_cargo^bus_format_size_volume_cargo_1^value^bus^貨物量^Cargo Volume")]
 public string bus_format_size_volume_cargo_value_1 {get; set;} = "bus_format_size_volume_cargo_1^value^bus^貨物量^Cargo Volume";
    ///<summary>
/// 離地間隙
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_gap", TypeName = "value", DefaultValue = "bus_format_size_gap^bus_format_size_gap_1^value^bus^離地間隙^Ground Clearance")]
 public string bus_format_size_gap_value_1 {get; set;} = "bus_format_size_gap_1^value^bus^離地間隙^Ground Clearance";
    ///<summary>
/// 底盤長度
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_size_bottom_longth", TypeName = "value", DefaultValue = "bus_format_size_bottom_longth^bus_format_size_bottom_longth_1^value^bus^底盤長度^Bed Length")]
 public string bus_format_size_bottom_longth_value_1 {get; set;} = "bus_format_size_bottom_longth_1^value^bus^底盤長度^Bed Length";
    ///<summary>
/// 車輪 & 輪胎
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_tire", TypeName = "value", DefaultValue = "bus_format_title_tire^bus_format_title_tire_1^value^bus^車輪 & 輪胎^Wheels & Tires")]
 public string bus_format_title_tire_value_1 {get; set;} = "bus_format_title_tire_1^value^bus^車輪 & 輪胎^Wheels & Tires";
    ///<summary>
/// 驅動類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_drive_type", TypeName = "value", DefaultValue = "bus_format_tire_drive_type^bus_format_tire_drive_type_1^value^bus^驅動類型^Drive Type")]
 public string bus_format_tire_drive_type_value_1 {get; set;} = "bus_format_tire_drive_type_1^value^bus^驅動類型^Drive Type";
    ///<summary>
/// 煞車系統
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_brake_system", TypeName = "value", DefaultValue = "bus_format_tire_brake_system^bus_format_tire_brake_system_1^value^bus^煞車系統^Brake System")]
 public string bus_format_tire_brake_system_value_1 {get; set;} = "bus_format_tire_brake_system_1^value^bus^煞車系統^Brake System";
    ///<summary>
/// 前輪輪距
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_front_tire_gap", TypeName = "value", DefaultValue = "bus_format_tire_front_tire_gap^bus_format_tire_front_tire_gap_1^value^bus^前輪輪距^Front Track Width")]
 public string bus_format_tire_front_tire_gap_value_1 {get; set;} = "bus_format_tire_front_tire_gap_1^value^bus^前輪輪距^Front Track Width";
    ///<summary>
/// 後輪輪距
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_back_tire_gap", TypeName = "value", DefaultValue = "bus_format_tire_back_tire_gap^bus_format_tire_back_tire_gap_1^value^bus^後輪輪距^Rear Track Width")]
 public string bus_format_tire_back_tire_gap_value_1 {get; set;} = "bus_format_tire_back_tire_gap_1^value^bus^後輪輪距^Rear Track Width";
    ///<summary>
/// 軸距
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_wheelbase", TypeName = "value", DefaultValue = "bus_format_tire_wheelbase^bus_format_tire_wheelbase_1^value^bus^軸距^Wheelbase")]
 public string bus_format_tire_wheelbase_value_1 {get; set;} = "bus_format_tire_wheelbase_1^value^bus^軸距^Wheelbase";
    ///<summary>
/// 前輪直徑
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_front_diameter", TypeName = "value", DefaultValue = "bus_format_tire_front_diameter^bus_format_tire_front_diameter_1^value^bus^前輪直徑^Front Wheel Diameter")]
 public string bus_format_tire_front_diameter_value_1 {get; set;} = "bus_format_tire_front_diameter_1^value^bus^前輪直徑^Front Wheel Diameter";
    ///<summary>
/// 後輪直徑
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_back_diameter", TypeName = "value", DefaultValue = "bus_format_tire_back_diameter^bus_format_tire_back_diameter_1^value^bus^後輪直徑^Rear Wheel Diameter")]
 public string bus_format_tire_back_diameter_value_1 {get; set;} = "bus_format_tire_back_diameter_1^value^bus^後輪直徑^Rear Wheel Diameter";
    ///<summary>
/// 後軸
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_back_wheelbase", TypeName = "value", DefaultValue = "bus_format_tire_back_wheelbase^bus_format_tire_back_wheelbase_1^value^bus^後軸^Rear Axle")]
 public string bus_format_tire_back_wheelbase_value_1 {get; set;} = "bus_format_tire_back_wheelbase_1^value^bus^後軸^Rear Axle";
    ///<summary>
/// 前輪輪胎類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_front_type", TypeName = "value", DefaultValue = "bus_format_tire_front_type^bus_format_tire_front_type_1^value^bus^前輪輪胎類型^Front Tire Type")]
 public string bus_format_tire_front_type_value_1 {get; set;} = "bus_format_tire_front_type_1^value^bus^前輪輪胎類型^Front Tire Type";
    ///<summary>
/// 前胎胎壓大小
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_front_pressure", TypeName = "value", DefaultValue = "bus_format_tire_front_pressure^bus_format_tire_front_pressure_1^value^bus^前胎胎壓大小^Front Tire PSI")]
 public string bus_format_tire_front_pressure_value_1 {get; set;} = "bus_format_tire_front_pressure_1^value^bus^前胎胎壓大小^Front Tire PSI";
    ///<summary>
/// 後輪輪胎類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_back_type", TypeName = "value", DefaultValue = "bus_format_tire_back_type^bus_format_tire_back_type_1^value^bus^後輪輪胎類型^Rear Tire Type")]
 public string bus_format_tire_back_type_value_1 {get; set;} = "bus_format_tire_back_type_1^value^bus^後輪輪胎類型^Rear Tire Type";
    ///<summary>
/// 後胎胎壓大小
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_tire_back_pressure", TypeName = "value", DefaultValue = "bus_format_tire_back_pressure^bus_format_tire_back_pressure_1^value^bus^後胎胎壓大小^Rear Tire PSI")]
 public string bus_format_tire_back_pressure_value_1 {get; set;} = "bus_format_tire_back_pressure_1^value^bus^後胎胎壓大小^Rear Tire PSI";
    ///<summary>
/// 重量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_weight", TypeName = "value", DefaultValue = "bus_format_title_weight^bus_format_title_weight_1^value^bus^重量^Weight")]
 public string bus_format_title_weight_value_1 {get; set;} = "bus_format_title_weight_1^value^bus^重量^Weight";
    ///<summary>
/// 空車重量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_weight_empty", TypeName = "value", DefaultValue = "bus_format_weight_empty^bus_format_weight_empty_1^value^bus^空車重量^Curb Weight")]
 public string bus_format_weight_empty_value_1 {get; set;} = "bus_format_weight_empty_1^value^bus^空車重量^Curb Weight";
    ///<summary>
/// 車輛總重量等級
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_weight_level", TypeName = "value", DefaultValue = "bus_format_weight_level^bus_format_weight_level_1^value^bus^車輛總重量等級^Gross Vehicle Weight Rating")]
 public string bus_format_weight_level_value_1 {get; set;} = "bus_format_weight_level_1^value^bus^車輛總重量等級^Gross Vehicle Weight Rating";
    ///<summary>
/// 性能
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_performance", TypeName = "value", DefaultValue = "bus_format_title_performance^bus_format_title_performance_1^value^bus^性能^Performance")]
 public string bus_format_title_performance_value_1 {get; set;} = "bus_format_title_performance_1^value^bus^性能^Performance";
    ///<summary>
/// 牽引能力
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_performance_traction", TypeName = "value", DefaultValue = "bus_format_performance_traction^bus_format_performance_traction_1^value^bus^牽引能力^Towing Capacity")]
 public string bus_format_performance_traction_value_1 {get; set;} = "bus_format_performance_traction_1^value^bus^牽引能力^Towing Capacity";
    ///<summary>
/// 最大有效承載
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_performance_loading", TypeName = "value", DefaultValue = "bus_format_performance_loading^bus_format_performance_loading_1^value^bus^最大有效承載^Max Payload")]
 public string bus_format_performance_loading_value_1 {get; set;} = "bus_format_performance_loading_1^value^bus^最大有效承載^Max Payload";
    ///<summary>
/// 燃油經濟性 / 油耗表現
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_consumption", TypeName = "value", DefaultValue = "bus_format_title_consumption^bus_format_title_consumption_1^value^bus^燃油經濟性 / 油耗表現^Fuel Economy")]
 public string bus_format_title_consumption_value_1 {get; set;} = "bus_format_title_consumption_1^value^bus^燃油經濟性 / 油耗表現^Fuel Economy";
    ///<summary>
/// EPA城市燃油經濟性市區油耗表現
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_consumption_city", TypeName = "value", DefaultValue = "bus_format_consumption_city^bus_format_consumption_city_1^value^bus^EPA城市燃油經濟性市區油耗表現^EPA City")]
 public string bus_format_consumption_city_value_1 {get; set;} = "bus_format_consumption_city_1^value^bus^EPA城市燃油經濟性市區油耗表現^EPA City";
    ///<summary>
/// EPA高速公路燃油經濟性高速公路油耗表現
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_consumption_highway", TypeName = "value", DefaultValue = "bus_format_consumption_highway^bus_format_consumption_highway_1^value^bus^EPA高速公路燃油經濟性高速公路油耗表現^EPA Highway")]
 public string bus_format_consumption_highway_value_1 {get; set;} = "bus_format_consumption_highway_1^value^bus^EPA高速公路燃油經濟性高速公路油耗表現^EPA Highway";
    ///<summary>
/// EPA綜合燃油經濟性市區綜合油耗表現
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_consumption_all", TypeName = "value", DefaultValue = "bus_format_consumption_all^bus_format_consumption_all_1^value^bus^EPA綜合燃油經濟性市區綜合油耗表現^EPA Combined")]
 public string bus_format_consumption_all_value_1 {get; set;} = "bus_format_consumption_all_1^value^bus^EPA綜合燃油經濟性市區綜合油耗表現^EPA Combined";
    ///<summary>
/// 變速器
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_gearbox", TypeName = "value", DefaultValue = "bus_format_title_gearbox^bus_format_title_gearbox_1^value^bus^變速器^Transmission")]
 public string bus_format_title_gearbox_value_1 {get; set;} = "bus_format_title_gearbox_1^value^bus^變速器^Transmission";
    ///<summary>
/// 變速器摘要
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_gearbox_summary", TypeName = "value", DefaultValue = "bus_format_gearbox_summary^bus_format_gearbox_summary_1^value^bus^變速器摘要^Transmission Summary")]
 public string bus_format_gearbox_summary_value_1 {get; set;} = "bus_format_gearbox_summary_1^value^bus^變速器摘要^Transmission Summary";
    ///<summary>
/// 變速器品牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_gearbox_brand", TypeName = "value", DefaultValue = "bus_format_gearbox_brand^bus_format_gearbox_brand_1^value^bus^變速器品牌^Transmission Brand")]
 public string bus_format_gearbox_brand_value_1 {get; set;} = "bus_format_gearbox_brand_1^value^bus^變速器品牌^Transmission Brand";
    ///<summary>
/// 變速器類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_gearbox_type", TypeName = "value", DefaultValue = "bus_format_gearbox_type^bus_format_gearbox_type_1^value^bus^變速器類型^Transmission Type")]
 public string bus_format_gearbox_type_value_1 {get; set;} = "bus_format_gearbox_type_1^value^bus^變速器類型^Transmission Type";
    ///<summary>
/// 變速器檔位
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_gearbox_level", TypeName = "value", DefaultValue = "bus_format_gearbox_level^bus_format_gearbox_level_1^value^bus^變速器檔位^Transmission Gears")]
 public string bus_format_gearbox_level_value_1 {get; set;} = "bus_format_gearbox_level_1^value^bus^變速器檔位^Transmission Gears";
    ///<summary>
/// 機油
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_engine_oil", TypeName = "value", DefaultValue = "bus_format_title_engine_oil^bus_format_title_engine_oil_1^value^bus^機油^Oil")]
 public string bus_format_title_engine_oil_value_1 {get; set;} = "bus_format_title_engine_oil_1^value^bus^機油^Oil";
    ///<summary>
/// 機油容量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_oil_volume", TypeName = "value", DefaultValue = "bus_format_engine_oil_volume^bus_format_engine_oil_volume_1^value^bus^機油容量^Oil Capacity")]
 public string bus_format_engine_oil_volume_value_1 {get; set;} = "bus_format_engine_oil_volume_1^value^bus^機油容量^Oil Capacity";
    ///<summary>
/// 引擎
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_engine", TypeName = "value", DefaultValue = "bus_format_title_engine^bus_format_title_engine_1^value^bus^引擎^Engine")]
 public string bus_format_title_engine_value_1 {get; set;} = "bus_format_title_engine_1^value^bus^引擎^Engine";
    ///<summary>
/// 引擎摘要
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_summary", TypeName = "value", DefaultValue = "bus_format_engine_summary^bus_format_engine_summary_1^value^bus^引擎摘要^Engine Summary")]
 public string bus_format_engine_summary_value_1 {get; set;} = "bus_format_engine_summary_1^value^bus^引擎摘要^Engine Summary";
    ///<summary>
/// 引擎品牌
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_brand", TypeName = "value", DefaultValue = "bus_format_engine_brand^bus_format_engine_brand_1^value^bus^引擎品牌^Engine Brand")]
 public string bus_format_engine_brand_value_1 {get; set;} = "bus_format_engine_brand_1^value^bus^引擎品牌^Engine Brand";
    ///<summary>
/// 進氣系統
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_intake", TypeName = "value", DefaultValue = "bus_format_engine_intake^bus_format_engine_intake_1^value^bus^進氣系統^Aspiratio")]
 public string bus_format_engine_intake_value_1 {get; set;} = "bus_format_engine_intake_1^value^bus^進氣系統^Aspiratio";
    ///<summary>
/// 引擎缸體類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_cylinder_type", TypeName = "value", DefaultValue = "bus_format_engine_cylinder_type^bus_format_engine_cylinder_type_1^value^bus^引擎缸體類型^Block Type")]
 public string bus_format_engine_cylinder_type_value_1 {get; set;} = "bus_format_engine_cylinder_type_1^value^bus^引擎缸體類型^Block Type";
    ///<summary>
/// 汽缸孔徑
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_cylinder_diameter", TypeName = "value", DefaultValue = "bus_format_engine_cylinder_diameter^bus_format_engine_cylinder_diameter_1^value^bus^汽缸孔徑^Bore")]
 public string bus_format_engine_cylinder_diameter_value_1 {get; set;} = "bus_format_engine_cylinder_diameter_1^value^bus^汽缸孔徑^Bore";
    ///<summary>
/// 凸輪軸類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_camshaft_type", TypeName = "value", DefaultValue = "bus_format_engine_camshaft_type^bus_format_engine_camshaft_type_1^value^bus^凸輪軸類型^Cam Type")]
 public string bus_format_engine_camshaft_type_value_1 {get; set;} = "bus_format_engine_camshaft_type_1^value^bus^凸輪軸類型^Cam Type";
    ///<summary>
/// 壓縮比
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_pressure_ratio", TypeName = "value", DefaultValue = "bus_format_engine_pressure_ratio^bus_format_engine_pressure_ratio_1^value^bus^壓縮比^Compression")]
 public string bus_format_engine_pressure_ratio_value_1 {get; set;} = "bus_format_engine_pressure_ratio_1^value^bus^壓縮比^Compression";
    ///<summary>
/// 汽缸
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_cylinder", TypeName = "value", DefaultValue = "bus_format_engine_cylinder^bus_format_engine_cylinder_1^value^bus^汽缸^Cylinders")]
 public string bus_format_engine_cylinder_value_1 {get; set;} = "bus_format_engine_cylinder_1^value^bus^汽缸^Cylinders";
    ///<summary>
/// 排量大小
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_exhaust", TypeName = "value", DefaultValue = "bus_format_engine_exhaust^bus_format_engine_exhaust_1^value^bus^排量大小^Displacement")]
 public string bus_format_engine_exhaust_value_1 {get; set;} = "bus_format_engine_exhaust_1^value^bus^排量大小^Displacement";
    ///<summary>
/// 燃油進氣方式
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_sensor", TypeName = "value", DefaultValue = "bus_format_engine_sensor^bus_format_engine_sensor_1^value^bus^燃油進氣方式^Fuel Induction")]
 public string bus_format_engine_sensor_value_1 {get; set;} = "bus_format_engine_sensor_1^value^bus^燃油進氣方式^Fuel Induction";
    ///<summary>
/// 最大馬力
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_horsepower", TypeName = "value", DefaultValue = "bus_format_engine_horsepower^bus_format_engine_horsepower_1^value^bus^最大馬力^Max HP")]
 public string bus_format_engine_horsepower_value_1 {get; set;} = "bus_format_engine_horsepower_1^value^bus^最大馬力^Max HP";
    ///<summary>
/// 最大扭距
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_torque", TypeName = "value", DefaultValue = "bus_format_engine_torque^bus_format_engine_torque_1^value^bus^最大扭距^Max Torque")]
 public string bus_format_engine_torque_value_1 {get; set;} = "bus_format_engine_torque_1^value^bus^最大扭距^Max Torque";
    ///<summary>
/// 最大轉速
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_revolution", TypeName = "value", DefaultValue = "bus_format_engine_revolution^bus_format_engine_revolution_1^value^bus^最大轉速^Redline RPM")]
 public string bus_format_engine_revolution_value_1 {get; set;} = "bus_format_engine_revolution_1^value^bus^最大轉速^Redline RPM";
    ///<summary>
/// 衝程
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_stroke", TypeName = "value", DefaultValue = "bus_format_engine_stroke^bus_format_engine_stroke_1^value^bus^衝程^Stroke")]
 public string bus_format_engine_stroke_value_1 {get; set;} = "bus_format_engine_stroke_1^value^bus^衝程^Stroke";
    ///<summary>
/// 每缸氣門數量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_engine_valve", TypeName = "value", DefaultValue = "bus_format_engine_valve^bus_format_engine_valve_1^value^bus^每缸氣門數量^Valves")]
 public string bus_format_engine_valve_value_1 {get; set;} = "bus_format_engine_valve_1^value^bus^每缸氣門數量^Valves";
    ///<summary>
/// 燃料
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_title_fuel", TypeName = "value", DefaultValue = "bus_format_title_fuel^bus_format_title_fuel_1^value^bus^燃料^Fuel")]
 public string bus_format_title_fuel_value_1 {get; set;} = "bus_format_title_fuel_1^value^bus^燃料^Fuel";
    ///<summary>
/// 燃料類型
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_fuel_type", TypeName = "value", DefaultValue = "bus_format_fuel_type^bus_format_fuel_type_1^value^bus^燃料類型^Fuel Type")]
 public string bus_format_fuel_type_value_1 {get; set;} = "bus_format_fuel_type_1^value^bus^燃料類型^Fuel Type";
    ///<summary>
/// 汽油質量
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_fuel_mass", TypeName = "value", DefaultValue = "bus_format_fuel_mass^bus_format_fuel_mass_1^value^bus^汽油質量^Fuel Quality")]
 public string bus_format_fuel_mass_value_1 {get; set;} = "bus_format_fuel_mass_1^value^bus^汽油質量^Fuel Quality";
    ///<summary>
/// 油箱1容量大小
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_fuel_volume1", TypeName = "value", DefaultValue = "bus_format_fuel_volume1^bus_format_fuel_volume1_1^value^bus^油箱1容量大小^Fuel Tank 1 Capacity")]
 public string bus_format_fuel_volume1_value_1 {get; set;} = "bus_format_fuel_volume1_1^value^bus^油箱1容量大小^Fuel Tank 1 Capacity";
    ///<summary>
/// 油箱2容量大小
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "bus_format_fuel_volume2", TypeName = "value", DefaultValue = "bus_format_fuel_volume2^bus_format_fuel_volume2_1^value^bus^油箱2容量大小^Fuel Tank 2 Capacit")]
 public string bus_format_fuel_volume2_value_1 {get; set;} = "bus_format_fuel_volume2_1^value^bus^油箱2容量大小^Fuel Tank 2 Capacit";
    ///<summary>
/// 姓名
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_1^array^driver^姓名^Name")]
 public string driverTitle_array_1 {get; set;} = "driverTitle_1^array^driver^姓名^Name";
    ///<summary>
/// E-MAIL
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_2^array^driver^E-MAIL^E-MAIL")]
 public string driverTitle_array_2 {get; set;} = "driverTitle_2^array^driver^E-MAIL^E-MAIL";
    ///<summary>
/// 車輛團隊
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_3^array^driver^車輛團隊^Vehicle Group")]
 public string driverTitle_array_3 {get; set;} = "driverTitle_3^array^driver^車輛團隊^Vehicle Group";
    ///<summary>
/// 指定車輛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_4^array^driver^指定車輛^Assigned Vehicle")]
 public string driverTitle_array_4 {get; set;} = "driverTitle_4^array^driver^指定車輛^Assigned Vehicle";
    ///<summary>
/// 群組
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_5^array^driver^群組^Roles")]
 public string driverTitle_array_5 {get; set;} = "driverTitle_5^array^driver^群組^Roles";
    ///<summary>
/// 登入次數
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_6^array^driver^登入次數^Number of logins")]
 public string driverTitle_array_6 {get; set;} = "driverTitle_6^array^driver^登入次數^Number of logins";
    ///<summary>
/// 加入時間
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_7^array^driver^加入時間^Start Date")]
 public string driverTitle_array_7 {get; set;} = "driverTitle_7^array^driver^加入時間^Start Date";
    ///<summary>
/// 加入狀態
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_8^array^driver^加入狀態^User Status")]
 public string driverTitle_array_8 {get; set;} = "driverTitle_8^array^driver^加入狀態^User Status";
    ///<summary>
/// 操作
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverTitle", TypeName = "array", DefaultValue = "driverTitle^driverTitle_9^array^driver^操作^Action")]
 public string driverTitle_array_9 {get; set;} = "driverTitle_9^array^driver^操作^Action";
    ///<summary>
/// 駕駛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver", TypeName = "value", DefaultValue = "driver^driver_1^value^driver^駕駛^Driver")]
 public string driver_value_1 {get; set;} = "driver_1^value^driver^駕駛^Driver";
    ///<summary>
/// 搜尋駕駛
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_search", TypeName = "value", DefaultValue = "driver_search^driver_search_1^value^driver^搜尋駕駛^Search Driver")]
 public string driver_search_value_1 {get; set;} = "driver_search_1^value^driver^搜尋駕駛^Search Driver";
    ///<summary>
/// 駕駛資訊
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_bookmark_info", TypeName = "value", DefaultValue = "driver_bookmark_info^driver_bookmark_info_1^value^driver^駕駛資訊^Driver Information")]
 public string driver_bookmark_info_value_1 {get; set;} = "driver_bookmark_info_1^value^driver^駕駛資訊^Driver Information";
    ///<summary>
/// 健康紀錄
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_bookmark_health", TypeName = "value", DefaultValue = "driver_bookmark_health^driver_bookmark_health_1^value^driver^健康紀錄^Health Records")]
 public string driver_bookmark_health_value_1 {get; set;} = "driver_bookmark_health_1^value^driver^健康紀錄^Health Records";
    ///<summary>
/// 基本資料
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_title_basic", TypeName = "value", DefaultValue = "driver_info_title_basic^driver_info_title_basic_1^value^driver^基本資料^Profile")]
 public string driver_info_title_basic_value_1 {get; set;} = "driver_info_title_basic_1^value^driver^基本資料^Profile";
    ///<summary>
/// 姓名
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_basic_name", TypeName = "value", DefaultValue = "driver_info_basic_name^driver_info_basic_name_1^value^driver^姓名^Name")]
 public string driver_info_basic_name_value_1 {get; set;} = "driver_info_basic_name_1^value^driver^姓名^Name";
    ///<summary>
/// E-Mail
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_basic_email", TypeName = "value", DefaultValue = "driver_info_basic_email^driver_info_basic_email_1^value^driver^E-Mail^E-Mail")]
 public string driver_info_basic_email_value_1 {get; set;} = "driver_info_basic_email_1^value^driver^E-Mail^E-Mail";
    ///<summary>
/// 手機
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_basic_phone", TypeName = "value", DefaultValue = "driver_info_basic_phone^driver_info_basic_phone_1^value^driver^手機^Phone")]
 public string driver_info_basic_phone_value_1 {get; set;} = "driver_info_basic_phone_1^value^driver^手機^Phone";
    ///<summary>
/// 駕駛履歷
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_title_resume", TypeName = "value", DefaultValue = "driver_info_title_resume^driver_info_title_resume_1^value^driver^駕駛履歷^Driver History")]
 public string driver_info_title_resume_value_1 {get; set;} = "driver_info_title_resume_1^value^driver^駕駛履歷^Driver History";
    ///<summary>
/// 使用者編號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_user_number", TypeName = "value", DefaultValue = "driver_info_resume_user_number^driver_info_resume_user_number_1^value^driver^使用者編號^User ID")]
 public string driver_info_resume_user_number_value_1 {get; set;} = "driver_info_resume_user_number_1^value^driver^使用者編號^User ID";
    ///<summary>
/// 駕駛編號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_driver_number", TypeName = "value", DefaultValue = "driver_info_resume_driver_number^driver_info_resume_driver_number_1^value^driver^駕駛編號^Driver ID")]
 public string driver_info_resume_driver_number_value_1 {get; set;} = "driver_info_resume_driver_number_1^value^driver^駕駛編號^Driver ID";
    ///<summary>
/// 執照州/省/地區
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_state", TypeName = "value", DefaultValue = "driver_info_resume_state^driver_info_resume_state_1^value^driver^執照州/省/地區^License State/Province/Region")]
 public string driver_info_resume_state_value_1 {get; set;} = "driver_info_resume_state_1^value^driver^執照州/省/地區^License State/Province/Region";
    ///<summary>
/// 牌照等級
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_level", TypeName = "value", DefaultValue = "driver_info_resume_level^driver_info_resume_level_1^value^driver^牌照等級^License Class")]
 public string driver_info_resume_level_value_1 {get; set;} = "driver_info_resume_level_1^value^driver^牌照等級^License Class";
    ///<summary>
/// 駕駛資歷 (年)
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_experience", TypeName = "value", DefaultValue = "driver_info_resume_experience^driver_info_resume_experience_1^value^driver^駕駛資歷 (年)^Driver Experience (Years)")]
 public string driver_info_resume_experience_value_1 {get; set;} = "driver_info_resume_experience_1^value^driver^駕駛資歷 (年)^Driver Experience (Years)";
    ///<summary>
/// 派遣區域
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_area", TypeName = "value", DefaultValue = "driver_info_resume_area^driver_info_resume_area_1^value^driver^派遣區域^Dispatch Region")]
 public string driver_info_resume_area_value_1 {get; set;} = "driver_info_resume_area_1^value^driver^派遣區域^Dispatch Region";
    ///<summary>
/// 派遣都市
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_city", TypeName = "value", DefaultValue = "driver_info_resume_city^driver_info_resume_city_1^value^driver^派遣都市^Dispatch City")]
 public string driver_info_resume_city_value_1 {get; set;} = "driver_info_resume_city_1^value^driver^派遣都市^Dispatch City";
    ///<summary>
/// 黑名單註記
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_blacklist_check", TypeName = "value", DefaultValue = "driver_info_resume_blacklist_check^driver_info_resume_blacklist_check_1^value^driver^黑名單註記^Blacklist Flag")]
 public string driver_info_resume_blacklist_check_value_1 {get; set;} = "driver_info_resume_blacklist_check_1^value^driver^黑名單註記^Blacklist Flag";
    ///<summary>
/// 黑名單備註
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_blacklist_note", TypeName = "value", DefaultValue = "driver_info_resume_blacklist_note^driver_info_resume_blacklist_note_1^value^driver^黑名單備註^Blacklist Flag")]
 public string driver_info_resume_blacklist_note_value_1 {get; set;} = "driver_info_resume_blacklist_note_1^value^driver^黑名單備註^Blacklist Flag";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_resume_tags", TypeName = "value", DefaultValue = "driver_info_resume_tags^driver_info_resume_tags_1^value^driver^標籤^Labels")]
 public string driver_info_resume_tags_value_1 {get; set;} = "driver_info_resume_tags_1^value^driver^標籤^Labels";
    ///<summary>
/// 駕駛證照
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_title_license", TypeName = "value", DefaultValue = "driver_info_title_license^driver_info_title_license_1^value^driver^駕駛證照^Driver Certifications")]
 public string driver_info_title_license_value_1 {get; set;} = "driver_info_title_license_1^value^driver^駕駛證照^Driver Certifications";
    ///<summary>
/// 證照種類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_category", TypeName = "value", DefaultValue = "driver_info_license_category^driver_info_license_category_1^value^driver^證照種類^Certification Type")]
 public string driver_info_license_category_value_1 {get; set;} = "driver_info_license_category_1^value^driver^證照種類^Certification Type";
    ///<summary>
/// 證照名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_name", TypeName = "value", DefaultValue = "driver_info_license_name^driver_info_license_name_1^value^driver^證照名稱^Certification Name")]
 public string driver_info_license_name_value_1 {get; set;} = "driver_info_license_name_1^value^driver^證照名稱^Certification Name";
    ///<summary>
/// 發照單位
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_department", TypeName = "value", DefaultValue = "driver_info_license_department^driver_info_license_department_1^value^driver^發照單位^Issuing Authority")]
 public string driver_info_license_department_value_1 {get; set;} = "driver_info_license_department_1^value^driver^發照單位^Issuing Authority";
    ///<summary>
/// 發照日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_publish_date", TypeName = "value", DefaultValue = "driver_info_license_publish_date^driver_info_license_publish_date_1^value^driver^發照日期^Issuance Date")]
 public string driver_info_license_publish_date_value_1 {get; set;} = "driver_info_license_publish_date_1^value^driver^發照日期^Issuance Date";
    ///<summary>
/// 有效日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_valid_date", TypeName = "value", DefaultValue = "driver_info_license_valid_date^driver_info_license_valid_date_1^value^driver^有效日期^Expiration Date")]
 public string driver_info_license_valid_date_value_1 {get; set;} = "driver_info_license_valid_date_1^value^driver^有效日期^Expiration Date";
    ///<summary>
/// 下次審驗日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_next_date", TypeName = "value", DefaultValue = "driver_info_license_next_date^driver_info_license_next_date_1^value^driver^下次審驗日期^Next Inspection Date")]
 public string driver_info_license_next_date_value_1 {get; set;} = "driver_info_license_next_date_1^value^driver^下次審驗日期^Next Inspection Date";
    ///<summary>
/// 證照檔案
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_file", TypeName = "value", DefaultValue = "driver_info_license_file^driver_info_license_file_1^value^driver^證照檔案^Certifications File")]
 public string driver_info_license_file_value_1 {get; set;} = "driver_info_license_file_1^value^driver^證照檔案^Certifications File";
    ///<summary>
/// 上傳證照檔案
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_upload", TypeName = "value", DefaultValue = "driver_info_license_upload^driver_info_license_upload_1^value^driver^上傳證照檔案^Upload Certifications File")]
 public string driver_info_license_upload_value_1 {get; set;} = "driver_info_license_upload_1^value^driver^上傳證照檔案^Upload Certifications File";
    ///<summary>
/// 失效
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_invalid_check", TypeName = "value", DefaultValue = "driver_info_license_invalid_check^driver_info_license_invalid_check_1^value^driver^失效^Expired")]
 public string driver_info_license_invalid_check_value_1 {get; set;} = "driver_info_license_invalid_check_1^value^driver^失效^Expired";
    ///<summary>
/// 失效備註
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_license_invalid_note", TypeName = "value", DefaultValue = "driver_info_license_invalid_note^driver_info_license_invalid_note_1^value^driver^失效備註^Expiration Note")]
 public string driver_info_license_invalid_note_value_1 {get; set;} = "driver_info_license_invalid_note_1^value^driver^失效備註^Expiration Note";
    ///<summary>
/// 語言能力
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_title_language", TypeName = "value", DefaultValue = "driver_info_title_language^driver_info_title_language_1^value^driver^語言能力^Language")]
 public string driver_info_title_language_value_1 {get; set;} = "driver_info_title_language_1^value^driver^語言能力^Language";
    ///<summary>
/// 中文
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_language_chinese", TypeName = "value", DefaultValue = "driver_info_language_chinese^driver_info_language_chinese_1^value^driver^中文^Chinese")]
 public string driver_info_language_chinese_value_1 {get; set;} = "driver_info_language_chinese_1^value^driver^中文^Chinese";
    ///<summary>
/// 英文
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driver_info_language_english", TypeName = "value", DefaultValue = "driver_info_language_english^driver_info_language_english_1^value^driver^英文^English")]
 public string driver_info_language_english_value_1 {get; set;} = "driver_info_language_english_1^value^driver^英文^English";
    ///<summary>
/// 聽
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverLanguageAbility", TypeName = "array", DefaultValue = "driverLanguageAbility^driverLanguageAbility_1^array^driver^聽^Listening")]
 public string driverLanguageAbility_array_1 {get; set;} = "driverLanguageAbility_1^array^driver^聽^Listening";
    ///<summary>
/// 說
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverLanguageAbility", TypeName = "array", DefaultValue = "driverLanguageAbility^driverLanguageAbility_2^array^driver^說^Speaking")]
 public string driverLanguageAbility_array_2 {get; set;} = "driverLanguageAbility_2^array^driver^說^Speaking";
    ///<summary>
/// 讀
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverLanguageAbility", TypeName = "array", DefaultValue = "driverLanguageAbility^driverLanguageAbility_3^array^driver^讀^Readin")]
 public string driverLanguageAbility_array_3 {get; set;} = "driverLanguageAbility_3^array^driver^讀^Readin";
    ///<summary>
/// 寫
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverLanguageAbility", TypeName = "array", DefaultValue = "driverLanguageAbility^driverLanguageAbility_4^array^driver^寫^Writing")]
 public string driverLanguageAbility_array_4 {get; set;} = "driverLanguageAbility_4^array^driver^寫^Writing";
    ///<summary>
/// 日期
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverHealthTitle", TypeName = "array", DefaultValue = "driverHealthTitle^driverHealthTitle_1^array^driver^日期^Date")]
 public string driverHealthTitle_array_1 {get; set;} = "driverHealthTitle_1^array^driver^日期^Date";
    ///<summary>
/// 分類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverHealthTitle", TypeName = "array", DefaultValue = "driverHealthTitle^driverHealthTitle_2^array^driver^分類^Classification")]
 public string driverHealthTitle_array_2 {get; set;} = "driverHealthTitle_2^array^driver^分類^Classification";
    ///<summary>
/// 機構
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverHealthTitle", TypeName = "array", DefaultValue = "driverHealthTitle^driverHealthTitle_3^array^driver^機構^Institution")]
 public string driverHealthTitle_array_3 {get; set;} = "driverHealthTitle_3^array^driver^機構^Institution";
    ///<summary>
/// 結果
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverHealthTitle", TypeName = "array", DefaultValue = "driverHealthTitle^driverHealthTitle_4^array^driver^結果^Result")]
 public string driverHealthTitle_array_4 {get; set;} = "driverHealthTitle_4^array^driver^結果^Result";
    ///<summary>
/// 報告
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "driverHealthTitle", TypeName = "array", DefaultValue = "driverHealthTitle^driverHealthTitle_5^array^driver^報告^Report")]
 public string driverHealthTitle_array_5 {get; set;} = "driverHealthTitle_5^array^driver^報告^Report";
    ///<summary>
/// 客戶號碼
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_1^array^customer^客戶號碼^Customer ID")]
 public string customerTitle_array_1 {get; set;} = "customerTitle_1^array^customer^客戶號碼^Customer ID";
    ///<summary>
/// 名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_2^array^customer^名稱^Name")]
 public string customerTitle_array_2 {get; set;} = "customerTitle_2^array^customer^名稱^Name";
    ///<summary>
/// 分類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_3^array^customer^分類^Classification")]
 public string customerTitle_array_3 {get; set;} = "customerTitle_3^array^customer^分類^Classification";
    ///<summary>
/// 區域
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_4^array^customer^區域^Region")]
 public string customerTitle_array_4 {get; set;} = "customerTitle_4^array^customer^區域^Region";
    ///<summary>
/// 公司電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_5^array^customer^公司電話^Company Phone")]
 public string customerTitle_array_5 {get; set;} = "customerTitle_5^array^customer^公司電話^Company Phone";
    ///<summary>
/// 公司信箱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_6^array^customer^公司信箱^Company Email")]
 public string customerTitle_array_6 {get; set;} = "customerTitle_6^array^customer^公司信箱^Company Email";
    ///<summary>
/// 主要聯絡人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_7^array^customer^主要聯絡人^Primary Contact")]
 public string customerTitle_array_7 {get; set;} = "customerTitle_7^array^customer^主要聯絡人^Primary Contact";
    ///<summary>
/// 主要聯絡人電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_8^array^customer^主要聯絡人電話^Primary Contact Phone")]
 public string customerTitle_array_8 {get; set;} = "customerTitle_8^array^customer^主要聯絡人電話^Primary Contact Phone";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_9^array^customer^標籤^Labels")]
 public string customerTitle_array_9 {get; set;} = "customerTitle_9^array^customer^標籤^Labels";
    ///<summary>
/// 操作
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customerTitle", TypeName = "array", DefaultValue = "customerTitle^customerTitle_10^array^customer^操作^Action")]
 public string customerTitle_array_10 {get; set;} = "customerTitle_10^array^customer^操作^Action";
    ///<summary>
/// 客戶
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer", TypeName = "value", DefaultValue = "customer^customer_1^value^customer^客戶^Customer")]
 public string customer_value_1 {get; set;} = "customer_1^value^customer^客戶^Customer";
    ///<summary>
/// 名稱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_name", TypeName = "value", DefaultValue = "customer_fast_name^customer_fast_name_1^value^customer^名稱^Name")]
 public string customer_fast_name_value_1 {get; set;} = "customer_fast_name_1^value^customer^名稱^Name";
    ///<summary>
/// 統一編號
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_company_number", TypeName = "value", DefaultValue = "customer_fast_company_number^customer_fast_company_number_1^value^customer^統一編號^Tax ID Number")]
 public string customer_fast_company_number_value_1 {get; set;} = "customer_fast_company_number_1^value^customer^統一編號^Tax ID Number";
    ///<summary>
/// 負責人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_owner", TypeName = "value", DefaultValue = "customer_fast_owner^customer_fast_owner_1^value^customer^負責人^President")]
 public string customer_fast_owner_value_1 {get; set;} = "customer_fast_owner_1^value^customer^負責人^President";
    ///<summary>
/// 公司地址
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_company_address", TypeName = "value", DefaultValue = "customer_fast_company_address^customer_fast_company_address_1^value^customer^公司地址^Company Address")]
 public string customer_fast_company_address_value_1 {get; set;} = "customer_fast_company_address_1^value^customer^公司地址^Company Address";
    ///<summary>
/// 地址1
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_address1", TypeName = "value", DefaultValue = "customer_fast_address1^customer_fast_address1_1^value^customer^地址1^Address")]
 public string customer_fast_address1_value_1 {get; set;} = "customer_fast_address1_1^value^customer^地址1^Address";
    ///<summary>
/// 地址2
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_address2", TypeName = "value", DefaultValue = "customer_fast_address2^customer_fast_address2_1^value^customer^地址2^Address Line 2")]
 public string customer_fast_address2_value_1 {get; set;} = "customer_fast_address2_1^value^customer^地址2^Address Line 2";
    ///<summary>
/// 城市
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_city", TypeName = "value", DefaultValue = "customer_fast_city^customer_fast_city_1^value^customer^城市^City")]
 public string customer_fast_city_value_1 {get; set;} = "customer_fast_city_1^value^customer^城市^City";
    ///<summary>
/// 州/省/區域
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_state", TypeName = "value", DefaultValue = "customer_fast_state^customer_fast_state_1^value^customer^州/省/區域^State/Province/Region")]
 public string customer_fast_state_value_1 {get; set;} = "customer_fast_state_1^value^customer^州/省/區域^State/Province/Region";
    ///<summary>
/// 郵政編碼
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_zipcode", TypeName = "value", DefaultValue = "customer_fast_zipcode^customer_fast_zipcode_1^value^customer^郵政編碼^Zip/Postal Code")]
 public string customer_fast_zipcode_value_1 {get; set;} = "customer_fast_zipcode_1^value^customer^郵政編碼^Zip/Postal Code";
    ///<summary>
/// 國家
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_country", TypeName = "value", DefaultValue = "customer_fast_country^customer_fast_country_1^value^customer^國家^Country")]
 public string customer_fast_country_value_1 {get; set;} = "customer_fast_country_1^value^customer^國家^Country";
    ///<summary>
/// 公司電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_company_phone", TypeName = "value", DefaultValue = "customer_fast_company_phone^customer_fast_company_phone_1^value^customer^公司電話^Company Phone")]
 public string customer_fast_company_phone_value_1 {get; set;} = "customer_fast_company_phone_1^value^customer^公司電話^Company Phone";
    ///<summary>
/// 主要聯絡人
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_main_contact", TypeName = "value", DefaultValue = "customer_fast_main_contact^customer_fast_main_contact_1^value^customer^主要聯絡人^Primary Contact")]
 public string customer_fast_main_contact_value_1 {get; set;} = "customer_fast_main_contact_1^value^customer^主要聯絡人^Primary Contact";
    ///<summary>
/// 主要聯絡人電話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_main_title_phone", TypeName = "value", DefaultValue = "customer_fast_main_title_phone^customer_fast_main_title_phone_1^value^customer^主要聯絡人電話^Primary Contact")]
 public string customer_fast_main_title_phone_value_1 {get; set;} = "customer_fast_main_title_phone_1^value^customer^主要聯絡人電話^Primary Contact";
    ///<summary>
/// 市話
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_main_tel", TypeName = "value", DefaultValue = "customer_fast_main_tel^customer_fast_main_tel_1^value^customer^市話^Telephone")]
 public string customer_fast_main_tel_value_1 {get; set;} = "customer_fast_main_tel_1^value^customer^市話^Telephone";
    ///<summary>
/// 手機
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_main_mobile", TypeName = "value", DefaultValue = "customer_fast_main_mobile^customer_fast_main_mobile_1^value^customer^手機^Mobile")]
 public string customer_fast_main_mobile_value_1 {get; set;} = "customer_fast_main_mobile_1^value^customer^手機^Mobile";
    ///<summary>
/// 分類
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_fast_category", TypeName = "value", DefaultValue = "customer_fast_category^customer_fast_category_1^value^customer^分類^Classification")]
 public string customer_fast_category_value_1 {get; set;} = "customer_fast_category_1^value^customer^分類^Classification";
    ///<summary>
/// 客戶資料
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_bookmark_info", TypeName = "value", DefaultValue = "customer_bookmark_info^customer_bookmark_info_1^value^customer^客戶資料^Customer Information")]
 public string customer_bookmark_info_value_1 {get; set;} = "customer_bookmark_info_1^value^customer^客戶資料^Customer Information";
    ///<summary>
/// 基本資料
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_title_basic", TypeName = "value", DefaultValue = "customer_info_title_basic^customer_info_title_basic_1^value^customer^基本資料^Profile")]
 public string customer_info_title_basic_value_1 {get; set;} = "customer_info_title_basic_1^value^customer^基本資料^Profile";
    ///<summary>
/// 客戶號碼
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_basic_number", TypeName = "value", DefaultValue = "customer_info_basic_number^customer_info_basic_number_1^value^customer^客戶號碼^Customer ID")]
 public string customer_info_basic_number_value_1 {get; set;} = "customer_info_basic_number_1^value^customer^客戶號碼^Customer ID";
    ///<summary>
/// 標籤
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_title_tag", TypeName = "value", DefaultValue = "customer_info_title_tag^customer_info_title_tag_1^value^customer^標籤^Labels")]
 public string customer_info_title_tag_value_1 {get; set;} = "customer_info_title_tag_1^value^customer^標籤^Labels";
    ///<summary>
/// 聯絡方式
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_title_contact", TypeName = "value", DefaultValue = "customer_info_title_contact^customer_info_title_contact_1^value^customer^聯絡方式^Contact Information")]
 public string customer_info_title_contact_value_1 {get; set;} = "customer_info_title_contact_1^value^customer^聯絡方式^Contact Information";
    ///<summary>
/// 公司傳真
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_contact_company_fax", TypeName = "value", DefaultValue = "customer_info_contact_company_fax^customer_info_contact_company_fax_1^value^customer^公司傳真^Company Fax")]
 public string customer_info_contact_company_fax_value_1 {get; set;} = "customer_info_contact_company_fax_1^value^customer^公司傳真^Company Fax";
    ///<summary>
/// 公司信箱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_contact_company_email", TypeName = "value", DefaultValue = "customer_info_contact_company_email^customer_info_contact_company_email_1^value^customer^公司信箱^Company Email")]
 public string customer_info_contact_company_email_value_1 {get; set;} = "customer_info_contact_company_email_1^value^customer^公司信箱^Company Email";
    ///<summary>
/// 公司網址
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_contact_company_website", TypeName = "value", DefaultValue = "customer_info_contact_company_website^customer_info_contact_company_website_1^value^customer^公司網址^Company Website")]
 public string customer_info_contact_company_website_value_1 {get; set;} = "customer_info_contact_company_website_1^value^customer^公司網址^Company Website";
    ///<summary>
/// 主要聯絡人信箱
/// ITTC-04509-0088
/// Data Source=S-DB-ELDPLAT; Initial Catalog=vehicle; User ID=U_Vehicle_AP;Password=Ah*TVeJmYP
/// view_backend
///</summary>
[ColumnsLanguage(Name = "customer_info_contact_main_email", TypeName = "value", DefaultValue = "customer_info_contact_main_email^customer_info_contact_main_email_1^value^customer^主要聯絡人信箱^Primary Contact")]
 public string customer_info_contact_main_email_value_1 {get; set;} = "customer_info_contact_main_email_1^value^customer^主要聯絡人信箱^Primary Contact";
	}

	/// <summary>
	/// 語系列舉<br/>
	///  ENGLISH: "en_us",<br/>
	///  CHINESE: "zh_tw",<br/>
	///  THAI: "th_th",<br/>
	/// </summary>
	public enum VendorLanguageList
	{
		///<summary>
/// id
/// </summary>
[Description("0")] id,
    ///<summary>
/// type
/// </summary>
[Description("1")] type,
    ///<summary>
/// page
/// </summary>
[Description("2")] page,
    ///<summary>
/// sort
/// </summary>
[Description("3")] sort,
    ///<summary>
/// zh_tw
/// </summary>
[Description("4")] zh_tw,
    ///<summary>
/// en_us
/// </summary>
[Description("5")] en_us,
	}
}

