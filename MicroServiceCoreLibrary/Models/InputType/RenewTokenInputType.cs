namespace MicroServiceCoreLibrary.Models.InputType
{
    /// <summary>
    /// 刷新Token
    /// </summary>
    public class RenewTokenInputType
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// RefreshToken
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
