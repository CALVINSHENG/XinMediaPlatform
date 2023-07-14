using System.Diagnostics;
using System.Reflection;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S3458 // Empty "case" clauses that fall through to the "default" should be omitted
    #endregion

    /// <summary>
    /// DempReflectionHelper
    /// </summary>
    public static class DempReflectionHelper
    {
        /// <summary>
        /// 取得 目前正在執行的 Function Info 資訊：
        /// <para>　1：取得當前方法類別命名空間名稱+取得當前類別名稱+取得當前所使用的方法</para>
        /// <para>　2：取得當前類別名稱+取得當前所使用的方法</para>
        /// <para>　3：取得當前所使用的方法</para>　　
        /// <para>　4：取得當前類別名稱</para>
        /// <para>　5：取得當前方法類別命名空間名稱</para>
        /// <para>執行結果範例：</para>
        /// <para>MicroServices.MemberShip.Repository.Implementation-DoBase-public IResultModel＜T＞Query＜T＞(string cmd, IDictionary＜string, object＞ parameters)</para>
        /// <para>info: MicroServices.MemberShip.Lib.Logger.BaseLogger[1002]</para>
        /// <para>　　　　　　執行日誌Stack：</para>
        /// <para>　　　命名空間名稱：MicroServices.MemberShip.Lib.Helper</para>
        /// <para>　　　類別名稱：MicroServices.MemberShip.Lib.Helper.DempReflectionHelper</para>
        /// <para>　　　使用的方法：GetCurrentMethodTraceInfo</para>
        /// </summary>
        /// <param name="modelWay">資訊組合(modelWay：1-5；預設１)</param>
        /// <returns>資訊組合</returns>
        public static String GetCurrentMethodTraceInfo(int modelWay = 1)
        {
            string? showString = "";

            switch (modelWay)
            {
                default:
                    //取得當前方法類別命名空間名稱
                    showString += "命名空間名稱：" + MethodBase.GetCurrentMethod()?.DeclaringType?.Namespace + "\n";
                    //取得當前類別名稱
                    showString += "類別名稱：" + MethodBase.GetCurrentMethod()?.DeclaringType?.FullName + "\n";
                    //取得當前所使用的方法
                    showString += "使用的方法：" + MethodBase.GetCurrentMethod()?.Name + "\n";
                    break;

                case 2:
                    //取得當前類別名稱
                    showString += "類別名稱：" + MethodBase.GetCurrentMethod()?.DeclaringType?.FullName + "\n";
                    //取得當前所使用的方法
                    showString += "使用的方法：" + MethodBase.GetCurrentMethod()?.Name + "\n";
                    break;

                case 3:
                    //取得當前所使用的方法
                    showString += "使用的方法：" + MethodBase.GetCurrentMethod()?.Name + "\n";
                    break;

                case 4:
                    //取得當前類別名稱
                    showString += "類別名稱：" + MethodBase.GetCurrentMethod()?.DeclaringType?.FullName + "\n";
                    break;

                case 5:
                    //取得當前方法類別命名空間名稱
                    showString += "命名空間名稱：" + MethodBase.GetCurrentMethod()?.DeclaringType?.Namespace + "\n";
                    break;
            }

            return showString;
        }

        /// <summary>
        /// 取得父類別的相關資訊(共用的Functiond可用)：
        /// <para>　1：上一層類別(父方) 命名空間名稱+function 所屬class Name+Full class Name+Function Name</para>
        /// <para>　2：上一層類別(父方) function 所屬class Name+Full class Name+Function Name</para>
        /// <para>　3：上一層類別(父方) function Full class Name+Function Name</para>
        /// <para>　4：上一層類別(父方) Function Name</para>
        /// <para>執行結果範例：</para>
        /// <para>MicroServices.MemberShip.Repository.Implementation/DoBase/public IResultModel＜T＞ Query＜T＞(string cmd, IDictionary＜string, object＞ parameters)</para>
        /// <para>　　crit: MicroServices.MemberShip.Lib.Logger.BaseLogger[1002]</para>
        /// <para>　　　　　執行日誌Stack：</para>
        /// <para>　　使用的命名空間名稱：MicroServices.MemberShip.Repository.Implementation</para>
        /// <para>　　使用的類別名稱：DoBase</para>
        /// <para>　　使用的完整類別名稱：MicroServices.MemberShip.Repository.Implementation.DoBase</para>
        /// <para>　　使用的方法名稱：Query</para>
        /// </summary>
        /// <param name="modelWay">資訊組合(modelWay：1-4；預設１)</param>
        /// <returns>資訊組合</returns>
        public static String GetParentTraceInfo(int modelWay = 1)
        {
            String showString = "";

            StackTrace ss = new StackTrace(true);
            //取得呼叫當前方法之上一層類別(GetFrame(1))的屬性
            MethodBase? mb = ss?.GetFrame(1)?.GetMethod();
            switch (modelWay)
            {
                case 1:
                default:
                    //取得呼叫當前方法之上一層類別(父方)的命名空間名稱
                    showString += "使用的命名空間名稱：" + mb?.DeclaringType?.Namespace + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
                    showString += "使用的類別名稱：" + mb?.DeclaringType?.Name + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的Full class Name
                    showString += "使用的完整類別名稱：" + mb?.DeclaringType?.FullName + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的Function Name
                    showString += "使用的方法名稱：" + mb?.Name + "\n";
                    break;

                case 2:
                    //取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
                    showString += "使用的類別名稱：" + mb?.DeclaringType?.Name + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的Full class Name
                    showString += "使用的完整類別名稱：" + mb?.DeclaringType?.FullName + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的Function Name
                    showString += "使用的方法名稱：" + mb?.Name + "\n";
                    break;

                case 3:
                    //取得呼叫當前方法之上一層類別(父方)的Full class Name
                    showString += "使用的完整類別名稱：" + mb?.DeclaringType?.FullName + "\n";
                    //取得呼叫當前方法之上一層類別(父方)的Function Name
                    showString += "使用的方法名稱：" + mb?.Name + "\n";
                    break;

                case 4:
                    //取得呼叫當前方法之上一層類別(父方)的Function Name
                    showString += "使用的方法名稱：" + mb?.Name + "\n";
                    break;
            }

            return showString + "=========\n" + GetStackTrace();
        }

        /// <summary>
        /// Gets the stack trace.
        /// </summary>
        /// <returns></returns>
        public static string GetStackTrace()
        {
            String extraShowString = "";

            StackTrace ss = new StackTrace(true);
            //取得呼叫當前方法之上一層類別(GetFrame(1))的屬性
            extraShowString += "Stack trace for current level：" + ss?.ToString() + "\n";
            StackFrame? sf = ss?.GetFrame(0);
            extraShowString += "File：" + sf?.GetFileName() + "\n";
            extraShowString += "Method：" + sf?.GetMethod()?.Name + "\n";
            extraShowString += "Line Number：" + sf?.GetFileLineNumber() + "\n";
            extraShowString += "Column Number：" + sf?.GetFileColumnNumber() + "\n";

            return extraShowString;
        }
    }
}