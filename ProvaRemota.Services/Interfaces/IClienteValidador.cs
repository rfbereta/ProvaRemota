using ProvaRemota.Services.Dtos;

namespace ProvaRemota.Services.Interfaces
{
    public interface IClienteValidator
    {

        Task<Tuple<bool, string>> ValidarViewModel(ClienteViewModel clienteViewModel);
    }
}
