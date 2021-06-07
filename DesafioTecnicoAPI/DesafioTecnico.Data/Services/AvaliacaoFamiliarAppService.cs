using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Models.Dto;
using DesafioTecnico.Data.Models.Enums;
using DesafioTecnico.Data.Repositories;
using DesafioTecnicoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Services {
    public class AvaliacaoFamiliarAppService : IAvaliacaoFamiliarAppService {
        private PessoaContext database;
        private IFamiliaAppService familiaAppService;

        public AvaliacaoFamiliarAppService(PessoaContext _database, IFamiliaAppService _familiaAppService) {
            this.database = _database;
            this.familiaAppService = _familiaAppService;
        }

        public AvaliacaoFamiliarDto PontuarFamilia(int id) {
            try {
                var criterios = 0;
                var pontuacao = 0;
                var dependentes = 0;
                Familia familia = familiaAppService.BuscarFamilia(id);

                if (familia == null)
                    return null;

                var renda = 0.0;
                foreach (Pessoa pessoa in familia.Pessoas) {
                    if (pessoa.ValorRenda != null)
                        renda += pessoa.ValorRenda.ValorRenda;

                    if (pessoa.Tipo == TipoPessoa.Pretendente) {
                        var idadePretendente = DateTime.Today.Year - pessoa.DataDeNascimento.Year;
                        if (DateTime.Today.DayOfYear < pessoa.DataDeNascimento.DayOfYear)
                            idadePretendente--;

                        if (idadePretendente < 30)
                            pontuacao++;
                        else if (idadePretendente < 45)
                            pontuacao += 3;
                        else
                            pontuacao += 5;
                        criterios++;
                    }

                    if (pessoa.Tipo == TipoPessoa.Dependente) {
                        var idadeDependente = DateTime.Today.Year - pessoa.DataDeNascimento.Year;
                        if (DateTime.Today.DayOfYear < pessoa.DataDeNascimento.DayOfYear)
                            idadeDependente--;

                        if (idadeDependente < 18)
                            dependentes++;
                    }
                }
                if (renda <= 2000.0) {
                    criterios++;

                    if (renda <= 900.0)
                        pontuacao += 5;
                    else if (renda <= 1500.0)
                        pontuacao += 3;
                    else if (renda <= 2000.0)
                        pontuacao += 1;
                }
                if (dependentes > 0) {
                    criterios++;
                    if (dependentes >= 3)
                        pontuacao += 3;
                    else if (dependentes >= 1)
                        pontuacao += 2;
                }

                return new AvaliacaoFamiliarDto(pontuacao, criterios, id);
            } catch (Exception e) {
                throw e;
            }
        }

        public List<AvaliacaoFamiliarDto> ListarFamiliasValidasPontuadas() {
            try {
                var familias = familiaAppService.BuscarTodasFamilias();
                var familiasAptas = new List<AvaliacaoFamiliarDto>();

                foreach (Familia familia in familias) {
                    if (familia.Status == StatusFamilia.Cadastro_valido) {
                        AvaliacaoFamiliarDto familiaAvaliada = PontuarFamilia(familia.Id);
                        familiasAptas.Add(familiaAvaliada);
                    }
                }

                return familiasAptas.OrderByDescending(x => x.Pontuacao).ToList();
            } catch (Exception e) {
                throw e;
            }
        }

        public ContempladoDto ObterFamiliaContemplada() {
            try {
                var familia = ListarFamiliasValidasPontuadas().FirstOrDefault();

                return new ContempladoDto(familia.Pontuacao, familia.Criterios, familia.FamiliaId, DateTime.Today);
            } catch (Exception e) {
                throw e;
            }
        }
    }
}
