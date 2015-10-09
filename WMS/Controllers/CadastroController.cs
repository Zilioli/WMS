using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            List<Models.Perfil> lstPerfil = new List<Models.Perfil>();
            Models.Perfil item = new Models.Perfil();
            item.idPerfil = 1;
            item.desPerfil = "Administrador";
            lstPerfil.Add(item);

            item = new Models.Perfil();
            item.idPerfil = 2;
            item.desPerfil = "Usuario";
            lstPerfil.Add(item);

            item = new Models.Perfil();
            item.idPerfil = 3;
            item.desPerfil = "Peão";
            lstPerfil.Add(item);

            return View(lstPerfil);
        }
    }
}