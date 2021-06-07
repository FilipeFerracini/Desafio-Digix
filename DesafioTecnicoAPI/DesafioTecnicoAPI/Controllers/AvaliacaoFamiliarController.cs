using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnicoAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoFamiliarController : ControllerBase {
        private IAvaliacaoFamiliarAppService avaliacaoFamiliar;

        public AvaliacaoFamiliarController(IAvaliacaoFamiliarAppService _avaliacaoFamiliar) {
            this.avaliacaoFamiliar = _avaliacaoFamiliar;
        }

        [HttpGet("ListarFamiliasValidasPontuadas")]
        public ActionResult<List<AvaliacaoFamiliarDto>> ListarFamiliasValidasPontuadas() {
            try {
                return avaliacaoFamiliar.ListarFamiliasValidasPontuadas();
            } catch (Exception e) {
                return BadRequest();
            }
        }


        [HttpPost("PontuarFamilia")]
        public ActionResult<AvaliacaoFamiliarDto> PontuarFamilia(int id) {
            try {
                return avaliacaoFamiliar.PontuarFamilia(id);
            } catch (Exception e) {
                return BadRequest();
            }
        }

        [HttpGet("ObterFamiliaContemplada")]
        public ActionResult<ContempladoDto> ObterFamiliaContemplada() {
            try {
                return avaliacaoFamiliar.ObterFamiliaContemplada();
            } catch (Exception e) {
                return BadRequest();
            }
        }
    }
}
