using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Models.InputType
{
    public class AccountInputType
    {
        [GraphQLDescription("使用者編號")]
        public string? USER_NO { get; set; }

        [GraphQLDescription("員工姓名")]
        public string USER_NAME { get; set; } = "";

        [GraphQLDescription("電子郵件")]
        public string USER_EMAIL { get; set; } = "";

        [GraphQLDescription("電話")]
        public string USER_PHONE { get; set; } = "";

        [GraphQLDescription("職稱")]
        public string? JOB_TITLE { get; set; }

        [GraphQLDescription("出生日期")]
        public DateTime? USER_BIRTHDAY { get; set; }

        [GraphQLDescription("員工編號")]
        public string? STAFF_NO { get; set; }

        [GraphQLDescription("開始日期")]
        public DateTime? STR_DATE { get; set; }

        [GraphQLDescription("離開日期")]
        public DateTime? END_DATE { get; set; }

        [GraphQLDeprecated("許可證號")]
        public string? LICENSE_NO { get; set; }

        [GraphQLDeprecated("牌照等級")]
        public string? LICENSE_LVL { get; set; }

        [GraphQLDeprecated("執照州/省/地區")]
        public string? LICENSE_AREA { get; set; }

        [GraphQLDeprecated("群組代碼")]
        public string? GROUP_NO { get; set; }

        [GraphQLDeprecated("新增人員")]
        public string? CREID { get; set; }

        [GraphQLDeprecated("修改人員")]
        public string? UPDID { get; set; }
    }
}
