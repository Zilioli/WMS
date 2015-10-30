using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WMS.App_Start
{
    public static class WMSUtil 
    {
        public static JsonResult ReturnWMSException(Exception ex) 
        {
            return new JsonResult
            {
                Data = new { ErrorMessage = ex.Message, Success = false },
                ContentEncoding = System.Text.Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}
