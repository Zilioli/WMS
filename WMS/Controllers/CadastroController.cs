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

        #region DeletarPerfil
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
        #endregion

        #region ManutencaoPerfil
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
        #endregion

        #region SalvarPerfil
        public JsonResult SalvarPerfil( Perfil pVO)
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();

            try
            {
                objCadastro.ManutencaoPerfil((pVO.idPerfil == 0 ? "I":"A"), JsonConvert.SerializeObject(pVO));
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
        #endregion
        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/


        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * FORNECEDOR
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/
        /// <summary>
        /// Carrega a tela inicial de Manutenção de Fornecedores
        /// </summary>
        /// <returns></returns>
        public ActionResult Fornecedor()
        {
            wcfCadastro.CadastroClient objCadastro = new wcfCadastro.CadastroClient();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Fornecedor> lstFornecedor = new List<Models.Fornecedor>();
            Models.Fornecedor objFornecedor = new Models.Fornecedor();

            try
            {
                objFornecedor.idFornecedor = -1;
                lstFornecedor = serializer.Deserialize<List<Fornecedor>>(objCadastro.ListarFornecedor(JsonConvert.SerializeObject(objFornecedor)));
                return View(lstFornecedor);
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
                lstFornecedor = null;
            }
            }

        public ActionResult ManutencaoFornecedor()
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

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * FORNECEDOR
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/

        [HttpPost]
        public ActionResult Funcionario(Funcionario funcionario)
        {

            if (!ModelState.IsValid) //Check for validation errors
            {
                return View(funcionario);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Funcionario()
        {
            Turno t = new Turno();

            List<Turno> lstTurnos = t.GetTurnos();
            ViewBag.lstTurnos = lstTurnos;

            return View();
        }

    }
}
