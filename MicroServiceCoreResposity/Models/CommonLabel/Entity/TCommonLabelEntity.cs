using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models.CommonLabel.Entity
{
    public class TCommonLabelEntity
    {
        /// <summary>
        /// Gets or sets the no.
        /// </summary>
        /// <value>
        /// The no.
        /// </value>
        public string? label_no { get; set; }
        /// <summary>
        /// Gets or sets the company no.
        /// </summary>
        /// <value>
        /// The company no.
        /// </value>
        public string? company_no { get; set; }
        /// <summary>
        /// Gets or sets the type of the function.
        /// </summary>
        /// <value>
        /// 功能類型
        /// </value>
        public string? function_type { get; set; }
        /// <summary>
        /// Gets or sets the function no.
        /// </summary>
        /// <value>
        /// 功能編號 Ex:客戶編號
        /// </value>
        public string? function_no { get; set; }
        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        /// <value>
        /// The name of the label.
        /// </value>
        public string? label_name { get; set; }
        /// <summary>
        /// Gets or sets the label status.
        /// </summary>
        /// <value>
        /// 標籤狀態 0:刪除 1:正常 2:停用
        /// </value>
        public string? label_status { get; set; }
        /// <summary>
        /// Gets or sets the creid.
        /// </summary>
        /// <value>
        /// The creid.
        /// </value>
        public string? creid { get; set; }
        /// <summary>
        /// Gets or sets the credate.
        /// </summary>
        /// <value>
        /// The credate.
        /// </value>
        public string? credate { get; set; }
        /// <summary>
        /// Gets or sets the updid.
        /// </summary>
        /// <value>
        /// The updid.
        /// </value>
        public string? updid { get; set; }
        /// <summary>
        /// Gets or sets the upddate.
        /// </summary>
        /// <value>
        /// The upddate.
        /// </value>
        public string? upddate { get; set; }
    }
}
