using System;
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
        bool IncluirPerfil();

        [OperationContract]
        string ListarPerfil(Perfil pPerfil);
    }
}
