using ProvaRemota.Domain.Entity;

namespace ProvaRemota.Domain.Interfaces
{
    public interface ISituacaoClienteRepository
    {
        Task<SituacaoCliente> GetById(int id);
        Task<IEnumerable<SituacaoCliente>> GetAll();
        Task Insert(SituacaoCliente situacaoCliente);
        Task Update(int id, SituacaoCliente situacaoCliente);
        Task Delete(int id);
    }

}
