using DesafioTecnico.Data.Interfaces;
using DesafioTecnico.Data.Models;
using DesafioTecnico.Data.Models.Enums;
using DesafioTecnico.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnico.Data.Services {
    public class FamiliaAppService : IFamiliaAppService {
        private PessoaContext database;
        private IPessoaAppService pessoaAppService;
        public FamiliaAppService(PessoaContext _database, IPessoaAppService _pessoaAppService) {
            this.database = _database;
            this.pessoaAppService = _pessoaAppService;
        }

        public bool AdicionarFamilia(Familia familia) {
            try {
                if (familia == null)
                    return false;

                database.Familia.Add(familia);
                database.SaveChanges();
                return true;
            } catch (Exception e) {
                throw e;
            }
        }

        public bool AdicionarPessoaFamilia(int idPessoa, int idFamilia) {
            var familia = BuscarFamilia(idFamilia);
            var pessoa = pessoaAppService.BuscaPessoa(idPessoa);

            if (familia != null) {
                familia.AdicionarPessoa(pessoa);
                database.SaveChanges();
                return true;
            }
            return false;
        }

        public Familia BuscarFamilia(int id) {
            return database.Familia
                .Include(f => f.Pessoas)
                .ThenInclude(p => p.ValorRenda)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Familia> BuscarTodasFamilias() {
            return database.Familia
                .Include(f => f.Pessoas)
                .ThenInclude(p => p.ValorRenda)
                .ToList();
        }

        public bool AlterarStatusFamilia(int id, int novoStatus) {
            var familia = BuscarFamilia(id);
            if (familia == null)
                return false;

            switch (novoStatus) {
                case 0:
                    familia.Status = StatusFamilia.Cadastro_valido;
                    break;
                case 1:
                    familia.Status = StatusFamilia.Ja_possui_uma_casa;
                    break;
                case 2:
                    familia.Status = StatusFamilia.Selecionada_em_outro_processo_de_selecao;
                    break;
                case 3:
                    familia.Status = StatusFamilia.Cadastro_incompleto;
                    break;
            }
            database.SaveChanges();
            return true;
        }
    }
}
