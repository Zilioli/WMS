using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Empresa
    {
        [JsonProperty("idEmpresa")]
        [Display(Name = "Código da Empresa")]
        public int idEmpresa
        {
            get;
            set;
        }

        [JsonProperty("nmEmpresa")]
        [Display(Name = "Nome da Empresa")]
        public string nmEmpresa
        {
            get;
            set;
        }
    }
}