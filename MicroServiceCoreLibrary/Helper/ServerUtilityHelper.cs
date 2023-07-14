namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域
#pragma warning disable S125
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //警告 S125    Remove this commented out code.MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\NLogHelper.cs 148	作用中
#pragma warning disable CA1416
    //嚴重性	程式碼	說明	專案	檔案	行	隱藏項目狀態
    //警告 CA1416  可在所有平台上連線到此呼叫網站。只有 'windows' 支援 'WindowsIdentity.GetCurrent()'。	MicroServiceCoreLibrary C:\Users\calvinsheng\source\repos\GIT\CloudServicePlatform\MicroServiceCoreLibrary\Helper\ServerUtilityHelper.cs	48	作用中

    #endregion

    /// <summary>
    /// 本機資訊
    /// ServerUtilityHelper
    /// </summary>
    public static class ServerUtilityHelper
    {
        /// <summary>
        /// Gets the name of the local machine.
        /// Gets the name of the server.
        /// Windows 及 LINUX 都正常
        /// </summary>
        /// <returns></returns>
        public static string GetLocalMachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// Gets the name of the net DNS host.
        /// </summary>
        /// <returns></returns>
        public static string GetNetDnsHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        /// <summary>
        /// Gets the name of the envir variable computer.
        /// Windows 正常
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">無法取得本機電腦名稱</exception>
        public static string GetEnvirVariableComputerName()
        {

            return Environment.GetEnvironmentVariable("COMPUTERNAME")
                                            ?? throw new Exception("無法取得本機電腦名稱");
        }

        /// <summary>
        /// Gets the name of the server.
        /// </summary>
        /// <returns></returns>
        public static string GetServerName()
        {
            return Environment.MachineName;

            // Or can use
            // return System.Net.Dns.GetHostName();
            // return System.Windows.Forms.SystemInformation.ComputerName;
            // return System.Environment.GetEnvironmentVariable("COMPUTERNAME"); 
        }

        /// <summary>
        /// Gets the login account.
        /// </summary>
        /// <returns></returns>
        public static string GetLoginAccount()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// Gets the ip addresses.
        /// </summary>
        /// <returns></returns>
        public static string[] GetIpAddresses()
        {
            string hostName = GetServerName();

            return System.Net.Dns.GetHostAddresses(hostName).Select(i => i.ToString()).ToArray();
        }
    }
}
