using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Models.UploadFiles
{
    public class FileModel
    {
        public string? Description { get; set; }
        public List<IFormFile>? Files { get; set; }
    }
}
