using AutoMapper;
using ProvaRemota.Domain.Entity;
using ProvaRemota.Domain.Interfaces;
using ProvaRemota.Services.Dtos;
using ProvaRemota.Services.Interfaces;

namespace ProvaRemota.Services
{

    public class SituacaoClienteService : ISituacaoClienteService
    {
        private readonly IMapper _mapper;
        private readonly ISituacaoClienteRepository _situacaoClienteRepository;

        public SituacaoClienteService(IMapper mapper, ISituacaoClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _situacaoClienteRepository = clienteRepository;
        }


        public async Task Add(SituacaoClienteViewModel situacaoClienteViewModel)
        {
            var situacaoCliente = _mapper.Map<SituacaoCliente>(situacaoClienteViewModel);
                    
            await _situacaoClienteRepository.Insert(situacaoCliente);

        }
        public async Task Update(int id, SituacaoClienteViewModel situacaoClienteViewModel)
        {
            var situacaoCliente = _mapper.Map<SituacaoCliente>(situacaoClienteViewModel);

            await _situacaoClienteRepository.Update(id, situacaoCliente);

        }

        public async Task Delete(int id)
        {
            await _situacaoClienteRepository.Delete(id);
        }

        public async Task<SituacaoClienteViewModel> GetSituacaoClienteById(int id)
        {
            var situacaoCliente = await _situacaoClienteRepository.GetById(id);
            return _mapper.Map<SituacaoClienteViewModel>(situacaoCliente);
            
        }
        public async Task<List<SituacaoClienteViewModel>> GetAllSituacaoCliente()
        {
            var situacaoClientes = await _situacaoClienteRepository.GetAll();
            return _mapper.Map<List<SituacaoClienteViewModel>>(situacaoClientes.ToList());
        }

    }

}
