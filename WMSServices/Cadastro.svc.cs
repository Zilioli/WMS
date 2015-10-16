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

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/
        #region IncluirPerfil
        public bool ManutencaoPerfil(string pACAO, string pJSONPerfil)
        {

            WMSData.Oracle objOracle = new WMSData.Oracle();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Perfil pPerfil = serializer.Deserialize<Perfil>(pJSONPerfil);

            try
            {
                // Recupera a string de Conexão
                objOracle.CONNECTION_STRING = ConfigurationManager.ConnectionStrings["WMS_ORACLE"].ConnectionString;

                // Abre conexão com o DB
                objOracle.Open();

                // Indica o tipo de comando
                objOracle.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objOracle.COMMAND = "SYS.PKG_Cadastrar.MANUTENCAO_PERFIL";

                // Adiciona os parametros a chamada da procedure
                objOracle.AddParameter("pACAO", OracleDbType.Char, 1, pACAO, ParameterDirection.Input);
                objOracle.AddParameter("pIDPERFIL", OracleDbType.Int16, 3, pPerfil.idPerfil, ParameterDirection.Input);
                objOracle.AddParameter("pDESPERFIL", OracleDbType.Varchar2, 255, pPerfil.desPerfil, ParameterDirection.Input);

                // Executa a procedure
                return (objOracle.ExecuteNonQuery() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Verifica se existe conexão aberta e fecha
                if (objOracle != null)
                    objOracle.Close();

                // Finaliza os objetos
                objOracle = null;
            }
        }
        #endregion

        #region ListarPerfil
        public string ListarPerfil(string pJSONPerfil)
        {
            WMSData.Oracle objOracle = new WMSData.Oracle();
            Perfil objPerfil;
            List<Perfil> lstPerfil = new List<Perfil>();
            OracleDataReader objResultado;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Perfil pPerfil = serializer.Deserialize<Perfil>(pJSONPerfil);
            try
            {
                // Recupera a string de Conexão
                objOracle.CONNECTION_STRING = ConfigurationManager.ConnectionStrings["WMS_ORACLE"].ConnectionString;

                // Abre conexão com o DB
                objOracle.Open();

                // Indica o tipo de comando
                objOracle.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objOracle.COMMAND = "SYS.PKG_Cadastrar.LISTAR_PERFIL";

                // Adiciona os parametros a chamada da procedure
                objOracle.AddParameter("pIDPERFIL", OracleDbType.Int16, 3,pPerfil.idPerfil, ParameterDirection.Input);
                objOracle.AddParameter("pDESPERFIL", OracleDbType.Varchar2, 255, pPerfil.desPerfil, ParameterDirection.Input);
                objOracle.AddParameter("C_CUR", OracleDbType.RefCursor, 0, null, ParameterDirection.Output);

                // Executa a procedure
                objOracle.ExecuteNonQuery();

                // Recupera o Cursor de Saída
                objResultado = ((OracleRefCursor)objOracle.GetParameter("C_CUR")).GetDataReader();

                // Percorre o resultado do cursor e adiciona os itens na lista
                while (objResultado.Read())
                {
                    // Preenche o objeto
                    objPerfil = new Perfil();
                    objPerfil.idPerfil = int.Parse( objResultado["IDPERFIL"].ToString());
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
                if (objOracle != null)
                    objOracle.Close();

                // Finaliza os objetos
                objOracle = null;
                objResultado = null;
                objPerfil = null;
                lstPerfil = null;
            }
        }
        #endregion

        /*--------------------------------------------------------------------
         *--------------------------------------------------------------------
         * PERFIL
         *--------------------------------------------------------------------
         *--------------------------------------------------------------------*/
    }
}
