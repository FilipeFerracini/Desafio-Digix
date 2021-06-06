using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Repositories
{
    public class PessoaRepository : IPessoaAppService
    {
        public List<Pessoa> pessoas = new List<Pessoa>()
        {
            new Pessoa{ Id = 1, Nome="João", Tipo=TipoPessoa.Pretendente, DataDeNascimento=DateTime.Parse("1989-12-30")},
            new Pessoa{ Id = 2, Nome="Maria", Tipo=TipoPessoa.Cônjuge, DataDeNascimento=DateTime.Parse("1989-12-30")},
            new Pessoa{ Id = 3, Nome="José", Tipo=TipoPessoa.Dependente, DataDeNascimento=DateTime.Parse("2015-12-30")},
            new Pessoa{ Id = 4, Nome="Angela", Tipo=TipoPessoa.Dependente, DataDeNascimento=DateTime.Parse("2015-12-30")}
        };

        public bool AdicionaPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Pessoa AdicionaRenda(int id, Renda renda)
        {
            throw new NotImplementedException();
        }

        public Pessoa BuscaPessoa(int id)
        {
            return pessoas.FirstOrDefault(x => x.Id == id);
        }

        public List<Pessoa> BuscaTodasPessoas()
        {
            return pessoas;
        }

        public bool RemovePessoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
