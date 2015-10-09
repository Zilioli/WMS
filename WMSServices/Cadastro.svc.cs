using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WMS.Models;
using WMSData;

namespace WMSServices
{
    public class Cadastro : ICadastro
    {
        public bool IncluirPerfil()
        {
            return true;
        }

        public List<Perfil> ListarPerfil(Perfil pPerfil)
        {
            return null;
        }
    }
}
