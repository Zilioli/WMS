#region using 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using WMS.Models;
using WMSData;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Configuration;
#endregion

namespace WMSServices
{
    public class Cadastro : ICadastro
    {

        #region Variáveis
        WMSData.IData objDATA;
        private string PKG_NAME = "";
        private bool SQL = true;
        #endregion

        #region Construtor

        public Cadastro()
        {
            if (ConfigurationManager.AppSettings["WMS_BD"] == "ORACLE")
            {
                objDATA = new WMSData.Oracle();
                PKG_NAME = "SYS.PKG_Cadastrar.";
                SQL = false;
            }
            else if (ConfigurationManager.AppSettings["WMS_BD"] == "SQL")
                objDATA = new WMSData.SQL();

            // Recupera a string de Conexão
            objDATA.CONNECTION_STRING = ConfigurationManager.ConnectionStrings["WMS_CONNECTION"].ConnectionString;

        }

        #endregion

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/
        #region PERFIL

        #region ManutencaoPerfil
        public bool ManutencaoPerfil(string pACAO, string pJSONPerfil)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Perfil pPerfil = serializer.Deserialize<Perfil>(pJSONPerfil);

            try
            {
                // Abre conexão com o DB
                objDATA.Open();

                // Indica o tipo de comando
                objDATA.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objDATA.COMMAND = PKG_NAME + "MANUTENCAO_PERFIL";

                // Adiciona os parametros a chamada da procedure
                objDATA.AddParameter("pACAO", WMSDBTypes.WMSDBType.CHAR, 1, pACAO, ParameterDirection.Input);
                objDATA.AddParameter("pIDPERFIL", WMSDBTypes.WMSDBType.INT16, 3, pPerfil.idPerfil, ParameterDirection.Input);
                objDATA.AddParameter("pDESPERFIL", WMSDBTypes.WMSDBType.VARCHAR2, 255, pPerfil.desPerfil, ParameterDirection.Input);

                // Executa a procedure
                return (objDATA.ExecuteNonQuery() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Verifica se existe conexão aberta e fecha
                if (objDATA != null)
                    objDATA.Close();
            }
        }
        #endregion

        #region ListarPerfil
        public string ListarPerfil(string pJSONPerfil)
        {
            Perfil objPerfil;
            List<Perfil> lstPerfil = new List<Perfil>();
            IDataReader objResultado;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Perfil pPerfil = serializer.Deserialize<Perfil>(pJSONPerfil);
            try
            {
                // Abre conexão com o DB
                objDATA.Open();

                // Indica o tipo de comando
                objDATA.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objDATA.COMMAND = PKG_NAME + "LISTAR_PERFIL";

                // Adiciona os parametros a chamada da procedure
                objDATA.AddParameter("pIDPERFIL", WMSDBTypes.WMSDBType.INT32, 3, pPerfil.idPerfil, ParameterDirection.Input);
                objDATA.AddParameter("pDESPERFIL", WMSDBTypes.WMSDBType.VARCHAR2, 255, pPerfil.desPerfil, ParameterDirection.Input);

                if (!SQL)
                {
                    objDATA.AddParameter("C_CUR", WMSDBTypes.WMSDBType.RefCursor, 0, null, ParameterDirection.Output);

                    // Executa a procedure
                    objDATA.ExecuteNonQuery();
                }

                // Recupera o Cursor de Saída
                objResultado = (!SQL) ? ((OracleRefCursor)objDATA.GetParameter("C_CUR")).GetDataReader() : objDATA.ExecuteQuery();

                // Percorre o resultado do cursor e adiciona os itens na lista
                while (objResultado.Read())
                {
                    // Preenche o objeto
                    objPerfil = new Perfil();
                    objPerfil.idPerfil = int.Parse(objResultado["IDPERFIL"].ToString());
                    objPerfil.desPerfil = objResultado["DESPERFIL"].ToString();

                    // Adiciona o item na lista
                    lstPerfil.Add(objPerfil);

                    // Finaliza o objeto
                    objPerfil = null;
                }

                // Fecha o objeto
                objResultado.Close();

                // Retorna a lista de perfil
                return JsonConvert.SerializeObject(lstPerfil);
            }
            catch (Exception ex)
            {
                // Tratamento de Exceção
                throw ex;
            }
            finally
            {
                // Verifica se existe conexão aberta e fecha
                if (objDATA != null)
                    objDATA.Close();

                // Finaliza os objetos
                objResultado = null;
                objPerfil = null;
                lstPerfil = null;
            }
        }
        #endregion

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
        #region ListarFornecedor
        public string ListarFornecedor(string pJSONFornecedor)
        {
            Fornecedor objFornecedor;
            CEP objCEP;
            List<Fornecedor> lstFornecedor = new List<Fornecedor>();
            IDataReader objResultado;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Fornecedor pFornecedor = serializer.Deserialize<Fornecedor>(pJSONFornecedor);
            try
            {
                // Abre conexão com o DB
                objDATA.Open();

                // Indica o tipo de comando
                objDATA.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objDATA.COMMAND = PKG_NAME + "LISTAR_FORNECEDOR";

                // Adiciona os parametros a chamada da procedure
                objDATA.AddParameter("pIDFORNECEDOR", WMSDBTypes.WMSDBType.INT32, 3, pFornecedor.idFornecedor, ParameterDirection.Input);

                if (!SQL)
                {
                    objDATA.AddParameter("C_CUR", WMSDBTypes.WMSDBType.RefCursor, 0, null, ParameterDirection.Output);

                    // Executa a procedure
                    objDATA.ExecuteNonQuery();
                }

                // Recupera o Cursor de Saída
                objResultado = (!SQL) ? ((OracleRefCursor)objDATA.GetParameter("C_CUR")).GetDataReader() : objDATA.ExecuteQuery();

                // Percorre o resultado do cursor e adiciona os itens na lista
                while (objResultado.Read())
                {
                    // Preenche o objeto
                    objFornecedor = new Fornecedor();
                    objFornecedor.idFornecedor = int.Parse(objResultado["IDFORNECEDOR"].ToString());
                    objFornecedor.nmFornecedor = objResultado["NMFORNECEDOR"].ToString();
                    objFornecedor.razaoSocial = objResultado["RAZAOSOCIAL"].ToString();
                    objFornecedor.CNPJ = objResultado["CNPJ"].ToString();
                    objFornecedor.cdIncricaoEstadual = objResultado["CDINSCRICAOESTADUAL"].ToString();

                    // TESTE
                    objFornecedor.CEP = new CEP();
                    objFornecedor.CEP.Cep = "14801230";
                    objFornecedor.CEP.Bairro = "Centro";
                    objFornecedor.CEP.Endereco = "Professor Jorge Corrêa";
                    objFornecedor.CEP.Estado = "SP";
                    objFornecedor.CEP.Municipio = "Araraquara";

                    objFornecedor.Empresa = new Empresa();
                    objFornecedor.Empresa.idEmpresa = 1;
                    objFornecedor.Empresa.nmEmpresa = "Empresa de teste";

                    // Adiciona o item na lista
                    lstFornecedor.Add(objFornecedor);

                    // Finaliza o objeto
                    objFornecedor = null;
                }

                // Fecha o objeto
                objResultado.Close();

                // Retorna a lista de perfil
                return JsonConvert.SerializeObject(lstFornecedor);
            }
            catch (Exception ex)
            {
                // Tratamento de Exceção
                throw ex;
            }
            finally
            {
                // Verifica se existe conexão aberta e fecha
                if (objDATA != null)
                    objDATA.Close();

                // Finaliza os objetos
                objResultado = null;
                objFornecedor = null;
                lstFornecedor = null;
            }
        }
        #endregion

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * FORNECEDOR
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/

    }
}
