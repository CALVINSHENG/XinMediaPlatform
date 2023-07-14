using Dapper;
using DapperQueryBuilder;
using DocumentFormat.OpenXml.Bibliography;
using MicroServiceCoreLibrary.Models;
using MicroServiceCoreResposity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models.Filter
{
    public class FilterHelperResult<TFilterListContentModel> where TFilterListContentModel : class
    {
        /// <summary>
        /// 狀態碼
        /// </summary>
        public string StatusCode { get; set; } = "200";
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string Message { get; set; } = "失敗";
        public List<TFilterListContentModel>? ContentList { get; set; }
        public List<TFilterListConditionModel>? ConditionList { get; set; }
        public PageInfo? PageInfo { get; set; }
    }
}
