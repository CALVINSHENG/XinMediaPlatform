using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Models.UploadFiles
{
    public class FileResultModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
