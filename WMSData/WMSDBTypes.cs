using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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
            XMLTYPE = OracleDbType.XmlType,
            DATETIME = DbType.Object
        }

        public static SqlDbType SQL(WMSDBType pWMSDBType)
        {
            switch (pWMSDBType)
            {
                case WMSDBType.BLOB:
                    return SqlDbType.Text;
                case WMSDBType.BYTE:
                    return SqlDbType.Bit;
                case WMSDBType.CHAR:
                    return SqlDbType.Char;
                case WMSDBType.DATE:
                    return SqlDbType.Date;
                case WMSDBType.DATETIME:
                    return SqlDbType.DateTime;
                case WMSDBType.DOUBLE:
                case WMSDBType.DECIMAL: 
                    return SqlDbType.Decimal;
                case WMSDBType.INT16:
                case WMSDBType.INT32:
                case WMSDBType.INT64:
                    return SqlDbType.Int;
                case WMSDBType.LONG:
                    return SqlDbType.BigInt;
                case WMSDBType.NCHAR:
                    return SqlDbType.NChar;
                case WMSDBType.TIMESTAMP:
                    return SqlDbType.Timestamp;
                case WMSDBType.VARCHAR2:
                    return SqlDbType.VarChar;
                case WMSDBType.XMLTYPE:
                    return SqlDbType.Xml;
                default:
                    throw new Exception("SQLType inválido");
            }
        }

    }
}
