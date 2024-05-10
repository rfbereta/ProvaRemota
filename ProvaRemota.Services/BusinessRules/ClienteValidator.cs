using ProvaRemota.Domain.Interfaces;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

namespace ProvaRemota.Services.BusinessRules
{
    public class ClienteValidator : IClienteValidator
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Tuple<bool, string>> ValidarViewModel(ClienteViewModel clienteViewModel)
        {
            bool validado = false;
            string mensagemErro = string.Empty;

            try
            {
                await this.ValidarNomeVazio(clienteViewModel);
                await this.ValidarCPFVazio(clienteViewModel);
                await this.ValidarCPFUnico(clienteViewModel);
                await this.ValidarTipoClienteVazio(clienteViewModel);
                await this.ValidarSexoVazio(clienteViewModel);
                await this.ValidarSituacaoClienteVazio(clienteViewModel);

                validado = true;
            }
            catch (Exception ex)
            {
                mensagemErro = ex.Message;
            }

            return new Tuple<bool, string>(validado, mensagemErro);
        }
        
        private async Task ValidarNomeVazio(ClienteViewModel clienteViewModel)
        {
            if (string.IsNullOrEmpty(clienteViewModel.Nome))
                throw new Exception("O preenchimento do campo Nome é obrigatório");
        }

        private async Task ValidarCPFVazio(ClienteViewModel clienteViewModel)
        {
            if (string.IsNullOrEmpty(clienteViewModel.CPF))
                throw new Exception("O preenchimento do campo CPF é obrigatório");
        }
        private async Task ValidarCPFUnico(ClienteViewModel clienteViewModel)
        {
            //O CPF só é validado a duplicidade na inclusão e na alteração ele não é alterado na query do update para evitar a duplicidade
            if(clienteViewModel.Id == 0)
            {
                var existeCPF = await _clienteRepository.ValidateUniqueCPF(clienteViewModel.CPF);
                if (existeCPF != null)
                    throw new Exception("O CPF informado já existe na base de dados");
            }

        }
        private async Task ValidarTipoClienteVazio(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.TipoClienteId == null || clienteViewModel.TipoClienteId.Value == 0)
                throw new Exception("O preenchimento do campo TipoClienteId é obrigatório");
        }
        private async Task ValidarSexoVazio(ClienteViewModel clienteViewModel)
        {
            if (string.IsNullOrEmpty(clienteViewModel.Nome))
                throw new Exception("O preenchimento do campo Nome é obrigatório");
        }
        private async Task ValidarSituacaoClienteVazio(ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel.SituacaoClienteId == null || clienteViewModel.SituacaoClienteId.Value == 0)
                throw new Exception("O preenchimento do campo SituacaoClienteId é obrigatório");
        }

    }
}
