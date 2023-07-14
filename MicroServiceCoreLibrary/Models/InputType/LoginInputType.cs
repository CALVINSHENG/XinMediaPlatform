namespace MicroServiceCoreLibrary.Models.InputType
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginInputType
    {
        /// <summary>
        /// 登入Email
        /// </summary>
        public string? accountno { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        public string? password { get; set; }
    }
}
