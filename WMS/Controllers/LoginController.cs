using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
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