#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#endregion

using MicroServiceCoreResposity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XinMedia.Models;
using XinMedia.Services.Interface;
using XinMediaService.Versions;

namespace XinMedia.Controllers.BackEnd
{
    /// <summary>
    /// 接口層
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    [Route("xin/api/DownStream/[action]")]
    [ApiExplorerSettings(GroupName = nameof(XinMedaiInfoVersion.v2))]
    public partial class XinMediaMemberController : ControllerBase
    {
        #region 建構子及全域設定暨變數
        /// <summary>
        /// The moduletemplate
        /// </summary>
        readonly IBackEnd _xinmedia;

        /// <summary>
        /// Initializes a new instance of the <see cref="XinMediaMemberController"/> class.
        /// 建構子
        /// </summary>
        /// <param name="xinmedia">The xinmedia.</param>
        public XinMediaMemberController(IBackEnd xinmedia)
        {
            _xinmedia = xinmedia;
        }
        #endregion

        #region 新增 HttpPost Method

        #endregion

        #region 查詢 HttpGet Method                
        /// <summary>
        /// Tests the member.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize]
        [Produces("application/json")]
        public DataResultModel<TArticleEntity> TestMember()
        {
            var result = _xinmedia.TestMember();

            return result;
        }
        #endregion

        #region 修改 HttpPut Method

        #endregion

        #region 刪除 HttpDelete Method

        #endregion
    }
}
