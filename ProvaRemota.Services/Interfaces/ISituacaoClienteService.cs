using ProvaRemota.Services.Dtos;

namespace ProvaRemota.Services.Interfaces
{
    public interface ISituacaoClienteService
    {
        Task Add(SituacaoClienteViewModel situacaoClienteViewModel);
        Task Update(int id, SituacaoClienteViewModel situacaoClienteViewModel);
        Task Delete(int id);
        Task<SituacaoClienteViewModel> GetSituacaoClienteById(int id);
        Task<List<SituacaoClienteViewModel>> GetAllSituacaoCliente();

    }
}
