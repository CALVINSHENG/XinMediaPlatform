using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.Models.Filter
{
    public class TFilterListConditionModel
    {
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string? Field_Name { get; set; }

        /// <summary>
        /// Gets or sets the array conditions.
        /// </summary>
        /// <value>
        /// The array conditions.
        /// </value>
        public string[]? ArrayConditions { get; set; }

        /// <summary>
        /// Gets or sets the displayType.
        /// 用於搜尋頁判斷條件應是Search框、固定欄位或是隱藏在過濾器
        /// </summary>
        /// <value>
        /// The string displayType
        /// </value>
        public string? DisplayType { get; set; }

        /// <summary>
        /// Gets or sets the string DataType.
        /// 用於判斷該欄位的資料型態
        /// </summary>
        /// <value>
        /// The string DataType
        /// </value>
        public string? DataType { get; set; }

        /// <summary>
        /// Gets or sets the string LanguageName.
        /// 用於顯示該欄位語系
        /// </summary>
        /// <value>
        /// The string LanguageName
        /// </value>
        public string? Label { get; set; }
    }
}
