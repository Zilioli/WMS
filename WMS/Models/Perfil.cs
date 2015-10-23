using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models
{
    [Serializable]
    public class Perfil
    {
        [JsonProperty("idPerfil")]
        [Display(Name = "Código do Perfil")]
        public int idPerfil
        {
            get;
            set;
        }

        [JsonProperty("desPerfil")]
        [Display(Name = "Descrição do Perfil")]
        public string desPerfil
        {
            get;
            set;
        }
    }
}
