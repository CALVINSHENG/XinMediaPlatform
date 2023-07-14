
using System;
namespace MicroServiceCoreResposity.DbAccess.T4_Design_Time
{
    // Disable the warning.
#pragma warning disable S101
    //警告	S101 Rename class 'GenerateEventCodeModelTtFile' 
    //to match pascal case naming rules, 
    //consider using 'GenerateEventCodeModelTtFile'.	MicroServiceCoreLibrary

    //
    // Code that uses obsolete API.
    // ...

    // Re-enable the warning.
    //#pragma warning restore SYSLIB0021

    /// <summary>
    /// 訊息代碼資料表資訊
    /// </summary>
    public static class GenerateEventCodeModelRowsCountsTtFile
    {   /// <summary>
        /// 資料總筆數
        /// </summary>
        public const int DataCount = 39;

        public const int FieldCount = 5;

        public const bool LackSummary = false;
    }
    /// <summary>
    /// 訊息代碼簡述<br/>
    /// 可以GenerateEventCodeModelTtFile.[代碼]時檢視
    /// </summary>
    ///public static class GenerateEventCodeModelTtFile
    public static class EventCode_Test
    {
        /// <summary>
        /// 派車數量為 0
        /// </summary>
        public static string AUTODISPATCH_0000000001 { get; set; } = "0000000001^AUTODISPATCH^詢價單號 {0}：派車數量為 0 ，請改用手動派車。^Inquiry No. {0}: The dispatch quantity is 0, please use manual dispatch instead.";
        /// <summary>
        /// 自動派車發生系統錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000002 { get; set; } = "0000000002^AUTODISPATCH^詢價單號 {0}：自動派車發生錯誤，請改用手動派車。^Inquiry number {0}: An error occurred in the automatic dispatch, please switch to manual dispatch.";
        /// <summary>
        /// 派車數量過程發生系統錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000003 { get; set; } = "0000000003^AUTODISPATCH^詢價單號 {0}：無法取得派車數量，請改用手動派車。^Inquiry number {0}: Unable to obtain the delivery quantity, please use manual delivery instead.";
        /// <summary>
        /// 無法媒合到符合的車輛
        /// </summary>
        public static string AUTODISPATCH_0000000004 { get; set; } = "0000000004^AUTODISPATCH^詢價單號 {0}：查無符合的車輛，請改用手動派車。^Inquiry number {0}: No matching vehicle found, please use manual delivery instead.";
        /// <summary>
        /// 訂單日期起迄日錯誤
        /// </summary>
        public static string AUTODISPATCH_0000000005 { get; set; } = "0000000005^AUTODISPATCH^詢價單號 {0}：訂單需求結束日期( {1} )不得小於開始日期( {2} )，請改用手動派車。^Inquiry number {0}: The end date of the order request ( {1} ) cannot be less than the start date ( {2} ), please use manual delivery instead.";
        /// <summary>
        /// 訂單日期為過去時間
        /// </summary>
        public static string AUTODISPATCH_0000000006 { get; set; } = "0000000006^AUTODISPATCH^詢價單號 {0}：訂單需求開始日期( {1} )為過去時間，請改用手動派車。^Inquiry number {0}: The start date of the order request ( {1} ) is in the past, please use manual delivery instead.";
        /// <summary>
        /// 全數透過自動派發
        /// </summary>
        public static string AUTODISPATCH_0000000007 { get; set; } = "0000000007^AUTODISPATCH^詢價單號 {0}：{1} 日行程，已自動派發 {2} 台車輛，共計發出 {3} 張派車單 {4} 張派工單。總計 {5} 張表單。^Inquiry number {0}: {1} day itinerary, {2} vehicles have been automatically dispatched, and a total of {3} dispatch orders and {4} work orders have been issued. Total {5} forms.";
        /// <summary>
        /// 部分透過自動派發，部分手動派發
        /// </summary>
        public static string AUTODISPATCH_0000000008 { get; set; } = "0000000008^AUTODISPATCH^詢價單號 {0}：{1} 日行程，計畫派發 {2} 台車輛，已部分透過自動派發 {2} 台車輛({3})，共計發出 {4} 張派車單 {5} 張派工單。{6} 請改用手動派車。^Inquiry number {0}: {1} day itinerary, {2} vehicles are planned to be dispatched, and {2} vehicles ({3}) have been partially dispatched automatically. A total of {4} dispatch orders {5 } Zhang dispatch work order. {6} Please use manual delivery instead.";
        /// <summary>
        /// 無媒合到未派發車輛資料
        /// </summary>
        public static string AUTODISPATCH_0000000009 { get; set; } = "0000000009^AUTODISPATCH^詢價單號 {0}：{1} 日行程，調用 {0} 台車輛，無媒合到資料，請改用手動派車。^Inquiry number {0}: {1} day itinerary, call {0} vehicles, no matching data, please use manual dispatch instead.";
        /// <summary>
        /// 儲存成功
        /// </summary>
        public static string COMM_00001 { get; set; } = "00001^COMM^儲存成功^Save successful";
        /// <summary>
        /// 發信內容
        /// </summary>
        public static string MAIL_00001 { get; set; } = "00001^MAIL^親愛的 {0} 你好： \r\n 你的管理員 {1} 已經成功把你加到 {2} 的公司平台， \r\n 點擊登入即可使用 {3}  \r\n  \r\n  你的預設資料為 : \r\n 【登入名稱】： {4} \r\n 【登入密碼】：{5}^Dear {0}: \r\n Your manager {1} has invited you to join the {2} platform, \r\n click to login and join now : {3} \r\n \r\n Here is your login information: \r\n 【Account】: {4} \r\n 【Password】: {5}";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00001 { get; set; } = "00001^MSG^一旦確認，系統就會寄送信件邀請 {0} 加入 {1} 的平台囉！請問確定要發送嗎？^Once confirmed, System will send an E-mail inviting {0} to join the {} platform! Are you sure about that?";
        /// <summary>
        /// 接受報價
        /// </summary>
        public static string ORD_00001 { get; set; } = "00001^ORD^訂單{0}確認金額NT${1}，請於繳費期限內付款，完成訂車作業。^";
        /// <summary>
        /// 儲存失敗
        /// </summary>
        public static string COMM_00002 { get; set; } = "00002^COMM^儲存失敗^Save failed";
        /// <summary>
        /// 發信內容
        /// </summary>
        public static string MAIL_00002 { get; set; } = "00002^MAIL^【ELDPLAT 系統通知】你在 {0} 平台上的權限已開啟！_【ELDPLAT NOTICE】^Your permission on {0} has enabled ! ";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00002 { get; set; } = "00002^MSG^已發送邀請！^The Invitation has been sent.";
        /// <summary>
        /// 已開放重新繳款
        /// </summary>
        public static string ORD_00002 { get; set; } = "00002^ORD^訂單{0} 已開放重新繳款，請於繳費期限內付款，完成訂車作業。^";
        /// <summary>
        /// 更新成功
        /// </summary>
        public static string COMM_00003 { get; set; } = "00003^COMM^更新成功^Update successful";
        /// <summary>
        /// 罐頭訊息
        /// </summary>
        public static string MSG_00003 { get; set; } = "00003^MSG^確認後 {0} 就會刪除 \r\n 有被指定腳色的員工，權限也會移除，無法繼續使用功能 \r\n 確定要刪除嗎？^Once confirmed, The {} will be deleted, the employees who has this group, the permissions will be remove too, are you sure?";
        /// <summary>
        /// 付款作業處理中
        /// </summary>
        public static string ORD_00003 { get; set; } = "00003^ORD^訂單{0} 付款作業處理中，後續將寄信告知是否完成付款。^";
        /// <summary>
        /// 更新失敗
        /// </summary>
        public static string COMM_00004 { get; set; } = "00004^COMM^更新失敗^Update failed";
        /// <summary>
        /// 刪除成功
        /// </summary>
        public static string COMM_00005 { get; set; } = "00005^COMM^刪除成功^Delete successful";
        /// <summary>
        /// 刪除失敗
        /// </summary>
        public static string COMM_00006 { get; set; } = "00006^COMM^刪除失敗^Delete failed";
        /// <summary>
        /// 參數錯誤
        /// </summary>
        public static string COMM_00007 { get; set; } = "00007^COMM^參數錯誤^Parameters error";
        /// <summary>
        /// 用戶端要求成功
        /// </summary>
        public static string HTTP_200 { get; set; } = "200^HTTP^用戶端要求成功^OK";
        /// <summary>
        /// 已接受
        /// </summary>
        public static string HTTP_202 { get; set; } = "202^HTTP^已接受^Accepted";
        /// <summary>
        /// 非授權資訊
        /// </summary>
        public static string HTTP_203 { get; set; } = "203^HTTP^非授權資訊^Non-Authoritative Information";
        /// <summary>
        /// 無內容
        /// </summary>
        public static string HTTP_204 { get; set; } = "204^HTTP^無內容^No Content";
        /// <summary>
        /// 錯誤的要求
        /// </summary>
        public static string HTTP_400 { get; set; } = "400^HTTP^錯誤的要求^Bad Request";
        /// <summary>
        /// 拒絕存取
        /// </summary>
        public static string HTTP_401 { get; set; } = "401^HTTP^拒絕存取^Unauthorized";
        /// <summary>
        /// 禁止使用
        /// </summary>
        public static string HTTP_403 { get; set; } = "403^HTTP^禁止使用^Forbidden";
        /// <summary>
        /// 找不到
        /// </summary>
        public static string HTTP_404 { get; set; } = "404^HTTP^找不到^Not Found";
        /// <summary>
        /// 用來存取這個頁面的 HTTP 動詞不受允許
        /// </summary>
        public static string HTTP_405 { get; set; } = "405^HTTP^用來存取這個頁面的 HTTP 動詞不受允許^Method Not Allowed";
        /// <summary>
        /// 執行失敗
        /// </summary>
        public static string HTTP_417 { get; set; } = "417^HTTP^執行失敗^Expectation Failed";
        /// <summary>
        /// 內部伺服器錯誤
        /// </summary>
        public static string HTTP_500 { get; set; } = "500^HTTP^內部伺服器錯誤^Internal Server Error";
        /// <summary>
        /// 標頭值指定未實作的設定
        /// </summary>
        public static string HTTP_501 { get; set; } = "501^HTTP^標頭值指定未實作的設定^Not Implemented";
        /// <summary>
        /// Web 伺服器在作為閘道或 Proxy 時收到無效的回應
        /// </summary>
        public static string HTTP_502 { get; set; } = "502^HTTP^Web 伺服器在作為閘道或 Proxy 時收到無效的回應^Bad Gateway";
        /// <summary>
        /// 閘道逾時
        /// </summary>
        public static string HTTP_504 { get; set; } = "504^HTTP^閘道逾時^Gateway Timeout";
        /// <summary>
        /// 不支援的 HTTP 版本
        /// </summary>
        public static string HTTP_505 { get; set; } = "505^HTTP^不支援的 HTTP 版本^HTTP Version Not Supported";
    }
}

