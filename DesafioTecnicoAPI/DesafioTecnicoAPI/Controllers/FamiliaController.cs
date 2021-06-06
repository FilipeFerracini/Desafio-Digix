using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnicoAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase {
        private IFamiliaAppService familias;
        public FamiliaController(IFamiliaAppService _familias) {
            this.familias = _familias;
        }

        [HttpGet("ListaFamilias")]
        public ActionResult<List<Familia>> BuscarTodasFamilias() {
            return familias.BuscarTodasFamilias();
        }

        [HttpPost("BuscarFamilia")]
        public ActionResult<Familia> BuscarFamilia(int id) {
            var familia = familias.BuscarFamilia(id);
            if (familia == null)
                return NotFound();

            return familia;
        }

        [HttpPost("AdicionarFamilia")]
        public string AdicionarFamilia(Familia familia) {
            try {
                if (familias.AdicionarFamilia(familia))
                    return "Família adicionada com sucesso";
                return "Ocorreu algum erro";
            } catch (Exception e) {
                return "Ocorreu algum erro";
            }
        }

        [HttpPost("AdicionarPessoaFamilia")]
        public string AdicionarPessoaFamilia(int idPessoa, int idFamilia) {
            var retorno = familias.AdicionarPessoaFamilia(idPessoa, idFamilia);
            if (retorno)
                return "Pessoa adicionada à família com sucesso";

            return "Ocorreu um erro ao adicionar a Pessoa à família";
        }

        [HttpPost("AlterarStatusFamilia")]
        public string AlterarStatusFamilia(int idFamilia, int novoStatus) {
            try {
                familias.AlterarStatusFamilia(idFamilia, novoStatus);
                return "Status da família alterado com sucesso";
            } catch (Exception e) {
                return "Não foi possível alterar o Status da família";
            }
        }
    }
}
