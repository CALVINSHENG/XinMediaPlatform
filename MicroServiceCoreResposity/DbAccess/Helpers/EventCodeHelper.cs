using MicroServiceCoreResposity.DbAccess.T4_Design_Time;
using MicroServiceCoreResposity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceCoreResposity.DbAccess.Helpers
{
    public class EventCodeHelper
    {
        /// <summary>
        /// 錯誤代碼轉換回傳訊息
        /// </summary>
        /// <param name="data">檢查資料</param>
        /// <param name="http_successs">成功代碼回報 ex: EventCode.HTTP_200</param>
        /// <param name="success_string">成功時，回傳給前端訊息</param>
        /// <param name="http_error">錯誤代碼回報 ex: EventCode.COMM_00001</param>
        /// <param name="error_string">失敗時，回傳給前端訊息</param>
        /// <returns></returns>
        public DataResultModel<T> ConvertEventCode<T>(IEnumerable<T> data, string http_successs, string success_string,  string http_error, string error_string)
        {
            DataResultModel<T> result = new();
            if (data is not null)
            {
                result.StatusCode = http_successs.Split("^")[0];
                result.Message = http_successs.Split("^")[3];
                result.ResultString = success_string.Split("^")[3];
                result.DataList = data;
                result.Result = true;
            }
            else
            {
                result.StatusCode = http_error.Split("^")[0];
                result.Message = http_error.Split("^")[3];
                result.ResultString = error_string.Split("^")[3];
            }
            return result;
        }
    }

    /// <summary>
    /// 預設回傳訊息
    /// </summary>
    public class DefaultResultModel
    {
        public string StatusCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ResultString { get; set; } = string.Empty;
    }

}
