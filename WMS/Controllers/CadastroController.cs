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
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Perfil> lstPerfil = serializer.Deserialize<List<Perfil>>(objCadastro.ListarPerfil(null));

            //string jsonString = @"{""Perfil"":[{""idPerfil"":""1"",""desPerfil"":""Sherlock""},{""idPerfil"":""2"",""desPerfil"":""The Matrix""}]}";
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var opa = JsonConvert.DeserializeObject<Perfil>(jsonString);
            //List<Perfil> lstPerfil = serializer.Deserialize<List<Perfil>>(jsonString);
            //List<Perfil> lstPerfil = new List<Models.Perfil>();
            return View(lstPerfil);
        }
    }
}