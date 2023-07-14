using MicroServiceCoreConfiguration.Configuration;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Logger;
using MicroServiceCoreLibrary.Models.AuthLogin;
using MicroServiceCoreResposity.Entity;
using MicroServiceCoreResposity.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    #region SonarLint Disabled 放置區域

    #endregion

    public class TokenHelper : DoBase
    {
        #region 建構子、全域物件宣告、定義區(Log物件、驗證物件、變數、區隔符號)
        /// <summary>
        /// The baselogger
        /// </summary>
        private readonly ILogger<BaseLogger>? _baselogger;
        /// <summary>
        /// The authentication login helper
        /// </summary>
        readonly AuthLoginHelper _authLoginHelper;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenHelper"/> class.
        /// 建構子
        /// </summary>
        /// <param name="baselogger">The baselogger.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="authLoginHelper">The authentication login helper.</param>
        public TokenHelper(ILogger<BaseLogger> baselogger, IHttpContextAccessor httpContextAccessor, AuthLoginHelper authLoginHelper) : base(baselogger)
        {
            _baselogger = baselogger;
            _httpContextAccessor = httpContextAccessor;
            _authLoginHelper = authLoginHelper;
        }

        #endregion

        /// <summary>
        /// 檢驗Token 是否真實存在該用戶
        /// </summary>
        /// <returns></returns>
        public DataResultModel CheckTokenUserData()
        {
            DataResultModel model = new();
            try
            {
                if (_httpContextAccessor.HttpContext is not null)
                {
                    var principal = _authLoginHelper.GetClaimsFromExpiredToken(MSGetConfig.GetTokenSettings());
                    if (principal == null || string.IsNullOrWhiteSpace(principal.user_no))
                    {
                        model.Message = "查無使用者";
                        return model;
                    }

                    Dictionary<string, object> parameters = new()
                    {
                        { "@user_no", principal!.user_no! }
                    };
                    var listSQLStatment = "Select Top 1 * From Account Where Account.user_no = @user_no";
                    var data = Query<TAccount>(listSQLStatment, parameters);
                    if (data.DataList != null)
                    {
                        model.Result = true;
                        model.Message = data.DataList.Select(s => s.user_no).FirstOrDefault()!;
                    }
                }
            }
            catch (Exception ex)
            {
                StringBuilder ExceptionMessage = new(
                            NLogHelper.FetchCompleteMessage()
                        );
                _baselogger?.LogError(ex, ExceptionMessage.ToString());
                IsSuccess = false;
                Message = ExceptionMessage.ToString();
                model.Message = Message;
            }
            return model;
        }
    }
}
