using ProvaRemota.Domain.Entity;

namespace ProvaRemota.Domain.Interfaces
{
    public interface ITipoClienteRepository
    {
        Task<TipoCliente> GetById(int id);
        Task<IEnumerable<TipoCliente>> GetAll();
        Task Insert(TipoCliente tipoCliente);
        Task Update(int id, TipoCliente tipoCliente);
        Task Delete(int id);
    }

}
