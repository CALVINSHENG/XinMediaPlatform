using MicroServiceCoreLibrary.Models;
using MicroServiceCoreLibrary.Models.AuthLogin;
using MicroServiceCoreLibrary.Models.InputType;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    public class AuthLoginHelper
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthLoginHelper"/> class.
        /// 建構子
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public AuthLoginHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the claims from expired token.
        /// 解析Access Token 取得使用者基本資訊
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public ClaimsUserData GetClaimsFromExpiredToken(object obj)
        {
            var accessToken = _httpContextAccessor.HttpContext!.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return null!;
            }

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,   //是否驗證Issuer
                ValidateAudience = true, //是否驗證Audience
                ValidateLifetime = true,  //是否驗證失效時間
                ValidateIssuerSigningKey = true,//是否驗證IssuerSigningKey

                ValidIssuer = obj.GetType().GetProperty("Issuer")!.GetValue(obj)!.ToString(),
                ValidAudience = obj.GetType().GetProperty("Audience")!.GetValue(obj)!.ToString(),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(obj.GetType().GetProperty("Key")!.GetValue(obj)!.ToString()!)),
            };

            var jwtHandler = new JwtSecurityTokenHandler();
            var principal = jwtHandler.ValidateToken(accessToken, tokenValidationParameter, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken)
            {
                return null!;
            }

            var userData = new ClaimsUserData();
            foreach (var data in principal.Claims.ToArray())
            {
                switch (data.Type)
                {
                    case "User_No":
                        userData.user_no = data.Value;
                        break;
                    case "Name":
                        userData.user_name = data.Value;
                        break;
                    case "Company_No":
                        userData.company_no = data.Value;
                        break;
                    case "Company_Name":
                        userData.company_name = data.Value;
                        break;
                }
            }

            return userData;
        }

        /// <summary>
        /// Gets the JWT authentication key.
        /// 產生Access Token
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="groups">The groups.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetJWTAuthKey(TAccount account, List<TGroups> groups, object obj)
        {
            var securtityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(obj.GetType().GetProperty("Key")!.GetValue(obj)!.ToString()!));
            var credentials = new SigningCredentials(securtityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("User_No", account.user_no!),
                new Claim("Name", account.user_name!),
                new Claim("Company_No", account.company_no!),
                new Claim("Company_Name", account.company_name!)
            };
            if ((groups?.Count ?? 0) > 0)
            {
                foreach (var group in groups!)
                {
                    claims.Add(new Claim(ClaimTypes.Role, group.GROUP_NAME));
                }
            }

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: obj!.GetType().GetProperty("Issuer")!.GetValue(obj)!.ToString(),
                audience: obj!.GetType().GetProperty("Audience")!.GetValue(obj)!.ToString(),
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        /// <summary>
        /// Generates the refresh token.
        /// 產生Refresh Token
        /// </summary>
        /// <returns></returns>
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        /// <summary>
        /// Resigstrations the validations.
        /// 註冊-資料驗證
        /// </summary>
        /// <param name="registerInput">The register input.</param>
        /// <returns></returns>
        public static string ResigstrationValidations(RegisterInputType registerInput)
        {
            if (string.IsNullOrEmpty(registerInput.emailaddress))
            {
                return "Eamil can't be empty";
            }

            if (string.IsNullOrEmpty(registerInput.password)
                || string.IsNullOrEmpty(registerInput.confirmpassword))
            {
                return "Password Or ConfirmPasswor Can't be empty";
            }

            if (registerInput.password != registerInput.confirmpassword)
            {
                return "Invalid confirm password";
            }

            string emailRules = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            if (!Regex.IsMatch(registerInput.emailaddress, emailRules))
            {
                return "Not a valid email";
            }

            // atleast one lower case letter
            // atleast one upper case letter
            // atleast one special character
            // atleast one number
            // atleast 8 character length
            string passwordRules = @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";
            if (!Regex.IsMatch(registerInput.password, passwordRules))
            {
                return "Not a valid password";
            }

            return string.Empty;
        }

        /// <summary>
        /// Sets the cookie for refresh token.
        /// (set-Cookie refreshToken)
        /// </summary>
        /// <param name="refreshToken">The refresh token.</param>
        public void SetCookieForRefreshToken(string? refreshToken)
        {
            if (_httpContextAccessor.HttpContext is not null && !string.IsNullOrWhiteSpace(refreshToken))
            {
                CookieOptions options = new()
                {
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                    Secure = true,
                    Expires = DateTime.Now.AddDays(7),
                };
                _httpContextAccessor.HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, options);
            }
        }
    }
}
