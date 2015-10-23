#region using
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
#endregion

namespace WMSData
{
    public class Oracle : IData
    {
        #region Variáveis
        private OracleConnection objConnection;
        private OracleCommand objCommand = new OracleCommand();
        #endregion

        #region Atributos
        public string CONNECTION_STRING
        {
            get;
            set;
        }

        public string PROCEDURE
        {
            get;
            set;
        }

        public string COMMAND
        {
            get;
            set;
        }

        public CommandType COMMAND_TYPE
        {
            get;
            set;
        }
        #endregion

        #region Métodos
        public void IData()
        {
        }

        public void AddParameter(string pName, OracleDbType pOracleDbType, int pSize, object pVal, ParameterDirection pDirection)
        {
            try
            {
                if(objCommand != null)
                {
                    if (pDirection == ParameterDirection.Input)
                        objCommand.Parameters.Add(pName, pOracleDbType, pSize, (pVal == null) ? DBNull.Value : pVal, pDirection);
                    else
                        objCommand.Parameters.Add(pName, pOracleDbType).Direction = ParameterDirection.Output;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public object GetParameter(string pName)
        {
            if (objCommand != null)
            {
                if (objCommand.Parameters[pName] != null)
                    return objCommand.Parameters[pName].Value;
            }

            return null;
        }

        public void ClearParameters()
        {
            try
            {
                // Verifica se existem parametros a serem excluídos
                if (objCommand != null)
                {
                    if (objCommand.Parameters.Count > 0)
                        objCommand.Parameters.Clear();
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public bool Close()
        {
            try
            {
                // Verifica se existe conexão aberta
                if (objConnection != null)
                {
                    if (objConnection.State == ConnectionState.Open)
                        objConnection.Clone(); // Fecha conexão
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Finaliza objetos
                objConnection = null; 
            }
        }

        public int ExecuteNonQuery()
        {
            try
            {
                if (objConnection.State != ConnectionState.Open)
                    throw new Exception("Conexão com o DB não está aberta!");

                objCommand.Connection = objConnection;
                objCommand.CommandType = COMMAND_TYPE;
                objCommand.CommandText = COMMAND;

                return objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public IDataReader ExecuteQuery()
        {
            try
            {
                if (objConnection.State != ConnectionState.Open)
                    throw new Exception("Conexão com o DB não está aberta!");

                objCommand.Connection = objConnection;
                objCommand.CommandType = COMMAND_TYPE;
                objCommand.CommandText = COMMAND; 
                return objCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Open()
        {
            try
            {
                // Verifica se a connection string foi informada
                if (CONNECTION_STRING == "")
                    throw new Exception("CONNECTION_STRING não informada.");

                // Instancia objeto de Conexão Oracle
                objConnection = new OracleConnection(CONNECTION_STRING);

                // Abre Conexão
                objConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameter(string pName, WMSDBTypes.WMSDBType pDbType, int pSize, object pVal, ParameterDirection pDirection)
        {
            try
            {
                if (objCommand != null)
                {
                    if (pDirection == ParameterDirection.Input)
                        objCommand.Parameters.Add(pName, (OracleDbType)pDbType, pSize, (pVal == null) ? DBNull.Value : pVal, pDirection);
                    else
                        objCommand.Parameters.Add(pName, (OracleDbType)pDbType).Direction = ParameterDirection.Output;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }

}
