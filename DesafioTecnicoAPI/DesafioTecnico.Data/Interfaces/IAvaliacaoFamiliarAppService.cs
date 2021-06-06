using DesafioTecnico.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Interfaces
{
    public interface IAvaliacaoFamiliarAppService
    {
        List<AvaliacaoFamiliarDto> ListarFamiliasValidasPontuadas();
        AvaliacaoFamiliarDto PontuarFamilia(int id);
        ContempladoDto ObterFamiliaContemplada();
    }
}
