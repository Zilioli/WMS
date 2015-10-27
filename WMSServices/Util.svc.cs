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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Util" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Util.svc or Util.svc.cs at the Solution Explorer and start debugging.
    public class Util : IUtil
    {
        #region Variáveis
        WMSData.IData objDATA;
        private string PKG_NAME = "";
        private bool SQL = true;
        #endregion

        public Util()
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

        public string ConsultarCep(string pJSONCEP)
        {
            IDataReader objResultado;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CEP objCEP = serializer.Deserialize<CEP>(pJSONCEP);

            try
            {
                // Abre conexão com o DB
                objDATA.Open();

                // Indica o tipo de comando
                objDATA.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objDATA.COMMAND = PKG_NAME + "CEP.dbo.PR_CONSULTA_CEP";

                // Adiciona os parametros a chamada da procedure
                objDATA.AddParameter("CEP", WMSDBTypes.WMSDBType.VARCHAR2, 20, objCEP.Cep, ParameterDirection.Input);

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

                    objCEP.Bairro = objResultado["BAIRRO"].ToString();
                    objCEP.Endereco = objResultado["LOGRADOURO"].ToString();
                    objCEP.Estado = objResultado["UF"].ToString();
                    objCEP.Municipio = objResultado["CIDADE"].ToString();
                    objCEP.UF = objResultado["UF"].ToString();

                }

                // Fecha o objeto
                objResultado.Close();

                // Retorna a lista de perfil
                return JsonConvert.SerializeObject(objCEP);
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
                objCEP = null;
            }

        }
    }
}
