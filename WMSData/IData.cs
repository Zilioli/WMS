#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
#endregion

namespace WMSData
{
    public interface IData
    {

        #region Atributos
        string PROCEDURE
        {
            get;
            set;
        }

        string CONNECTION_STRING
        {
            get;
            set;
        }

        string COMMAND
        {
            get;
            set;
        }

        CommandType COMMAND_TYPE
        {
            get;
            set;
        }

        #endregion

        #region Métodos

        void AddParameter(string pName, WMSDBTypes.WMSDBType pDbType, int pSize, object pVal, ParameterDirection pDirection);

        void ClearParameters();

        bool Open();
        bool Close();
        int ExecuteNonQuery();
        IDataReader ExecuteQuery();
        object GetParameter(string pName);
        void IData();

        #endregion
    }
}
