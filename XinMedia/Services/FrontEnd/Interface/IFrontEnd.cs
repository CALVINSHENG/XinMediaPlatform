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
    public interface IFrontEnd
    {
        /// <summary>
        /// Tests this instance.
        /// </summary>
        /// <returns></returns>
        public DataResultModel<TArticleEntity> Test();
    }
}