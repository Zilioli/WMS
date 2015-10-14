using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models
{
    [Serializable]
    public class Perfil
    {
        [JsonProperty("idPerfil")]
        public int idPerfil
        {
            get;
            set;
        }

        [JsonProperty("desPerfil")]
        public string desPerfil
        {
            get;
            set;
        }
    }
}
