using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;

namespace ContaBancaria.Domain.Repositories
{
    public interface IContaRepository
    {
        public Task CriarConta(Conta conta);
        public Task<Conta> ObterContaPeloCodigo(int codigoConta);
        public Task AtualizarSaldo(Conta conta);
    }
}