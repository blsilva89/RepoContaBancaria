using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;

namespace Domain.UseCases
{
    public class CadastroTitularUseCase
    {
        private readonly IPessoaRepository pessoaRepository;

        public CadastroTitularUseCase(IPessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }

        public async Task CadastrarPessoaFisica(string nome, string cep, string cpf, DateTime dataNascimento, string rg)
        {
            Fisica pessoaFisica = new Fisica(nome, cep, cpf, rg, dataNascimento);

            await this.pessoaRepository.gravarPessoaFisica(pessoaFisica);
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