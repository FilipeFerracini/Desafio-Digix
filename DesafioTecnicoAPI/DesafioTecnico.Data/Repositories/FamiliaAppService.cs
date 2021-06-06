using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Repositories
{
    public class FamiliaAppService : IFamiliaAppService
    {
        private PessoaContext database;
        private IPessoaAppService pessoaAppService;
        public FamiliaAppService(PessoaContext _database, IPessoaAppService _pessoaAppService)
        {
            this.database = _database;
            this.pessoaAppService = _pessoaAppService;
        }

        public bool AdicionarFamilia(Familia familia)
        {
            try
            {
                if (familia == null)
                    return false;

                database.Familia.Add(familia);
                database.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AdicionarPessoaFamilia(int idPessoa, int idFamilia)
        {
            var familia = BuscarFamilia(idFamilia);
            var pessoa = pessoaAppService.BuscaPessoa(idPessoa);

            if(familia!= null)
            {
                familia.AdicionarPessoa(pessoa);
                database.SaveChanges();
                return true;
            }
            return false;
        }

        public Familia BuscarFamilia(int id)
        {
            return database.Familia
                .Include(f=>f.Pessoas)
                .ThenInclude(p=>p.Valor)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Familia> BuscarTodasFamilias()
        {
            return database.Familia
                .Include(f => f.Pessoas)
                .ThenInclude(p => p.Valor)
                .ToList();
        }
    }
}
