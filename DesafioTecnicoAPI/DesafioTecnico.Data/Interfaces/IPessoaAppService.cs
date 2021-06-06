using DesafioTecnico.Data.Models;
using DesafioTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Interfaces
{
    public interface IPessoaAppService
    {
        List<Pessoa> BuscaTodasPessoas();
        Pessoa BuscaPessoa(int id);
        bool AdicionaPessoa(Pessoa pessoa);
        bool RemovePessoa(int id);
        Pessoa AdicionaRenda(int id, Renda valor);
    }
}
