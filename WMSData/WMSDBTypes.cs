using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;

namespace WMSData
{
    public class WMSDBTypes
    {
        public enum WMSDBType
        {
            RefCursor = OracleDbType.RefCursor,
            INT16 = OracleDbType.Int16,
            INT32 = OracleDbType.Int32,
            INT64 = OracleDbType.Int64,
            CHAR = OracleDbType.Char,
            VARCHAR2 = OracleDbType.Varchar2,
            BLOB = OracleDbType.Blob,
            BYTE = OracleDbType.Byte,
            DATE = OracleDbType.Date,
            DECIMAL = OracleDbType.Decimal,
            DOUBLE = OracleDbType.Double,
            LONG = OracleDbType.Long,
            NCHAR = OracleDbType.NChar,
            TIMESTAMP = OracleDbType.TimeStamp,
            XMLTYPE = OracleDbType.XmlType
        }
    }
}
