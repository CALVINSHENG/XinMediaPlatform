using Bogus.DataSets;
using MicroServiceCoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.DbAccess.T4
{
    #region SonarLint Disabled 放置區域
#pragma warning disable IDE0044 // 新增唯讀修飾元
#pragma warning disable S4487 // Unread "private" fields should be removed
#pragma warning disable S2933 // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable IDE0052 // 刪除未讀取的私用成員
    #endregion

    public partial class LanguageCultureT4
    {
        string posts;
        /// <summary>
        /// Initializes a new instance of the <see cref="GenModelT4"/> class.
        /// </summary>
        /// <param name="posts">The posts.</param>
        public LanguageCultureT4(string posts)
        {
            this.posts = posts;
        }
    }
}
