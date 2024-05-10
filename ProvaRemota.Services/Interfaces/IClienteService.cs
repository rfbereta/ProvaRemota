using ProvaRemota.Services.Dtos;

namespace ProvaRemota.Services.Interfaces
{
    public interface IClienteService
    {
        Task Add(ClienteViewModel clienteViewModel);
        Task Update(int id, ClienteViewModel clienteViewModel);
        Task Delete(int id);
        Task<ClienteViewModel> GetClienteById(int id);
        Task<List<ClienteViewModel>> GetAllCliente();

    }
}
