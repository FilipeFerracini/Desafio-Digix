using System;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DesafioTecnico.Data.Repositories;
using DesafioTecnicoAPI.Models;
using DesafioTecnicoAPI.Controllers;
using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Services;

namespace Tests {
    public class PessoaUnitTest {
        [Fact]
        public void ConsultarPessoa() {
            //arrange
            var context = new Mock<IPessoaAppService>();
            var pessoaId = 1;
            var tipo = TipoPessoa.Pretendente;
            var nome = "João";
            var dataNascimento = new DateTime(1991, 03, 04);
            context.Setup(p => p.BuscarPessoa(It.IsAny<int>())).Returns(new Pessoa() { Id = 1, Nome = "João", Tipo = TipoPessoa.Pretendente, DataDeNascimento = new DateTime(1991, 03, 04) });
            var controller = new PessoaController(context.Object);

            //act
            var response = controller.BuscarPessoa(pessoaId);

            //Assert
            Assert.Equal(pessoaId, response.Value.Id);
            Assert.Equal(nome, response.Value.Nome);
            Assert.Equal(tipo, response.Value.Tipo);
            Assert.Equal(dataNascimento, response.Value.DataDeNascimento);
        } 
    }
}
