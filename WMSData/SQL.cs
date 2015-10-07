using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WMSData
{
    class SQL : IData
    {
        public string CONNECTION_STRING
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string PROCEDURE
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string COMMAND
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public CommandType COMMAND_TYPE
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddParameter()
        {
            throw new NotImplementedException();
        }

        public bool Close()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public bool Open()
        {
            throw new NotImplementedException();
        }

        public void AddParameter(string pName, OracleDbType pOracleDbType, int pSize, object pVal, ParameterDirection pDirection)
        {
            throw new NotImplementedException();
        }

        public void ClearParameters()
        {
            throw new NotImplementedException();
        }

        public void IData()
        {
            throw new NotImplementedException();
        }
    }
}
