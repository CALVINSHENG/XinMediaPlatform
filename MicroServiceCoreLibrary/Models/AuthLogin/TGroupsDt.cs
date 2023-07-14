#region SonarLint Disabled 放置區域
#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Models.AuthLogin
{
    public class TGroupsDt
    {
        /// <summary>
        /// Gets or sets the group no.
        /// </summary>
        /// <value>
        /// The group no.
        /// </value>
        [DisplayName("GROUP_NO")] public string GROUP_NO { get; set; }
        /// <summary>
        /// Gets or sets the user no.
        /// </summary>
        /// <value>
        /// The user no.
        /// </value>
        [DisplayName("USER_NO")] public string USER_NO { get; set; }
    }
}
