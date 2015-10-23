using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMS.Models
{
    public class Funcionario
    {
        
        [Display(Name = "Código", Prompt ="Insira o código")]
        [Required(ErrorMessage = "Campo Código é obrigatório")]              
        public int Codigo { get; set; }
       

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome é obrigatório")]        
        [MinLength(3, ErrorMessage = "Campo Nome é necessário o minímo de 3 letras")]            
        public string Nome { get; set; }

    }
}