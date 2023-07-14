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
#pragma warning disable S1118 // Utility classes should not have public constructors
#endregion

using Dapper.Contrib.Extensions;
using MicroServiceCoreLibrary.Attributes;
using MicroServiceCoreResposity.Entity;
using System;
using System.ComponentModel;

namespace MicroServiceCoreResposity.DbAccess.T4_Design_Time
{
    /// <summary>
    /// 多語系程序處理訊息前端系統代碼對應表
    /// </summary>
    public static class DataCheck_EventCode
    {
        ///<summary>
        /// 資料表筆數
        ///</summary>
        public const int DataCount_EventCode = 43;
        ///<summary>
        /// 資料表欄位數
        ///</summary>
        public const int FieldCount_EventCode = 5;
        ///<summary>
        /// 註解有(false)無(true)填寫
        ///</summary>
        public const bool LackSummary_EventCode = false;
    }
    /// <summary>
    /// 📒多語系程序處理訊息前端系統代碼對應表
    /// 📒EventCode
    /// </summary>
    [Table("'message'")]
    public class EventCode
    {
        /// <summary>
        /// 派車數量為 0
        /// </summary>
        public static string AUTODISPATCH_0000000001 { get; set; } = "0000000001^AUTODISPATCH^詢價單號 {0}：派車數量為 0 ，請改用手動派車。^Inquiry No. {0}: The dispatch quantity is 0, please use manual dispatch instead.^派車數量為 0";
        /// <summary>
        /// 自動派車發生系統錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000002 { get; set; } = "0000000002^AUTODISPATCH^詢價單號 {0}：自動派車發生錯誤，請改用手動派車。^Inquiry number {0}: An error occurred in the automatic dispatch, please switch to manual dispatch.^自動派車發生系統錯誤";
        /// <summary>
        /// 派車數量過程發生系統錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000003 { get; set; } = "0000000003^AUTODISPATCH^詢價單號 {0}：無法取得派車數量，請改用手動派車。^Inquiry number {0}: Unable to obtain the delivery quantity, please use manual delivery instead.^派車數量過程發生系統錯誤";
        /// <summary>
        /// 無法媒合到符合的車輛
        /// </summary>
        public static string AUTODISPATCH_0000000004 { get; set; } = "0000000004^AUTODISPATCH^詢價單號 {0}：查無符合的車輛，請改用手動派車。^Inquiry number {0}: No matching vehicle found, please use manual delivery instead.^無法媒合到符合的車輛";
        /// <summary>
        /// 訂單日期起迄日錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000005 { get; set; } = "0000000005^AUTODISPATCH^詢價單號 {0}：訂單需求結束日期( {1} )不得小於開始日期( {2} )，請改用手動派車。^Inquiry number {0}: The end date of the order request ( {1} ) cannot be less than the start date ( {2} ), please use manual delivery instead.^訂單日期起迄日錯誤";
        /// <summary>
        /// 訂單日期為過去時間
        /// </summary>
        public static string AUTODISPATCH_0000000006 { get; set; } = "0000000006^AUTODISPATCH^詢價單號 {0}：訂單需求開始日期( {1} )為過去時間，請改用手動派車。^Inquiry number {0}: The start date of the order request ( {1} ) is in the past, please use manual delivery instead.^訂單日期為過去時間";
        /// <summary>
        /// 全數透過自動派發
        /// </summary>
        public static string AUTODISPATCH_0000000007 { get; set; } = "0000000007^AUTODISPATCH^詢價單號 {0}： {1} 日行程，預計派發 {2} 台車輛，已經全數自動派發 {3} 台車輛({4})，共計發出 {5} 張派車單 {6} 張派工單。總計發出 {7} 張派單。^Inquiry number {0}: {1} day itinerary, {2} vehicles are expected to be dispatched, all {3} vehicles ({4}) have been dispatched automatically, and {5} dispatch orders {6} have been issued in total Dispatch List. A total of {7} dispatches have been sent.^全數透過自動派發";
        /// <summary>
        /// 部分透過自動派發，部分手動派發
        /// </summary>
        public static string AUTODISPATCH_0000000008 { get; set; } = "0000000008^AUTODISPATCH^詢價單號 {0}： {1} 日行程，預計派發 {2} 台車輛，實際自動派發 {3} 台車輛({4})，共計發出 {5} 張派車單 {6} 張派工單，總計目前發出 {7} 張派單。第 {8} 車之後，請改用手動派車。^Inquiry number {0}: {1} day itinerary, {2} vehicles are expected to be dispatched, {3} vehicles ({4}) are actually dispatched automatically, and a total of {5} dispatch orders {6} dispatches have been issued Tickets, a total of {7} dispatches are currently issued. After the {8} car, please switch to manual dispatch.^部分透過自動派發，部分手動派發";
        /// <summary>
        /// 無媒合到未派發車輛資料
        /// </summary>
        public static string AUTODISPATCH_0000000009 { get; set; } = "0000000009^AUTODISPATCH^詢價單號 {0}： {1} 日行程，預計調用 {2} 台車輛，無媒合到資料，請改用手動派車。^Inquiry number {0}: {1} day itinerary, {2} vehicles are expected to be called, but there is no matching information, please use manual dispatch instead.^無媒合到未派發車輛資料";
        /// <summary>
        /// 車隊車號人員配置
        /// </summary>
        public static string AUTODISPATCH_0000000010 { get; set; } = "0000000010^AUTODISPATCH^司機員 {0}-駕駛 {1} 號車^Driver {0} - driving car {1}^車隊車號人員配置";
        /// <summary>
        /// 優先權排列無效
        /// </summary>
        public static string AUTODISPATCH_0000000011 { get; set; } = "0000000011^AUTODISPATCH^詢價單號 {0}：優先權列表無法產生，請改用手動派車。^Inquiry number {0}: The priority list cannot be generated, please use manual dispatch instead.^優先權排列無效";
        /// <summary>
        /// 無法自動派車
        /// </summary>
        public static string AUTODISPATCH_0000000012 { get; set; } = "0000000012^AUTODISPATCH^目前無法完成自動派單，請重新設定媒合條件或是改用手動派單^Currently, the automatic order dispatch cannot be completed. Please reset the matching conditions or switch to manual order dispatch^無法自動派車";
        /// <summary>
        /// 查無日期區間駕駛排班表
        /// </summary>
        public static string AUTODISPATCH_0000000013 { get; set; } = "0000000013^AUTODISPATCH^詢價單號 {0}： 日期區間{1}~{2}，{3}日行程查無駕駛排班表資料，請改用手動派車。^Inquiry number {0}: Date range {1}~{2}, {3} day itinerary has no driving schedule information, please use manual dispatch instead.^查無日期區間駕駛排班表";
        /// <summary>
        /// 儲存成功
        /// </summary>
        public static string COMM_00001 { get; set; } = "00001^COMM^儲存成功^Save successful^儲存成功";
        /// <summary>
        /// 發信內容
        /// </summary>
        public static string MAIL_00001 { get; set; } = "00001^MAIL^親愛的 {0} 你好： \r\n 你的管理員 {1} 已經成功把你加到 {2} 的公司平台， \r\n 點擊登入即可使用 {3}  \r\n  \r\n  你的預設資料為 : \r\n 【登入名稱】： {4} \r\n 【登入密碼】：{5}^Dear {0}: \r\n Your manager {1} has invited you to join the {2} platform, \r\n click to login and join now : {3} \r\n \r\n Here is your login information: \r\n 【Account】: {4} \r\n 【Password】: {5}^發信內容";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00001 { get; set; } = "00001^MSG^一旦確認，系統就會寄送信件邀請 {0} 加入 {1} 的平台囉！請問確定要發送嗎？^Once confirmed, System will send an E-mail inviting {0} to join the {} platform! Are you sure about that?^罐頭訊息";
        /// <summary>
        /// 接受報價
        /// </summary>
        public static string ORD_00001 { get; set; } = "00001^ORD^訂單{0}確認金額NT${1}，請於繳費期限內付款，完成訂車作業。^^接受報價";
        /// <summary>
        /// 儲存失敗
        /// </summary>
        public static string COMM_00002 { get; set; } = "00002^COMM^儲存失敗^Save failed^儲存失敗";
        /// <summary>
        /// 發信內容
        /// </summary>
        public static string MAIL_00002 { get; set; } = "00002^MAIL^【ELDPLAT 系統通知】你在 {0} 平台上的權限已開啟！_【ELDPLAT NOTICE】^Your permission on {0} has enabled ! ^發信內容";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00002 { get; set; } = "00002^MSG^已發送邀請！^The Invitation has been sent.^罐頭訊息";
        /// <summary>
        /// 已開放重新繳款
        /// </summary>
        public static string ORD_00002 { get; set; } = "00002^ORD^訂單{0} 已開放重新繳款，請於繳費期限內付款，完成訂車作業。^^已開放重新繳款";
        /// <summary>
        /// 更新成功
        /// </summary>
        public static string COMM_00003 { get; set; } = "00003^COMM^更新成功^Update successful^更新成功";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00003 { get; set; } = "00003^MSG^確認後 {0} 就會刪除 \r\n 有被指定腳色的員工，權限也會移除，無法繼續使用功能 \r\n 確定要刪除嗎？^Once confirmed, The {} will be deleted, the employees who has this group, the permissions will be remove too, are you sure?^罐頭訊息";
        /// <summary>
        /// 付款作業處理中
        /// </summary>
        public static string ORD_00003 { get; set; } = "00003^ORD^訂單{0} 付款作業處理中，後續將寄信告知是否完成付款。^^付款作業處理中";
        /// <summary>
        /// 更新失敗
        /// </summary>
        public static string COMM_00004 { get; set; } = "00004^COMM^更新失敗^Update failed^更新失敗";
        /// <summary>
        /// 刪除成功
        /// </summary>
        public static string COMM_00005 { get; set; } = "00005^COMM^刪除成功^Delete successful^刪除成功";
        /// <summary>
        /// 刪除失敗
        /// </summary>
        public static string COMM_00006 { get; set; } = "00006^COMM^刪除失敗^Delete failed^刪除失敗";
        /// <summary>
        /// 參數錯誤
        /// </summary>
        public static string COMM_00007 { get; set; } = "00007^COMM^參數錯誤^Parameters error^參數錯誤";
        /// <summary>
        /// 用戶端要求成功
        /// </summary>
        public static string HTTP_200 { get; set; } = "200^HTTP^用戶端要求成功^OK^用戶端要求成功";
        /// <summary>
        /// 已接受
        /// </summary>
        public static string HTTP_202 { get; set; } = "202^HTTP^已接受^Accepted^已接受";
        /// <summary>
        /// 非授權資訊
        /// </summary>
        public static string HTTP_203 { get; set; } = "203^HTTP^非授權資訊^Non-Authoritative Information^非授權資訊";
        /// <summary>
        /// 無內容
        /// </summary>
        public static string HTTP_204 { get; set; } = "204^HTTP^無內容^No Content^無內容";
        /// <summary>
        /// 錯誤的要求
        /// </summary>
        public static string HTTP_400 { get; set; } = "400^HTTP^錯誤的要求^Bad Request^錯誤的要求";
        /// <summary>
        /// 拒絕存取
        /// </summary>
        public static string HTTP_401 { get; set; } = "401^HTTP^拒絕存取^Unauthorized^拒絕存取";
        /// <summary>
        /// 禁止使用
        /// </summary>
        public static string HTTP_403 { get; set; } = "403^HTTP^禁止使用^Forbidden^禁止使用";
        /// <summary>
        /// 找不到
        /// </summary>
        public static string HTTP_404 { get; set; } = "404^HTTP^找不到^Not Found^找不到";
        /// <summary>
        /// 用來存取這個頁面的 HTTP 動詞不受允許
        /// </summary>
        public static string HTTP_405 { get; set; } = "405^HTTP^用來存取這個頁面的 HTTP 動詞不受允許^Method Not Allowed^用來存取這個頁面的 HTTP 動詞不受允許";
        /// <summary>
        /// 執行失敗
        /// </summary>
        public static string HTTP_417 { get; set; } = "417^HTTP^執行失敗^Expectation Failed^執行失敗";
        /// <summary>
        /// 內部伺服器錯誤
        /// </summary>
        public static string HTTP_500 { get; set; } = "500^HTTP^內部伺服器錯誤^Internal Server Error^內部伺服器錯誤";
        /// <summary>
        /// 標頭值指定未實作的設定
        /// </summary>
        public static string HTTP_501 { get; set; } = "501^HTTP^標頭值指定未實作的設定^Not Implemented^標頭值指定未實作的設定";
        /// <summary>
        /// Web 伺服器在作為閘道或 Proxy 時收到無效的回應
        /// </summary>
        public static string HTTP_502 { get; set; } = "502^HTTP^Web 伺服器在作為閘道或 Proxy 時收到無效的回應^Bad Gateway^Web 伺服器在作為閘道或 Proxy 時收到無效的回應";
        /// <summary>
        /// 閘道逾時
        /// </summary>
        public static string HTTP_504 { get; set; } = "504^HTTP^閘道逾時^Gateway Timeout^閘道逾時";
        /// <summary>
        /// 不支援的 HTTP 版本
        /// </summary>
        public static string HTTP_505 { get; set; } = "505^HTTP^不支援的 HTTP 版本^HTTP Version Not Supported^不支援的 HTTP 版本";
    }
}

