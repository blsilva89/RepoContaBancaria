using System;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;

namespace ContaBancaria.Domain.UseCases;

public class CreditarUseCase
{
    public Conta conta { get; private set; }
    private readonly IContaRepository contaRepository;

    public CreditarUseCase(IContaRepository contaRepository)
    {
        this.contaRepository = contaRepository;
    }

    public async Task<decimal> creditar(int codigoConta, decimal valor)
    {
        Conta conta = await this.contaRepository.ObterContaPeloCodigo(codigoConta);
        conta.Saldo += valor;
        await this.contaRepository.AtualizarSaldo(conta);

        return conta.Saldo;
    }
}
