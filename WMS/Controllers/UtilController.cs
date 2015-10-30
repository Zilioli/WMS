using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WMS.Models;

namespace WMS.Controllers
{
    public class UtilController : Controller
    {
        public ActionResult CEP()
        {
            return View();
        }

        public JsonResult ConsultarCEP(CEP pVO)
        {
            wcfUtil.UtilClient objUtil = new wcfUtil.UtilClient();
            try
            {
                return Json(objUtil.ConsultarCep(JsonConvert.SerializeObject(pVO)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUtil.Close();
                objUtil = null;
            }
        }

        public JsonResult ConsultarEndereco(CEP pVO)
        {
            List<CEP> lstCEP = new List<Models.CEP>();
            wcfUtil.UtilClient objUtil = new wcfUtil.UtilClient();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            try
            {
                lstCEP = serializer.Deserialize<List<CEP>>(objUtil.ConsultarEndereco(JsonConvert.SerializeObject(pVO)));
                return Json(JsonConvert.SerializeObject(lstCEP));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUtil.Close();
                objUtil = null;
            }
        }
    }
}
