using System.Threading.Tasks;
using ContaBancaria.Domain.Entities;

namespace ContaBancaria.Domain.Repositories
{
    public interface IAgenciaRepository
    {
        public Task<Agencia> obterAgenciaPeloId(int codigoAgencia);
    }
}