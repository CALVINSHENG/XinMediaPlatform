using MicroServiceCoreResposity.DbAccess.T4_Design_Time;

namespace MicroServiceCoreResposity.DbAccess.T4_Run_Time.Models
{
    /// <summary>
    /// 系統代碼參數值
    /// </summary>
    public class EventCodeParameterModel
    {
        /// <summary>
        /// Gets or sets the data count.
        /// 資料筆數
        /// </summary>
        /// <value>
        /// The data count.
        /// </value>
        public int DataCount { get; set; } = GenerateEventCodeModelRowsCountsTtFile.DataCount;
        /// <summary>
        /// Gets or sets the field count.
        /// 資料表欄位數
        /// </summary>
        /// <value>
        /// The field count.
        /// </value>
        public int FieldCount { get; set; } = GenerateEventCodeModelRowsCountsTtFile.FieldCount;
    }
}
