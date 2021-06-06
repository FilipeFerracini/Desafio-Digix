using DesafioTecnico.Data.Models;
using DesafioTecnicoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Repositories
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Renda> Renda { get; set; }
        public DbSet<Familia> Familia { get; set; }
    }
}
