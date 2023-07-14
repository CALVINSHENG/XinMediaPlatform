using DocumentFormat.OpenXml.Spreadsheet;
using Iced.Intel;
using MongoDB.Bson;
using Newtonsoft.Json;
using NLog;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S125
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //警告 S125    Remove this commented out code.MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\NLogHelper.cs 148	作用中
#pragma warning disable S3427
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //警告 S3427   This method signature overlaps the one defined on line 127, the default parameter value can't be used.	MicroServiceCoreLibrary	C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\NLogHelper.cs	166	作用中
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
#pragma warning disable CS8601 // 可能有 Null 參考指派。
#pragma warning disable S3445 // Exceptions should not be explicitly rethrown
#pragma warning disable CA2200 // 重新擲回以保存堆疊詳細資料

    #endregion

    /// <summary>
    /// NLogHelper
    /// </summary>
    public static class NLogHelper
    {
        /// <summary>
        /// CurrentMethodTraceInfo
        /// </summary>
        public static class CurrentMethodTraceInfo
        {
            /// <summary>
            /// Gets the name space.
            /// 取得當前方法類別空間名稱
            /// </summary>
            /// <returns></returns>
            public static String GetNameSpace()
            {
                string? logMessage = "";
                logMessage += "命名空間名稱:" + MethodBase.GetCurrentMethod()?.DeclaringType?.Namespace + "\n";

                return logMessage;
            }

            /// <summary>
            /// Gets the full name.
            /// 取得當前類別名稱
            /// </summary>
            /// <returns></returns>
            public static String GetFullName()
            {
                string? logMessage = "";
                logMessage += "類別名稱:" + MethodBase.GetCurrentMethod()?.DeclaringType?.FullName + "\n";

                return logMessage;
            }

            /// <summary>
            /// Gets the name.
            /// 取得當前所使用的方法
            /// </summary>
            /// <returns></returns>
            public static String GetName()
            {
                string? logMessage = "";
                logMessage += "使用的方法:" + MethodBase.GetCurrentMethod()?.DeclaringType?.FullName + "\n";

                return logMessage;
            }
        }

        /// <summary>
        /// 取得當前方法類別空間名稱
        /// </summary>
        public static class GetParentTraceInfo
        {
            //取得當前方法類別空間名稱
            public static String GetNameSpace()
            {
                StackTrace ss = new() { };
                MethodBase? mb = ss?.GetFrame(1)?.GetMethod();

                string? logMessage = "";
                logMessage += "使用的命名空間名稱：" + mb?.DeclaringType?.Namespace + "\n";

                return logMessage;
            }

            //取得呼叫當前方法之上一層類別(父方)的Full class Name
            public static String GetFullName()
            {
                StackTrace ss = new() { };
                MethodBase? mb = ss?.GetFrame(1)?.GetMethod();

                string? logMessage = "";
                logMessage += "使用的完整類別名稱：" + mb?.DeclaringType?.FullName + "\n";

                return logMessage;
            }

            /// <summary>
            /// Gets the name.
            /// 取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
            /// </summary>
            /// <returns></returns>
            public static String GetName()
            {
                StackTrace ss = new() { };
                MethodBase? mb = ss?.GetFrame(1)?.GetMethod();

                string? logMessage = "";
                logMessage += "使用的類別名稱：" + mb?.DeclaringType?.Name + "\n";

                return logMessage;
            }

            /// <summary>
            /// Gets the name of the function.
            /// </summary>
            /// <returns></returns>
            public static String GetFunctionName()
            {
                StackTrace ss = new() { };
                MethodBase? mb = ss?.GetFrame(1)?.GetMethod();

                string? logMessage = "";
                logMessage += "使用的方法名稱：" + mb?.Name + "\n";

                return logMessage;
            }
        }

        /// <summary>
        /// Stacks the trace.
        /// </summary>
        /// <returns></returns>
        public static string StackTrace()
        {
            String extraShowString = "";

            StackTrace ss = new(true) { };
            //取得呼叫當前方法之上一層類別(GetFrame(1))的屬性
            extraShowString += "Stack trace for current level：" + ss?.ToString() + "\n";
            StackFrame? sf = ss?.GetFrame(0);
            extraShowString += "File：" + sf?.GetFileName() + "\n";
            extraShowString += "Method：" + sf?.GetMethod()?.Name + "\n";
            extraShowString += "Line Number：" + sf?.GetFileLineNumber() + "\n";
            extraShowString += "Column Number：" + sf?.GetFileColumnNumber() + "\n";

            return extraShowString;
        }
        /// <summary>
        /// Fetches the complete message.
        /// 取得完整訊息
        /// </summary>
        /// <returns></returns>
        public static string FetchCompleteMessage()
        {
            List<string> list = new() { };
            /*
            * 編輯作者：ADD BY CALVIN AT 2023/12/07
            * 說明：
            * 1.直接輸出完整訊息
            * 2.返回呼叫點後再自行決定串接其他資訊
            */
            //StringBuilder Message = new
            //                (
            //                    "執行日誌Stack：\\r\\n" +
            //                    GetParentTraceInfo.GetFullName() +
            //                    GetParentTraceInfo.GetNameSpace() +
            //                    GetParentTraceInfo.GetFunctionName() +
            //                    GetParentTraceInfo.GetName() +
            //                    "\\r\\n程序追蹤：\\r\\n" +
            //                    StackTrace() +
            //                    "\\r\\n"
            //                );
            //return Message.ToString();
            list.Add("執行日誌Stack： ");
            list.Add(GetParentTraceInfo.GetFullName());
            list.Add(GetParentTraceInfo.GetNameSpace());
            list.Add(GetParentTraceInfo.GetFunctionName());
            list.Add(GetParentTraceInfo.GetName());
            list.Add(string.Empty);

            var responsed = String.Join("●", list.ToArray());

            return responsed;
        }
        /// <summary>
        /// Fetches the complete message.
        /// 取得完整訊息
        /// Use For LogError
        /// </summary>
        /// <param name="IsNeedStackTrace">if set to <c>true</c> [is need stack trace].</param>
        /// <returns></returns>
        public static string FetchCompleteMessage(bool IsNeedStackTrace = false)
        {
            List<string> list = new() { };
            /*
            * 編輯作者：ADD BY CALVIN AT 2023/12/07
            * 說明：
            * 1.直接輸出完整訊息
            * 2.返回呼叫點後再自行決定串接其他資訊
            */
            //StringBuilder Message = new
            //                (
            //                    "執行日誌Stack：\\r\\n" +
            //                    GetParentTraceInfo.GetFullName() +
            //                    GetParentTraceInfo.GetNameSpace() +
            //                    GetParentTraceInfo.GetFunctionName() +
            //                    GetParentTraceInfo.GetName() +
            //                    "\\r\\n程序追蹤：\\r\\n" +
            //                    StackTrace() +
            //                    "\\r\\n"
            //                );
            //return Message.ToString();
            list.Add("執行日誌Stack： ");
            list.Add(GetParentTraceInfo.GetFullName());
            list.Add(GetParentTraceInfo.GetNameSpace());
            list.Add(GetParentTraceInfo.GetFunctionName());
            list.Add(GetParentTraceInfo.GetName());
            list.Add(string.Empty);
            list.Add("程序追蹤： ");
            if (IsNeedStackTrace)
            {
                list.Add(StackTrace());
            }

            var responsed = String.Join("●", list.ToArray());

            return responsed;
        }

        /// <summary>
        /// Fetches the complete message.
        /// 取得完整訊息
        /// 新版：取得系統錯誤代碼
        /// Use For DataResultModel/Message
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="appendResult">The append result.</param>
        /// <returns></returns>
        public static string FetchCompleteMessage(Exception ex, string appendResult = "發生例外錯誤")
        {
            /*
            * 編輯作者：ADD BY CALVIN AT 2023/12/07
            * 說明：
            * 1.直接輸出完整訊息
            * 2.返回呼叫點後再自行決定串接其他資訊
            */
            StringBuilder Message = new
                            (
                                "執行日誌Stack：\r\n" +
                                GetParentTraceInfo.GetFullName() +
                                GetParentTraceInfo.GetNameSpace() +
                                GetParentTraceInfo.GetFunctionName() +
                                GetParentTraceInfo.GetName() +
                                "\r\n程序追蹤：\r\n" +
                                StackTrace() +
                                "\r\n"
                            )
            { };

            var errorCode = ex.HResult;

            return appendResult
                + "\r\n\r\n"
                + "錯誤代碼：" + errorCode
                + "\r\n\r\n"
                + Message.ToString()
                + "\r\n"
                + "例外訊息："
                + "\r\n"
                + ex.Message;
        }
        /// <summary>
        /// Gets the user log message.
        /// </summary>
        /// <returns></returns>
        public static string GetUserLogMessage()
        {
            string message;

            message = "紀錄編號: {guid}    " +
                "使用者編號: {user_no}    " +
                "使用SQL語法: {sql_commands}     " +
                "使用SQL參數: {sql_params}    " +
                "系統訊息: {completed_Message}";

            return message;
        }
        /// <summary>
        /// Gets the user log parameters.
        /// </summary>
        /// <param name="user_no">The user no.</param>
        /// <param name="completed_message">The completed message.</param>
        /// <param name="sql_commands">The SQL commands.</param>
        /// <param name="sql_params">The SQL parameters.</param>
        /// <returns></returns>
        public static string[] GetUserLogParams(string? user_no = null, string? completed_message = null, string? sql_commands = null, object? sql_params = null)
        {
            string[] log;

            try
            {
                string guid = GetGUID();
                string sql_paramss = string.Empty;
                string sql_commandss = string.Empty;

                if (sql_commands is not null)
                {
                    int sql_count = 1;
                    string[] sql_command = sql_commands.Split(';');

                    if (sql_command.Count() > 2)
                    {
                        foreach (var sql in sql_command)
                        {
                            if (sql is not null && sql != "")
                            {
                                sql_commandss += "第 " + sql_count.ToString() + " 筆SQL語法：" + sql.ToString() + ";" + Environment.NewLine;
                                sql_count++;
                            }
                        }
                    }
                    else
                    {
                        sql_commandss = sql_command[0];
                    }

                    if (sql_params is not null)
                    {
                        // Object轉為Json格式並轉換為String
                        var settings = new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        };
                        sql_paramss = JsonConvert.SerializeObject(sql_params, Formatting.Indented, settings);
                    }
                }
                log = new string[] { guid, user_no, sql_commandss, sql_paramss, completed_message };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return log;
        }
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns></returns>
        private static string GetGUID()
        {
            string guid = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            guid = ReplaceMutiple(guid, "-:.;,");

            return guid;
        }
        /// <summary>
        /// Replaces the mutiple.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private static string ReplaceMutiple(string input, string pattern)
        {
            var result = Regex.Replace(input, pattern, "");

            return result;
        }
    }
}