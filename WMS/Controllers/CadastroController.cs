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
                objCadastro.Close();
                objCadastro = null;
                serializer = null;
                lstPerfil = null;
            }
        }

        #endregion

        public JsonResult DeletarPerfil(Perfil pVO)
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();
            try
            {
                objCadastro.ManutencaoPerfil("E", JsonConvert.SerializeObject(pVO));
                return Json("OK");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCadastro.Close();
                objCadastro = null;
            }
        }

        public ActionResult ManutencaoPerfil(Perfil pVO)
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
                if (pVO.idPerfil > 0)
                    pVO = serializer.Deserialize<List<Perfil>>(objCadastro.ListarPerfil(JsonConvert.SerializeObject(pVO)))[0];

                return View(pVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCadastro.Close();
                objCadastro = null;
            }
        }

        public JsonResult SalvarPerfil(Perfil pVO)
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();

            try
            {
                objCadastro.ManutencaoPerfil((pVO.idPerfil == 0 ? "I" : "A"), JsonConvert.SerializeObject(pVO));
                return Json("OK");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCadastro.Close();
                objCadastro = null;
            }
        }

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/

      

        public ActionResult Funcionario()
        {
            Turno t = new Turno();

            List<Turno> lstTurnos = t.GetTurnos();
            ViewBag.lstTurnos = lstTurnos;

            return View();
        }
         
        public JsonResult SalvarFuncionario()
        {
            return Json("OK");
        }

    }
}