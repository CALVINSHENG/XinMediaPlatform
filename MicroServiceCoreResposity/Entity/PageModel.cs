using MicroServiceCoreResposity.Interface;

namespace MicroServiceCoreResposity.Entity
{
    /// <summary>
    /// PageModel
    /// </summary>
    /// <seealso cref="MicroServiceCoreResposity.Interface.IPageModel" />
    public class PageModel : IPageModel
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string? OrderBy { get; set; }
    }
}