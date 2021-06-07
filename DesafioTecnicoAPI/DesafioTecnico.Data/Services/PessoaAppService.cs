using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Repositories;
using DesafioTecnicoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Services {
    public class PessoaAppService : IPessoaAppService {
        private PessoaContext database;

        public PessoaAppService(PessoaContext _database) {
            this.database = _database;
        }

        public bool AdicionarPessoa(Pessoa pessoa) {
            try {
                if (pessoa == null)
                    return false;

                database.Add(pessoa);
                database.SaveChanges();
                return true;
            } catch (Exception e) {
                throw e;
            }
        }

        public Pessoa AdicionarRenda(int id, Renda renda) {
            try {
                Pessoa pessoa = BuscarPessoa(id);
                pessoa.ValorRenda = renda;
                database.SaveChanges();
                return pessoa;
            } catch (Exception e) {
                throw e;
            }
        }

        public Pessoa BuscarPessoa(int id) {
            try {
                return database.Pessoa.Include(x => x.ValorRenda).FirstOrDefault(x => x.Id == id);
            } catch (Exception e) {
                throw e;
            }
        }

        public List<Pessoa> BuscarTodasPessoas() {
            try {
                return database.Pessoa.Include(x => x.ValorRenda).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public bool RemoverPessoa(int id) {
            try {
                var pessoa = BuscarPessoa(id);

                if (pessoa == null)
                    return false;

                database.Pessoa.Remove(pessoa);
                database.SaveChanges();
                return true;
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
