using DesafioTecnico.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnicoAPI.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoPessoa Tipo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        
        ////ForeignKey("Renda")
        //public int? RendaId { get; set; }

        //Navigation
        public virtual Renda Valor { get; set; }
        public int? FamiliaId { get; set; }
        //public virtual Familia Familia { get; set; }
    }
}
