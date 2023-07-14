namespace MicroServiceCoreResposity.DbAccess.T4_Run_Time
{
    /// <summary>
    /// partial class連動到RunTimeT4的Base Class
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.DbAccess.RunTimeT4.GenModelT4Base" />
    public partial class GenModelT4
    {
        string posts;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenModelT4"/> class.
        /// </summary>
        /// <param name="posts">The posts.</param>
        public GenModelT4(string posts)
        {
            this.posts = posts;
        }
    }
}
