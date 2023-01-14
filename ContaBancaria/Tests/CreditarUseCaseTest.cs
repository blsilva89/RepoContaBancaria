using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;
using ContaBancaria.Domain.UseCases;
using Moq;
using Xunit;

namespace Tests
{
    public class CreditarUseCaseTest
    {
        [Fact]
        public void CreditarTest()
        {
            string nome = "cliente";
            string cep = "12345123";
            string cpf = "12345678901";
            string rg = "001112229";
            DateTime dataNascimento = new DateTime(2000, 1, 1);
            Pessoa pessoa = new Fisica(nome, cep, cpf, rg, dataNascimento);
            Agencia agencia = new Agencia();
            Conta conta = new Conta(1, pessoa, agencia);

            var mockContaRepo = new Mock<IContaRepository>();
            mockContaRepo.Setup(repo => repo.ObterContaPeloCodigo(It.IsAny<int>())).ReturnsAsync(conta);
            IContaRepository contaRepository = mockContaRepo.Object;
            CreditarUseCase useCaseDeposito = new CreditarUseCase(contaRepository);
            decimal saldoAtualizado = useCaseDeposito.Creditar(conta.Codigo, 100).Result;

            Assert.Equal(100, saldoAtualizado);
        }
    }
}