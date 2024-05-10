using AutoMapper;
using ProvaRemota.Domain.Entity;
using ProvaRemota.Domain.Interfaces;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

namespace ProvaRemota.Services
{

    public class TipoClienteService : ITipoClienteService
    {
        private readonly IMapper _mapper;
        private readonly ITipoClienteRepository _tipoClienteRepository;

        public TipoClienteService(IMapper mapper, ITipoClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _tipoClienteRepository = clienteRepository;
        }


        public async Task Add(TipoClienteViewModel tipoClienteViewModel)
        {
            var tipoCliente = _mapper.Map<TipoCliente>(tipoClienteViewModel);
                    
            await _tipoClienteRepository.Insert(tipoCliente);

        }
        public async Task Update(int id, TipoClienteViewModel tipoClienteViewModel)
        {
            var tipoCliente = _mapper.Map<TipoCliente>(tipoClienteViewModel);

            await _tipoClienteRepository.Update(id, tipoCliente);

        }

        public async Task Delete(int id)
        {
            await _tipoClienteRepository.Delete(id);
        }

        public async Task<TipoClienteViewModel> GetTipoClienteById(int id)
        {
            var tipoCliente = await _tipoClienteRepository.GetById(id);
            return _mapper.Map<TipoClienteViewModel>(tipoCliente);
            
        }
        public async Task<List<TipoClienteViewModel>> GetAllTipoCliente()
        {
            var tipoClientes = await _tipoClienteRepository.GetAll();
            return _mapper.Map<List<TipoClienteViewModel>>(tipoClientes.ToList());
        }

    }

}
