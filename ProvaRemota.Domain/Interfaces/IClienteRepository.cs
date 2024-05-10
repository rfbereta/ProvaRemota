using ProvaRemota.Domain.Entity;

namespace ProvaRemota.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetById(int id);
        Task<IEnumerable<Cliente>> GetAll();
        Task Insert(Cliente cliente);
        Task Update(int id, Cliente cliente);
        Task Delete(int id);
        Task<Cliente> ValidateUniqueCPF(string CPF);

    }

}
