using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using WMS.Models;

namespace WMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            //string jsonString = @"{""Perfil"":[{""idPerfil"":""1"",""desPerfil"":""Sherlock""},{""idPerfil"":""2"",""desPerfil"":""The Matrix""}]}";
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var opa = JsonConvert.DeserializeObject<Perfil>(jsonString);
            //List<Perfil> lstPerfil = serializer.Deserialize<List<Perfil>>(jsonString);

            return View("Login");
        }

        [HttpPost]
        public JsonResult LoginWMS(object data)
        {
            Session["Usuario"] = "opa";
            return Json("OK"); 
        }
    }
}