using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models.CommonLabel
{
    /// <summary>
    /// 回傳 CommonLabelHelper 的連線、交易字串
    /// 用於接續其他資料的交易
    /// </summary>
    public class TCommonLabelConnection
    {
        /// <summary>
        /// Gets or sets 連線
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IDbConnection? conn { get; set; }
        /// <summary>
        /// Gets or sets 交易
        /// </summary>
        /// <value>
        /// The trans.
        /// </value>
        public IDbTransaction? trans { get; set; } 
        public bool? issuccess { get; set; }
    }
}
