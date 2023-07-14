#region SonarLint Disabled 放置區域
#pragma warning disable S3267
// Remove this commented out code
#pragma warning disable S125
//Refactor your code not to use hardcoded absolute paths or URls.
#pragma warning disable CS8604
// Re-enable the warning.
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#pragma warning disable VSSpell001 // Spell Check
#endregion

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MailKit.Security;
using MicroServiceCoreResposity.DbAccess.Helpers;
using MicroServiceCoreResposity.DbAccess.T4_Design_Time;
using MicroServiceCoreResposity.Models;
using MimeKit;
using System.Text.RegularExpressions;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace MicroServiceCoreLibrary.Helper
{
    /// <summary>
    /// MailType
    /// </summary>
    public enum MailType
    {
        //呼叫寄信Type

        //邀請成員
        //罐頭訊息MAIL 601
        Invite_MAIL_00001
    }

    /// <summary>
    /// SendMailHelper
    /// </summary>
    public class SendMailHelper
    {
        #region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
        /// <summary>
        /// Gets or sets the segmentsymbol.
        /// </summary>
        /// <value>
        /// The segmentsymbol.
        /// </value>
        private static string? SEGMENTSYMBOL { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMailHelper"/> class.
        /// </summary>
        public SendMailHelper()
        {
            SEGMENTSYMBOL = new GetConfigHelper()
                                .GetConfig(
                                    ConfigTargetType.ServiceDefault
                                    , "SegmentSymbol:EventCodeSegmentSymbol"
                                );
        }

        #endregion
        /*
        * 編輯作者 : ADD BY Shan AT 2023/01/03
        * 說    明 : 
        * 1. 使用GmailAPI 發信(搭配Oauth2)
        * 2. GmailAPI 自2022/05/31後關閉低安全性應用程式訪問，需使用Oauth2驗證方能使用。 
        * 備    註 : 需安裝套件 : mailkit 、 Google.Apis.Auth(GmailAPI 驗證)
        *            使用套件的Function含有 async，在呼叫的function中需另建立實體物件。
        * 修改歷程 : 
        * 2022/01/07 初版
        */

        // Gmail API Oauth 管理員帳號
        private readonly string systemAccount = "xuanlu0424@gmail.com";
        // Gmail API  Oauth 客戶端ID
        private readonly string _clientId = "1042795979984-48mik703n57tt4vl64m2bocqilv0drbt.apps.googleusercontent.com";
        // Gmail API  Oauth 客戶端金鑰
        private readonly string _clientSecret = "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";

        //Mail Server
        private readonly string _stepName = "smtp.gmail.com";
        private readonly int _stepPort = 587;

        /*
       * 編輯作者 : ADD BY Shan AT 2023/01/12
       * 說    明 : 
       * 1. 自呼叫函式接收參數並組合資料 到 Models.MailModel
       * 2. 呼叫 Send() 寄信       
       * 
       * 備    註 : 
       * 修改歷程 : 
       * 2022/01/12 初版
       */

        /// <summary>
        /// Sends the system email.
        /// 寄送系統信：通知權限開啟
        /// </summary>
        /// <param name="mailModel">The mail model.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public Task SendSystemEmail(MailModel mailModel, MailType type)
        {
            /*
            * 編輯作者：REMARK BY Shan AT 2023/01/12
            * 說明：
            * 1. 處理 to_Address、cc、bcc、reply_to等陣列型態資料轉成 List (Model需要)
            */
            switch (type)
            {
                // 員工邀請系統信
                case MailType.Invite_MAIL_00001:
                    // 必填收件人地址、名稱
                    if (mailModel.To_Name == null || mailModel.To_Address == null)
                    {
                        break;
                    }
                    //公司名稱
                    if (mailModel.Company_name == null || mailModel.Company_name == "")
                    {
                        // 經討論暫由前端提供
                        break;
                    }
                    //URL產出
                    if (mailModel.Url == null || mailModel.Url == "")
                    {
                        // 產出信件所需連結
                        // 經討論先以hardcode方式處理
                        mailModel.Url = "https://lionexpress.bus.eldplat.com";
                    }
                    //回復收件人
                    if (mailModel.ReplyTo_Address == null)
                    {
                        // 管理員帳號?
                        // 經討論暫由前端提供
                    }
                    // 主旨
                    if (mailModel.Subject == null || mailModel.Subject == "")
                    {
                        if (mailModel.Company_name != null)
                        {
                            mailModel.Subject = MailMessageVersion.PermisssionOpenedSub(mailModel.Company_name);
                        }
                        else
                        {
                            break;
                        }
                    }
                    // 內文
                    if (mailModel.TextBody == null || mailModel.TextBody == "")
                    {
                        //罐頭訊息: Mail_601, 並帶入參數 username, manager name, company name, url, account, pwd
                        mailModel.TextBody = MailMessageVersion.PermissionOpenedMessage(mailModel.To_Name, mailModel.Manager_name, mailModel.Company_name, mailModel.Url, mailModel.To_Name, mailModel.User_Pwd);
                    }
                    break;

            }

            _ = Send(mailModel);

            return Task.CompletedTask;
        }

        /*
        * 編輯作者 : ADD BY Shan AT 2023/01/08
        * 說    明 : 
        * 1. 使用GmailAPI 發信(搭配Oauth2)
        * 2. 接收Models.MailModel資料，再發信
        * 備    註 : 需安裝套件 : mailkit 、 Google.Apis.Auth(GmailAPI 驗證)
        *            使用套件的Function含有 async，在呼叫的function中需另建立實體物件。
        *            必帶入參數 ： 收件者、內容，其餘可不填(須帶入null)，不可傳入空字串。
        * 修改歷程 : 
        * 2022/01/07 初版
        * 2022/01/12 EDIT BY Shan
        *       說明 : 組成資料傳進MailModel改在底層進行
        */

        /// <summary>
        /// Sends the specified maildata.
        /// </summary>
        /// <param name="maildata">The maildata.</param>
        /// <exception cref="System.NotImplementedException">Send Email Wrong:</exception>
        private async Task Send(MailModel maildata)
        {
            /*
             *  編輯作者: REMARK BY Shan AT 2023/01/07
             *  說明：
             *  1. GmailAPI 自2022/05/31後關閉低安全性應用程式訪問，需使用Oauth2驗證方能使用。 
             *  2. Oauth2 的處理流程：CodeFlow，基本上保持這樣不需調整 
             *  3. 日後改為公司 smtp 再確認是否留存
             */

            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = _clientId,
                    ClientSecret = _clientSecret
                };

                var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    DataStore = new FileDataStore("CredentialCacheFolder", false),
                    Scopes = new[] { "https://mail.google.com" },
                    ClientSecrets = clientSecrets
                });

                var codeReceiver = new LocalServerCodeReceiver();
                var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

                var credential = await authCode.AuthorizeAsync(systemAccount, CancellationToken.None);

                if (credential.Token.IsExpired(SystemClock.Default))
                {
                    await credential.RefreshTokenAsync(CancellationToken.None);
                }
                var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);


                // 寄信流程
                /*
                *  編輯作者: REMARK BY Shan AT 2023/01/04
                *  說明：
                *  1. 寄信流程 
                *  2. 收件者、信件內容為必填
                *  3. 寄件者、主旨、皆有預設系統，參數可為null
                */

                //信件主體
                var message = new MimeMessage();

                //寄件者名稱、信箱(預設為系統帳號)
                if (maildata.From_Address != null && EmailIsValid(maildata.From_Address))
                {
                    message.From.Add(new MailboxAddress(maildata.From, maildata.From_Address));
                }

                //收件者名稱、收件者信箱(必填)

                if (maildata.To_Address != null)
                {
                    message.To.Add(new MailboxAddress(maildata.To_Name, maildata.To_Address));
                }
                else if (maildata.To_AddressList != null)
                {
                    int i = 0;
                    foreach (var address in maildata.To_AddressList)
                    {
                        if (EmailIsValid(address))
                        {
                            _ = address.Replace(" ", "");
                            message.To.Add(new MailboxAddress(maildata.To_NameList[i], address));
                        }
                        i += 1;
                    }
                }

                //副本
                if (maildata.Cc != null)
                {
                    message.Cc.Add(new MailboxAddress("", maildata.Cc));
                }
                else if (maildata.CcList != null)
                {
                    foreach (var cc in maildata.CcList)
                    {
                        if (EmailIsValid(cc))
                        {
                            _ = cc.Replace(" ", "");
                            message.Cc.Add(new MailboxAddress("", cc));
                        }
                    }
                }

                //密件副本
                if (maildata.Bcc != null)
                {
                    message.Bcc.Add(new MailboxAddress("", maildata.Bcc));
                }
                else if (maildata.BccList != null)
                {
                    foreach (var bcc in maildata.BccList)
                    {
                        if (EmailIsValid(bcc))
                        {
                            _ = bcc.Replace(" ", "");
                            message.Bcc.Add(new MailboxAddress("", bcc));
                        }
                    }
                }

                //信件標題(必填)
                if (maildata.Subject != null)
                {
                    message.Subject = maildata.Subject;
                }

                //信件內容(必填)
                if (!string.IsNullOrEmpty(maildata.TextBody) || !string.IsNullOrEmpty(maildata.HtmlBody))
                {
                    var mailbody = new BodyBuilder
                    {
                        //純文本
                        TextBody = maildata.TextBody,
                        //html : html文件
                        HtmlBody = maildata.HtmlBody
                    };

                    //附件
                    if (maildata.Attachment != null)
                    {
                        string filepath = @"{0}";
                        mailbody.Attachments.Add(string.Format(filepath, maildata.Attachment));
                    }
                    else if (maildata.AttachmentList != null)
                    {
                        foreach (var attachment in maildata.AttachmentList)
                        {
                            string filepath = @"{0}";
                            mailbody.Attachments.Add(string.Format(filepath, attachment));
                        }
                    }

                    message.Body = mailbody.ToMessageBody();
                }

                //回覆信件收件人
                if (maildata.ReplyTo_Address != null)
                {
                    message.ReplyTo.Add(new MailboxAddress("EldPlat", maildata.ReplyTo_Address));
                }
                else if (maildata.ReplyTo_AddressList != null)
                {
                    foreach (var replyto_email in maildata.ReplyTo_AddressList)
                    {
                        if (EmailIsValid(replyto_email))
                        {
                            _ = replyto_email.Replace(" ", "");
                            message.ReplyTo.Add(new MailboxAddress("EldPlat", replyto_email));
                        }
                    }
                }

                //連接GmailAPI，驗證並傳送
                using var client = new MailKit.Net.Smtp.SmtpClient();
                await client.ConnectAsync(_stepName, _stepPort);
                await client.AuthenticateAsync(oauth2);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                //return ("Success");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Send Email Wrong:", ex);
            }
        }

        /*
        * 編輯作者 : ADD BY Shan AT 2023/01/07
        * 說    明 : 
        * 1. GmailAPI 發信測試 不使用Oauth2
        * 2. GmailAPI 自2022/05/31後關閉低安全性應用程式訪問，需使用Oauth2驗證方能使用。
        * 3. 不搭配Oauth2，Gmail目前無法使用，待公司mail設定出來再繼續實作。
        * 備    註 : 需安裝套件 : mailkit 
        * 修改歷程 : 
        * 2022/01/04 初版
        */
        /// <summary>
        /// Sends the email without oauth.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public static void SendEmailWithoutOauth()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("ShanTest1", "xuanyulyu@liontravel.com"));
                message.To.Add(new MailboxAddress("Xuan", "xuanyulyu@liontravel.com"));
                message.Subject = "Test Email Without Oauth2";
                message.Body = new TextPart("plain")
                {
                    Text = "Test Email Without Oauth2's content"
                };

                using var client = new MailKit.Net.Smtp.SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("xuanlu0424@gmail.com", "shanyuYZU", default);
                client.Send(message);

                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new NotImplementedException();
            }
        }

        /*
       * 編輯作者 : ADD BY Shan AT 2023/01/08
       * 說    明 : 郵件地址正則表達式驗證
       * 備    註 : 
       * 修改歷程 : 
       * 2022/01/08 初版
       */
        /// <summary>
        /// Emails the is valid.
        /// </summary>
        /// <param name="emailaddress">The emailaddress.</param>
        /// <returns></returns>
        private static bool EmailIsValid(string emailaddress)
        {
            try
            {
                Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(emailaddress);
                if (match.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*
       * 編輯作者 : ADD BY Shan AT 2023/01/17
       * 說    明 : 信件內文、主旨罐頭訊息處理
       * 備    註 : 
       * 修改歷程 : 
       * 2022/01/17 初版
       */
        /// <summary>
        /// MailMessageVersion
        /// </summary>
        public static class MailMessageVersion
        {
            /// <summary>
            /// Permissions the opened message.
            /// Email罐頭訊息：601 創建會員資料(內文)
            /// </summary>
            /// <param name="username">The username.</param>
            /// <param name="managername">The managername.</param>
            /// <param name="companyname">The companyname.</param>
            /// <param name="url">The URL.</param>
            /// <param name="useraccount">The useraccount.</param>
            /// <param name="userpwd">The userpwd.</param>
            /// <returns></returns>
            public static string PermissionOpenedMessage(string username, string managername, string companyname, string url, string useraccount, string userpwd)
            {
                string message = EventCode.MAIL_00001.Split(SEGMENTSYMBOL)[2];
                string v = string.Format(message, username, managername, companyname, url, useraccount, userpwd);
                message = v;
                return message;
            }

            /// <summary>
            /// Permisssions the opened sub.
            /// Email罐頭訊息：6011 創建會員資料(主旨)
            /// </summary>
            /// <param name="companyname">The companyname.</param>
            /// <returns></returns>
            public static string PermisssionOpenedSub(string companyname)
            {
                string subject = EventCode.MAIL_00002.Split(SEGMENTSYMBOL)[2];
                string v = string.Format(subject, companyname);
                return v;
            }
        }
    }
}
