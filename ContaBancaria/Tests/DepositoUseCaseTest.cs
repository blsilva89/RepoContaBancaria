using Xunit;
using ContaBancaria.Infra.Entities;
using ContaBancaria.Infra.Repositories;
using ContaBancaria.Domain.UseCases;
using Moq;

namespace ContaBancaria.Tests;

public class DepositoUseCaseTest
{
    [Fact]
    public void Depositar()
    {
        Conta conta = new Conta();

        var mockContaRepo = new Mock<IContaRepository>();
        mockContaRepo.Setup(repo => repo.obterContaPeloCodigo(It.IsAny<int>())).ReturnsAsync(conta);
        IContaRepository contaRepository = mockContaRepo.Object;
        DepositoUseCase useCaseDeposito = new DepositoUseCase(contaRepository);
        decimal saldoAtualizado = useCaseDeposito.depositar(1, 100).Result;

        Assert.Equal(100, saldoAtualizado);
    }
}