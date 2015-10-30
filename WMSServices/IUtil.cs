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
    [ServiceContract]
    public interface IUtil
    {
        [OperationContract]
        string ConsultarCep(string pJSONCEP);

        [OperationContract]
        string ConsultarEndereco(string pJSONCEP);
    }
}
