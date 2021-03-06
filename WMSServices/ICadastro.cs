﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WMS.Models;

namespace WMSServices
{
    [ServiceContract]
    public interface ICadastro
    {
        [OperationContract]
        bool ManutencaoPerfil(string pACAO, string pJSONPerfil);

        [OperationContract]
        string ListarPerfil(string pJSONPerfil);

        [OperationContract]
        string ListarFornecedor(string pJSONFornecedor);
    }
}
