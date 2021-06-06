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

namespace DesafioTecnicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaAppService pessoas;

        public PessoaController(IPessoaAppService _pessoas)
        {
            this.pessoas = _pessoas;
        }

        [HttpGet("ListaPessoas")]
        public ActionResult<IEnumerable<Pessoa>> BuscaTodasPessoas()
        {
            return pessoas.BuscaTodasPessoas();
        }

        [HttpPost("BuscarPessoa")]
        public ActionResult<Pessoa> BuscaPessoa(int id)
        {
            var pessoa = pessoas.BuscaPessoa(id);
            if (pessoa == null)
                return NotFound();

            return pessoa;
        }

        [HttpPost("AdicionarPessoa")]
        public ActionResult<string> AdicionaPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoas.AdicionaPessoa(pessoa))
                    return "Pessoa adicionada com sucesso";
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("RemoverPessoa")]
        public ActionResult<string> RemovePessoa(int id)
        {
            if (pessoas.RemovePessoa(id))
                return "Pessoa removida com sucesso";
            return "Não foi encontrada nenhuma pessoa com este Id";
        }

        [HttpPost("AdicionarRenda")]
        public ActionResult<string> AdicionaRenda(int id, Renda valor)
        {
            if (pessoas.AdicionaRenda(id, valor) != null)
                return "Renda adicionada com sucesso";

            return "Não foi foi possível adicionar renda a esta pessoa";
        }
    }
}
