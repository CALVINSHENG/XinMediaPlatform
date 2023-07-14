namespace MicroServiceCoreLibrary.Common
{
    #region SonarLint Disabled 放置區域

    #endregion

    /// <summary>
    /// 搜尋工具
    /// </summary>
    public static class SearchTargetCommon
    {
        /// <summary>
        /// 查找重複數值
        /// </summary>
        /// <param name="myList">字串列表</param>
        /// <param name="strTarget">查找字串</param>
        /// <returns></returns>
        public static bool FindListDuplicates(List<string> myList, string strTarget)
        {
            var match = myList
                .FirstOrDefault(stringToCheck => stringToCheck.Contains(strTarget));

            /*
            * 編輯作者：ADD BY CALVIN AT 2023/01/03
            * 說明：
            * != null：找到重複欄位
            * == null：查無重複欄位
            */
            return match == null;
        }
    }
}
