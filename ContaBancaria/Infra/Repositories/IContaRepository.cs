using System.Threading.Tasks;
using ContaBancaria.Infra.Entities;


namespace ContaBancaria.Infra.Repositories
{
    public interface IContaRepository
    {
        public Task<Conta> obterContaPeloCodigo(int codigoConta);
    }
}