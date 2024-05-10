using ProvaRemota.Services.Dtos;

namespace ProvaRemota.Services.Interfaces
{
    public interface ITipoClienteService
    {
        Task Add(TipoClienteViewModel tipoClienteViewModel);
        Task Update(int id, TipoClienteViewModel tipoClienteViewModel);
        Task Delete(int id);
        Task<TipoClienteViewModel> GetTipoClienteById(int id);
        Task<List<TipoClienteViewModel>> GetAllTipoCliente();

    }
}
