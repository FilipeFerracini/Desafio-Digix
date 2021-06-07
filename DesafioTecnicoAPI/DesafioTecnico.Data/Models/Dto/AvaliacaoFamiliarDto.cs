using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Models.Dto
{
    public class AvaliacaoFamiliarDto
    {
        public int FamiliaId { get; set; }
        public int Pontuacao { get; set; }
        public int Criterios { get; set; }

        public AvaliacaoFamiliarDto(int familiaId, int pontuacao, int criterios)
        {
            FamiliaId = familiaId;
            Pontuacao = pontuacao;
            Criterios = criterios;
        }
    }
}
