using DesafioTecnico.Data.Interfaces;
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
    public class PessoaDatabase : IPessoaAppService
    {
        private PessoaContext database;

        public PessoaDatabase(PessoaContext _database)
        {
            this.database = _database;
        }

        public bool AdicionaPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                    return false;

                database.Add(pessoa);
                database.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Pessoa AdicionaRenda(int id, Renda renda)
        {
            Pessoa pessoa = BuscaPessoa(id);
            pessoa.Valor = renda;
            database.SaveChanges();
            return pessoa;
        }

        public Pessoa BuscaPessoa(int id)
        {
            return database.Pessoa.Include(x => x.Valor).FirstOrDefault(x => x.Id == id);
        }

        public List<Pessoa> BuscaTodasPessoas()
        {
            return database.Pessoa.Include(x => x.Valor).ToList();
        }

        public bool RemovePessoa(int id)
        {
            var pessoa = BuscaPessoa(id);

            if (pessoa == null)
                return false;

            database.Pessoa.Remove(pessoa);
            database.SaveChanges();
            return true;
        }
    }
}
