using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models
{
    public class Fornecedor
    {

        public Empresa Empresa
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Informações do CEP são obrigatórios")]
        public CEP CEP
        {
            get;
            set;
        }
        
        [JsonProperty("idFornecedor")]
        [Display(Name = "Código do Fornecedor")]
        public int idFornecedor
        {
            get;
            set;
        }

        [JsonProperty("razaoSocial")]
        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é obrigatório")]
        public string razaoSocial
        {
            get;
            set;
        }

        [JsonProperty("nmFornecedor")]
        [Display(Name = "Nome Fornecedor")]
        [Required(ErrorMessage = "Nome Fornecedor é obrigatório")]
        public string nmFornecedor
        {
            get;
            set;
        }

        [JsonProperty("CNPJ")]
        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        public string CNPJ
        {
            get;
            set;
        }

        [JsonProperty("cdIncricaoEstatual")]
        [Display(Name = "Inscrição Estadual")]
        [Required(ErrorMessage = "Inscrição Estadual é obrigatório")]
        public string cdIncricaoEstadual
        {
            get;
            set;
        }
    }
}
