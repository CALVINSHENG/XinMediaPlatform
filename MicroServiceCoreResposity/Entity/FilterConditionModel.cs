using MicroServiceCoreLibrary.Models;
using MicroServiceCoreLibrary.Models.InputType;

namespace MicroServiceCoreResposity.Entity
{
    /// <summary>
    /// FilterConditionModel
    /// </summary>
    public class FilterConditionModel
    {
        public List<FilterInputType>? Filters { get; set; }
        public bool? Filter_Needed { get; set; } = false;
        public PageInfo? PageInfo { get; set; }
    }
}
