#region SonarLint Disabled 放置區域
#pragma warning disable S4487 // Unread "private" fields should be removed
#pragma warning disable IDE0052 // 刪除未讀取的私用成員
#pragma warning disable CS8604 // 可能有 Null 參考引數。
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable S125 // Sections of code should not be commented out

#endregion

using Dapper;
using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreResposity.DbAccess.Helpers;
using MicroServiceCoreResposity.Entity;
using MicroServiceCoreResposity.Implementation;
using XinMedia.Models;
using XinMedia.Services.Interface;
using static MicroServiceCoreLibrary.Common.EnumDefineCommon;

namespace XinMedia.Services.FrontEnd
{
    /// <summary>
    /// 實作商業邏輯層
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Implementation.DoBase" />
    /// <seealso cref="XinMedia.Services.Interface.IFrontEnd" />
    public partial class FrontEndBusiness : DoBase, IFrontEnd
    {
        #region  建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號) 
        /// <summary>
        /// The baselogger
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Gets or sets the segmentsymbol.
        /// </summary>
        /// <value>
        /// The segmentsymbol.
        /// </value>
        private static string? SEGMENTSYMBOL { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrontEndBusiness"/> class.
        /// 建構子
        /// </summary>
        /// <param name="baselogger">The baselogger.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public FrontEndBusiness(
            ILogger<BaseLogger>? baselogger
            , IHttpContextAccessor httpContextAccessor)
            : base(baselogger)
        {
            _baselogger = baselogger;
            _httpContextAccessor = httpContextAccessor;

            SEGMENTSYMBOL = new GetConfigHelper()
                                .GetConfig(
                                    ConfigTargetType.ServiceDefault
                                    , "SegmentSymbol:EventCodeSegmentSymbol"
                                );
        }
        #endregion

        #region 主程序程式碼放置區        
        /// <summary>
        /// Tests this instance.
        /// </summary>
        /// <returns></returns>
        public DataResultModel<TArticleEntity> Test()
        {
            var result = new DataResultModel<TArticleEntity>();

            using var conn = MSGetConfig.AutoEstablishConnection();
            //using var conn = new MySqlConnection("Server =13.70.31.96;Port=3306;Database=xinmedia_solomo;Uid=root;Pwd=Tw#maria88;");

            string query = "SELECT * FROM articles LIMIT 100";
            var results = conn.Query<TArticleEntity>(query).ToList();
            if (results.Count > 0)
            {
                result = new DataResultModel<TArticleEntity>()
                {
                    StatusCode = "200",
                    Message = "success",
                    DataList = results
                };
            }

            return result;
        }
        #endregion

        #region 子程序程式碼放置區

        #endregion
    }
}