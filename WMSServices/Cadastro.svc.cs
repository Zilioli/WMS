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

namespace WMSServices
{
    public class Cadastro : ICadastro
    {
        public bool IncluirPerfil()
        {
            return true;
        }

        public string ListarPerfil(Perfil pPerfil)
        {
            WMSData.Oracle objOracle = new WMSData.Oracle();
            Perfil objPerfil;
            List<Perfil> lstPerfil = new List<Perfil>();
            OracleDataReader objResultado;

            try
            {
                // Recupera a string de Conexão
                objOracle.CONNECTION_STRING = objOracle.CONNECTION_STRING = @"Data Source=(DESCRIPTION=
                                        (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=Zilioli )(PORT=1521)))
         (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=WMS))); User Id=wms ;Password=wms2015";

                // Abre conexão com o DB
                objOracle.Open();

                // Indica o tipo de comando
                objOracle.COMMAND_TYPE = CommandType.StoredProcedure;

                // Comando a ser executado no DB
                objOracle.COMMAND = "SYS.PKG_Cadastrar.LISTAR_PERFIL";

                // Adiciona os parametros a chamada da procedure
                objOracle.AddParameter("pIDPERFIL", OracleDbType.Int16, 3, 1, ParameterDirection.Input);
                objOracle.AddParameter("pDESPERFIL", OracleDbType.Varchar2, 255, null, ParameterDirection.Input);
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

    }
}
