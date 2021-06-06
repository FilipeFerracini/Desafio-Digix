using DesafioTecnico.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Interfaces
{
    public interface IFamiliaAppService
    {
        bool AdicionarFamilia(Familia familia);
        Familia BuscarFamilia(int id);
        List<Familia> BuscarTodasFamilias();
        bool AdicionarPessoaFamilia(int idPessoa, int idFamilia);
    }
}
