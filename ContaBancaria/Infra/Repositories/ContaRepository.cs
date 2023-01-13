using System;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;
using ContaBancaria.Infra.Database;
using ContaBancaria.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Infra.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaBancariaDbContext dbContext;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IAgenciaRepository agenciaRepository;

        public ContaRepository(ContaBancariaDbContext dbContext, IAgenciaRepository agenciaRepository, IPessoaRepository pessoaRepository)
        {
            this.agenciaRepository = agenciaRepository;
            this.dbContext = dbContext;
            this.pessoaRepository = pessoaRepository;
        }
        public async Task AtualizarSaldo(Conta conta)
        {
            TbConta? entidadeConta = await dbContext.TbConta.FirstOrDefaultAsync(c => c.CodConta == conta.Codigo);

            if (entidadeConta is null)
                throw new ArgumentNullException("Conta não localizada");

            entidadeConta.Saldo = conta.Saldo;
            dbContext.TbConta.Update(entidadeConta);
            await dbContext.SaveChangesAsync();
        }

        public async Task CriarConta(Conta conta)
        {
            TbConta entidadeConta = new TbConta()
            {
                CodAgencia = conta.Agencia.CodAgencia,
                CodPessoa = conta.Titular.CodPessoa,
                DataAbertura = conta.DataAbertura,
                Saldo = conta.Saldo
            };

            dbContext.TbConta.Add(entidadeConta);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Conta> ObterContaPeloCodigo(int codigoConta)
        {
            TbConta? entidadeConta = await dbContext.TbConta.FirstOrDefaultAsync(c => c.CodConta == codigoConta);

            if (entidadeConta is null)
                throw new ArgumentNullException("Conta não localizada");

            Pessoa pessoa = await this.pessoaRepository.obterPessoaPeloId(entidadeConta.CodPessoa);
            Agencia agencia = await this.agenciaRepository.obterAgenciaPeloId(entidadeConta.CodAgencia);

            return new Conta(codigoConta, pessoa, agencia);
        }
    }
}