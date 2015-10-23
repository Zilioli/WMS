using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WMS.Models
{
    public class Turno
    {
        private int _codigo;
        [Display(Name = "Código")]
        public int Codigo
        {
            get;
            set;
        }

        private string _descricao;
        [Display(Name = "Descrição")]
        public string Descricao
        {
            get;
            set;
        }

        public List<Turno> GetTurnos()
        {
            return new List<Turno>
            {
                new Turno{ Codigo = 1, Descricao = "Manha"},
                new Turno{ Codigo = 2, Descricao = "Tarde"},
                new Turno{ Codigo = 3, Descricao = "Noite"}
            };
        }
    }
}