using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Models.InputType
{
    public class FilterInputType
    {
        public string? Field_Name { get; set; }
        public string? ArrayConditions { get; set; }
        public string? Value { get; set; }
        public string? DataType { get; set; }
    }
}
