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
        List<Pessoa> BuscarTodasPessoas();
        Pessoa BuscarPessoa(int id);
        bool AdicionarPessoa(Pessoa pessoa);
        bool RemoverPessoa(int id);
        Pessoa AdicionarRenda(int id, Renda valor);
    }
}
