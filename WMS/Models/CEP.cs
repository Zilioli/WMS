using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class CEP
    {

        [JsonProperty("Cep")]
        [Display(Name = "CEP")]
        public string Cep
        {
            get;
            set;
        }

        [JsonProperty("Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco
        {
            get;
            set;
        }

        [JsonProperty("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro
        {
            get;
            set;
        }

        [JsonProperty("Municipio")]
        [Display(Name = "Municipio")]
        public string Municipio
        {
            get;
            set;
        }

        [JsonProperty("Estado")]
        [Display(Name = "Estado")]
        public string Estado
        {
            get;
            set;
        }

        [JsonProperty("UF")]
        [Display(Name = "UF")]
        public string UF
        {
            get;
            set;
        }
    }
}
