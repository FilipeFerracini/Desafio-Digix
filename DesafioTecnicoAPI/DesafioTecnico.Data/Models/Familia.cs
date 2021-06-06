using DesafioTecnico.Data.Models.Enums;
using DesafioTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Models
{
    public class Familia
    {
        [Key]
        public int Id { get; set; }
        public StatusFamilia Status { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; private set; } = new List<Pessoa>();

        public void AdicionarPessoa(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                this.Pessoas.Add(pessoa);
            }
        }
    }
}
