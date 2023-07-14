using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models.Filter
{
    public class FilterCustomModel
    {
        /// <summary>
        /// 欲客製化欄位
        /// </summary>
        public string? CustomField { get; set; }
        public string? CustomSQLColumn { get; set; }

    }
}
