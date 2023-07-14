using MicroServiceCoreLibrary.Models;
using System.Data;

namespace MicroServiceCoreLibrary.Helper
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// PageHelper
    /// </summary>
    public class PageHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageHelper"/> class.
        /// 建構子
        /// </summary>
        public PageHelper()
        {
        }
        /// <summary>
        /// Gets the page information.
        /// 分頁程式
        /// </summary>
        /// <param name="pageSize">分頁筆數</param>
        /// <param name="pageIndex">第幾頁</param>
        /// <param name="result">執行查詢後的結果</param>
        /// <returns></returns>
        public PageInfo GetPageInfo(int? pageSize, int? pageIndex, IDataReader result)
        {
            // 建立回傳物件PageInfo
            PageInfo pageInfo = new PageInfo();

            if (pageIndex is not null || pageIndex <= 0)
            {
                pageInfo.Page_Index = 1;
                pageInfo.Page_Size = pageSize;
            }
            else
            {
                pageInfo.Page_Size = pageSize;
                pageInfo.Page_Index = pageIndex;
            }


            // 取得查詢結果總筆數
            var dt = new DataTable();
            dt.Load(result);
            if (dt.Rows.Count >= 1)
            {
                pageInfo.Total = (int)dt.Rows[0]["COUNTING"];
                // 計算最後一頁
                if (pageInfo.Total == 0)
                {
                    pageInfo.Last_Page = 1;
                }
                else if (pageInfo.Total % pageInfo.Page_Size == 0)
                {
                    pageInfo.Last_Page = pageInfo.Total / pageInfo.Page_Size;
                }
                else
                {
                    pageInfo.Last_Page = (pageInfo.Total / pageInfo.Page_Size) + 1;
                }
            }
            return pageInfo;
        }
    }
}
