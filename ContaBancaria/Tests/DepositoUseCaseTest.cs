using Xunit;
// using ContaBancaria.Infra.Entities;
using ContaBancaria.Infra.Repositories;
using ContaBancaria.Domain.UseCases;
using Moq;
using ContaBancaria.Domain.Repositories;
using ContaBancaria.Domain.Entities;
using System;

namespace ContaBancaria.Tests;

public class DepositoUseCaseTest
{
    [Fact]
    public void Depositar()
    {
        string nome = "cliente";
        string cep = "12345123";
        string cpf = "12345678901";
        string rg = "001112229";
        DateTime dataNascimento = new DateTime(2000, 1, 1);
        Pessoa pessoa = new Fisica(nome, cep, cpf, rg, dataNascimento);
        Agencia agencia = new Agencia();
        Conta conta = new Conta(1, pessoa, agencia);
        conta.Saldo = 100;

        var mockContaRepo = new Mock<IContaRepository>();
        mockContaRepo.Setup(repo => repo.ObterContaPeloCodigo(It.IsAny<int>())).ReturnsAsync(conta);
        IContaRepository contaRepository = mockContaRepo.Object;
        DebitarUseCase useCaseDeposito = new DebitarUseCase(contaRepository);
        decimal saldoAtualizado = useCaseDeposito.Debitar(conta.Codigo, 100).Result;

        Assert.Equal(0, saldoAtualizado);
    }
}