using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// FileHelper
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Gets the name of the unique file.
        /// 檔案名稱重新命名
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return string.Concat(DateTime.Now.ToString("yyyyMMdd")
                                , "_"
                                , Path.GetFileNameWithoutExtension(fileName)
                                , Path.GetExtension(fileName));
        }

        /// <summary>
        /// Checks the file.
        /// .檢查檔案
        /// </summary>
        /// <param name="formFiles">The form files.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public static bool CheckFile(List<IFormFile> formFiles, out string errorMessage)
        {
            errorMessage = "";
            foreach (var formFile in formFiles)
            {
                var name = formFile.FileName.Split(".")[0];
                var extension = formFile.FileName.Split(".")[^1].ToUpper();
                long mb = 0;

                switch (extension)
                {
                    case "PNG":
                    case "JPG":
                        mb = FileHelper.MutateImage(formFile);
                        break;
                    case "XLSX":
                    case "DOS":
                        mb = formFile.Length / 1024 / 1024;
                        break;
                    default:
                        errorMessage = "檔案格式錯誤!!";
                        return false;
                }

                if (mb > 30)
                {
                    errorMessage = "檔案不得超過30MB!!";
                    return false;
                }

                if (name.Length > 10)
                {
                    errorMessage = "檔名不得超過10字!!";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Mutates the image.
        /// 取得圖檔轉換尺寸後的大小
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static long MutateImage(IFormFile file)
        {
            IImageFormat format;
            using var memoryStream = new MemoryStream();
            using var image = Image.Load(file.OpenReadStream(), out format);
            image.Mutate(x => x.Resize(50, 50));
            image.Save(memoryStream, format);
            return memoryStream.Length / 1024 / 1024;
        }

        /// <summary>
        /// Saves the mutate image.
        /// 儲存轉換尺寸後的圖片
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static bool SaveMutateImage(IFormFile file, string path)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(100, 50));
            image.Save(path);
            return true;
        }
    }
}
