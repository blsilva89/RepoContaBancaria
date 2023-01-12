using System;
using System.Threading.Tasks;
using ContaBancaria.Infra.Entities;
using ContaBancaria.Infra.Repositories;

namespace ContaBancaria.Domain.UseCases;

public class DepositoUseCase
{
    public Conta conta { get; private set; }
    private readonly IContaRepository contaRepository;

    public DepositoUseCase(IContaRepository contaRepository)
    {
        this.contaRepository = contaRepository;
    }

    public async Task<decimal> depositar(int codigoConta, decimal valor)
    {
        conta = await this.contaRepository.obterContaPeloCodigo(codigoConta);
        conta.Saldo += valor;

        return conta.Saldo;
    }
}
