using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models
{
    /// <summary>
    ///  信件資料模型類別，請務必包含收件人信箱地址(List)、信件主旨、信件內容
    /// </summary>
    /// <param></param>
    /// 
    // Disable the warning.


    //
    // Code that uses obsolete API.
    // 
#pragma warning disable CS8618
    // 退出建構函式時，不可為null的屬性必須包含非Null值。請考慮將屬性宣告為可為 Null。
#pragma warning disable S125
    // Remove this commented out code.
    // Re-enable the warning.
    //#pragma warning restore SYSLIB0021

    /*
        * 編輯作者：REMARK BY SHAN AT 2022/01/19
        * 說明：
        * 1. MailModel承接信件組成主要元素
        * 2. 承接各情境所需不同變數
        */
    public class MailModel
    {
        /*
        * 編輯作者：REMARK BY SHAN AT 2022/01/19
        * 說明：
        * 1. MailModel承接信件組成主要元素
        */

        /// <summary>
        /// 信件主旨
        /// </summary>>
        public string Subject { get; set; } = "【EldPlat】系統信件";

        /// <summary>
        /// 信件內容(Text)
        /// </summary>>
        public string TextBody { get; set; }

        /// <summary>
        /// 收件人姓名(單一收件者)
        /// </summary>
        public string? To_Name { get; set; }

        /// <summary>
        /// 多收件人姓名(List) 
        /// ///</summary>>
        public List<string>? To_NameList { get; set; }

        /// <summary>
        /// 收件人信箱(單一收件人)
        /// </summary>        
        public string? To_Address { get; set; }

        /// <summary>
        /// 多收件人信箱(List)
        /// </summary>>
        public List<string>? To_AddressList { get; set; }

        /// <summary>
        /// 寄件人姓名(單一寄件人)
        /// </summary>> 
        public string? From { get; set; } = "【EldPlat】系統信件";

        /// <summary>
        /// 寄件人信箱地址
        /// </summary>>
        public string? From_Address { get; set; } = "xuanlu0424@gmail.com";

        /// <summary>
        /// 信件內容(HTML)
        /// </summary>>
        public string? HtmlBody { get; set; } = null;

        /// <summary>
        /// 副本(單一收件人)
        /// </summary>
        public string? Cc { get; set; } = null;

        /// <summary>
        /// 多副本(List)
        /// </summary>>
        public List<string>? CcList { get; set; } = null;

        /// <summary>
        /// 密件副本(單一收件人)
        /// </summary>
        public string? Bcc { get; set; } = null;

        /// <summary>
        /// 密件副本(List)
        /// </summary>>
        public List<string>? BccList { get; set; } = null;

        /// <summary>
        /// 附件(單一附件)
        /// </summary>
        public string? Attachment { get; set; } = null;

        /// <summary>
        /// 附件(多附件)
        /// </summary>>
        public List<string>? AttachmentList { get; set; }

        /// <summary>
        /// 信件回復收件人(單一收件者)
        /// </summary>
        public string? ReplyTo_Address { get; set; } = null;

        /// <summary>
        /// 信件回覆收件人(多位收件者)
        /// </summary>>
        public List<string>? ReplyTo_AddressList { get; set; }

        /*
        * 編輯作者：REMARK BY SHAN AT 2022/01/19
        * 說明：
        * 1. 承接各情境信件組成所需變數
        */
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string? Company_name { get; set; } = null;

        /// <summary>
        /// URL連結字串
        /// </summary>
        public string? Url { get; set; } = null;

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string? User_Accont { get; set; }

        /// <summary>
        /// 使用者密碼(使用方法待討論)
        /// </summary>
        public string? User_Pwd { get; set; }

        /// <summary>
        /// 組織管理員姓名(預設一組織一管理員)
        /// ///</summary>
        public string? Manager_name { get; set; }
    }

}
