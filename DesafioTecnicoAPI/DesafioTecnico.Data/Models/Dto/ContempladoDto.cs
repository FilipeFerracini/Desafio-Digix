using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Models.Dto {
    public class ContempladoDto : AvaliacaoFamiliarDto {
        public DateTime DataSelecao { get; set; }

        public ContempladoDto(int pontuacao, int criterios, int familiaId, DateTime dataSelecao) : base(pontuacao, criterios, familiaId) {
            DataSelecao = dataSelecao;
        }
    }
}
