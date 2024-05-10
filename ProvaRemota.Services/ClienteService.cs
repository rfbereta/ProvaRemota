using AutoMapper;
using ProvaRemota.Domain.Entity;
using ProvaRemota.Domain.Interfaces;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

namespace ProvaRemota.Services
{

    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteValidator _clienteValidador;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository, IClienteValidator clienteValidator)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _clienteValidador = clienteValidator;
        }


        public async Task Add(ClienteViewModel clienteViewModel)
        {
            Tuple<bool, string> tupleClienteValidator = await _clienteValidador.ValidarViewModel(clienteViewModel);

            if (!tupleClienteValidator.Item1)
                throw new Exception(tupleClienteValidator.Item2);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
                    
            await _clienteRepository.Insert(cliente);

        }
        public async Task Update(int id, ClienteViewModel clienteViewModel)
        {
            Tuple<bool, string> tupleClienteValidator = await _clienteValidador.ValidarViewModel(clienteViewModel);

            if (!tupleClienteValidator.Item1)
                throw new Exception(tupleClienteValidator.Item2);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            await _clienteRepository.Update(id, cliente);

        }

        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
        }

        public async Task<ClienteViewModel> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteViewModel>(cliente);
            
        }
        public async Task<List<ClienteViewModel>> GetAllCliente()
        {
            var clientes = await _clienteRepository.GetAll();
            return _mapper.Map<List<ClienteViewModel>>(clientes.ToList());
        }

    }

}
