namespace MicroServiceCoreLibrary.Models.InputType
{
#pragma warning disable IDE1006 // 命名樣式
    /// <summary>
    /// 帳號註冊
    /// </summary>
    public class RegisterInputType
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// EMail
        /// </summary>
        public string? emailaddress { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string? account_no { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string? password { get; set; }

        /// <summary>
        /// 重新確認密碼
        /// </summary>
        public string? confirmpassword { get; set; }
    }
}
