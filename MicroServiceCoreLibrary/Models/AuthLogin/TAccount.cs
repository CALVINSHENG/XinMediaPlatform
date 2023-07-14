using Bogus.DataSets;
using System.Configuration;
using MicroServiceCoreLibrary.Attributes.Extensions;
using MicroServiceCoreLibrary.Attributes;
using System.Xml.Linq;

namespace MicroServiceCoreLibrary.Models.AuthLogin
{
#pragma warning disable IDE1006 // 命名樣式
    /// <summary>
    /// 帳號主表
    /// </summary>
    public class TAccount
    {
        public int NO { get; set; }
        /// <summary>
        /// 使用者代碼
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "USER_NO", EnDeSignal = false)]
        public string? user_no { get; set; }

        /// <summary>
        /// 使用者身分證號
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 20, MaxLength = 20)]
        [NeedEnDecript(FieldName = "STAFF_NO", EnDeSignal = true)]
        public string? staff_no { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "USER_NAME", EnDeSignal = false)]
        public string? user_name { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "ACCOUNT", EnDeSignal = false)]
        public string? account_no { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 100)]
        [NeedEnDecript(FieldName = "PASSWORD", EnDeSignal = true)]
        public string? password { get; set; }

        public string? re_token { get; set; }
        public DateTime? exp_token { get; set; }

        /// <summary>
        /// 使用者出生日期
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{};'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "BIRTHDAY", EnDeSignal = true)]
        public string? birthday { get; set; }
        /// <summary>
        /// 使用者性別
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 1)]
        [NeedEnDecript(FieldName = "SEX", EnDeSignal = false)]
        public string? sex { get; set; }
        /// <summary>
        /// 使用者電子郵件
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!#$%^&*()[]{}/;'\"|\\", MinLength = 2, MaxLength = 20)]
        [NeedEnDecript(FieldName = "EMAIL", EnDeSignal = true)]
        public string? user_email { get; set; }
        /// <summary>
        /// 使用者手機號碼
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "PHONE", EnDeSignal = true)]
        public string? phone { get; set; }
        /// <summary>
        /// 使用者室內電話號碼
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "TEL", EnDeSignal = true)]
        public string? tel { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "PLFTYP", EnDeSignal = false)]
        public string? plftyp { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 1)]
        [NeedEnDecript(FieldName = "USER_STATUS", EnDeSignal = false)]
        public string? user_status { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [NeedEnDecript(FieldName = "LOGIN_ERR", EnDeSignal = false)]
        public int? login_err { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        public DateTime? err_date { get; set; } = null;
        /// <summary>
        /// 使用者
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "CREID", EnDeSignal = false)]
        public string? creid { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{};'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "CREDATE", EnDeSignal = false)]
        public string? credate { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\", MinLength = 10, MaxLength = 10)]
        [NeedEnDecript(FieldName = "UPDID", EnDeSignal = false)]
        public string? updid { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        [NeedEnDecript(FieldName = "UPDDATE", EnDeSignal = false)]
        public DateTime? upddate { get; set; }

        public string? company_no { get; set; }
        public string? company_name { get; set; }
       
        public string? group_name { get; set; }
    }
}