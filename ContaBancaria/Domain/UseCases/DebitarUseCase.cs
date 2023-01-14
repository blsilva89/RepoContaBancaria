using System;
using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;
using ContaBancaria.Domain.Repositories;

namespace ContaBancaria.Domain.UseCases;

public class DebitarUseCase
{
    public Conta conta { get; private set; }
    private readonly IContaRepository contaRepository;

    public DebitarUseCase(IContaRepository contaRepository)
    {
        this.contaRepository = contaRepository;
    }

    public async Task<decimal> Debitar(int codigoConta, decimal valor)
    {
        Conta conta = await this.contaRepository.ObterContaPeloCodigo(codigoConta);
        if (conta.Saldo < valor)
            throw new ArgumentException("Não há saldo suficiente para esta operação");

        conta.Saldo -= valor;
        await this.contaRepository.AtualizarSaldo(conta);

        return conta.Saldo;
    }
}
