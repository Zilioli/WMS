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

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/

        #region Perfil

        /// <summary>
        /// Carrega a tela inicial de Manutenção de Perfil
        /// </summary>
        /// <returns></returns>
        public ActionResult Perfil()
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Perfil> lstPerfil = new List<Models.Perfil>();
            Models.Perfil objPerfil = new Models.Perfil();

            try
            {
                objPerfil.idPerfil = -1;
                lstPerfil = serializer.Deserialize<List<Perfil>>(objCadastro.ListarPerfil(JsonConvert.SerializeObject(objPerfil)));
                return View(lstPerfil);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                serializer = null;
                lstPerfil = null;
            }
        }

        #endregion

        [HttpPost]
        public JsonResult DeletarPerfil(Perfil pVO)
        {
            return Json("OK");
        }

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/
    }
}
