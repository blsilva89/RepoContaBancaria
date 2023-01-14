using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;

namespace ContaBancaria.Domain.UseCases
{
    public class CadastroPessoaJuridicaUseCase
    {
        private readonly IPessoaRepository pessoaRepository;

        public CadastroPessoaJuridicaUseCase(IPessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }
        public async Task CadastrarPessoaJuridica(string nome, string cep, string cnpj, string inscricaoEstadual, string nomeFantasia)
        {
            Juridica pessoaJuridica = new Juridica(nome, cep, cnpj);
            pessoaJuridica.InscricaoEstadual = inscricaoEstadual;
            pessoaJuridica.NomeFantasia = nomeFantasia;

            await this.pessoaRepository.gravarPessoaJuridica(pessoaJuridica);
        }
    }
}