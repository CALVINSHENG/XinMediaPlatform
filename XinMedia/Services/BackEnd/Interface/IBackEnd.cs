#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreResposity.Entity;
using XinMedia.Models;

namespace XinMedia.Services.Interface
{
    /// <summary>
    /// 介面層
    /// </summary>
    public interface IBackEnd
    {
        /// <summary>
        /// Tests the member.
        /// </summary>
        /// <returns></returns>
        public DataResultModel<TArticleEntity> TestMember();
    }
}