using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;

namespace Domain.UseCases
{
    public class CadastroPessoaFisicaUseCase
    {
        private readonly IPessoaRepository pessoaRepository;

        public CadastroPessoaFisicaUseCase(IPessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }

        public async Task CadastrarPessoaFisica(string nome, string cep, string cpf, DateTime dataNascimento, string rg)
        {
            Fisica pessoaFisica = new Fisica(nome, cep, cpf, rg, dataNascimento);

            if (DateTime.Now.Date.Ticks - dataNascimento.Date.Ticks < 18)
                throw new ArgumentException("Não é permitido pessoas menores de dezoito anos");

            await this.pessoaRepository.gravarPessoaFisica(pessoaFisica);
        }
        
    }
}