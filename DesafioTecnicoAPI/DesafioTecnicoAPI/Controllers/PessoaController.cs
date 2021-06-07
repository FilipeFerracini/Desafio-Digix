using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Repositories;
using DesafioTecnicoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnicoAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase {
        private IPessoaAppService pessoas;

        public PessoaController(IPessoaAppService _pessoas) {
            this.pessoas = _pessoas;
        }

        [HttpGet("ListarPessoas")]
        public ActionResult<IEnumerable<Pessoa>> BuscarTodasPessoas() {
            return pessoas.BuscarTodasPessoas();
        }

        [HttpPost("BuscarPessoa")]
        public ActionResult<Pessoa> BuscarPessoa(int id) {
            try {
                var pessoa = pessoas.BuscarPessoa(id);
                if (pessoa == null)
                    return NotFound();

                return pessoa;
            } catch (Exception e) {
                return BadRequest();
            }
        }

        [HttpPost("AdicionarPessoa")]
        public ActionResult<string> AdicionarPessoa(Pessoa pessoa) {
            try {
                if (pessoas.AdicionarPessoa(pessoa))
                    return "Pessoa adicionada com sucesso";
                return BadRequest();
            } catch (Exception e) {
                return BadRequest();
            }
        }

        [HttpPost("RemoverPessoa")]
        public ActionResult<string> RemoverPessoa(int id) {
            try {
                if (pessoas.RemoverPessoa(id))
                    return "Pessoa removida com sucesso";
                return "Não foi encontrada nenhuma pessoa com este Id";
            } catch (Exception e) {
                return BadRequest();
            }
        }

        [HttpPost("AdicionarRenda")]
        public ActionResult<string> AdicionarRenda(int id, Renda valor) {
            try {
                if (pessoas.AdicionarRenda(id, valor) != null)
                    return "Renda adicionada com sucesso";

                return "Não foi foi possível adicionar renda a esta pessoa";
            } catch (Exception e) {
                return BadRequest();
            }
        }
    }
}
