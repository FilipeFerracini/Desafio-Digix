using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Models.Dto
{
    public class AvaliacaoFamiliarDto
    {
        public int Pontuacao { get; set; }
        public int Criterios { get; set; }
        public int FamiliaId { get; set; }

        public AvaliacaoFamiliarDto(int pontuacao, int criterios, int familiaId)
        {
            Pontuacao = pontuacao;
            Criterios = criterios;
            FamiliaId = familiaId;
        }
    }
}
