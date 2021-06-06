using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Models.Enums
{
    public enum StatusFamilia : int
    {
        Cadastro_valido = 0,
        Ja_possui_uma_casa = 1,
        Selecionada_em_outro_processo_de_selecao=2,
        Cadastro_incompleto=3
    }
}
