using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

namespace WMSData
{
    public class SQL : IData
    {
        #region Variáveis
        private SqlConnection objConnection;
        private SqlCommand objCommand = new SqlCommand();
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

        public bool Close()
        {
            try
            {
                // Verifica se existe conexão aberta
                if (objConnection != null)
                {
                    if (objConnection.State == ConnectionState.Open)
                        objConnection.Close(); // Fecha conexão
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
                objConnection = new SqlConnection(CONNECTION_STRING);

                // Abre Conexão
                objConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public void IData()
        {
            throw new NotImplementedException();
        }

        public void AddParameter(string pName, WMSDBTypes.WMSDBType pDbType, int pSize, object pVal, ParameterDirection pDirection)
        {
            try
            {
                if (objCommand != null)
                {
                    if (pDirection == ParameterDirection.Input)
                        objCommand.Parameters.Add(pName, WMSDBTypes.SQL(pDbType), pSize).Value = (pVal == null) ? DBNull.Value : pVal;
                    else
                        objCommand.Parameters.Add(pName,  WMSDBTypes.SQL(pDbType)).Direction = ParameterDirection.Output;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetParameter(string pName)
        {
            throw new NotImplementedException(); if (objCommand != null)
            {
                if (objCommand.Parameters[pName] != null)
                    return objCommand.Parameters[pName].Value;
            }

            return null;
        }
    }
}
