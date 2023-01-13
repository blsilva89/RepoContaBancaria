using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;

namespace ContaBancaria.Domain.Repositories
{
    public interface IPessoaRepository
    {
        public Task<Fisica> obterPessoaPeloId(int codigoPessoa);
        public Task<Fisica> obterPessoaFisicaPeloCpf(string cpf);
        public Task<Juridica> obterPessoaJuridicaPeloCnpj(string cnpj);
        public Task gravarPessoaFisica(Fisica pessoaFisica);
        public Task gravarPessoaJuridica(Juridica pessoaJuridica);
    }
}