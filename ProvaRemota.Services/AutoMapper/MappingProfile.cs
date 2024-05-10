using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaRemota.Services.AutoMapper
{
    using AutoMapper;
    using global::AutoMapper;
    using ProvaRemota.Domain.Entity;
    using ProvaRemota.Services.Dtos;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TipoClienteViewModel, TipoCliente>().ReverseMap();
            CreateMap<SituacaoClienteViewModel, SituacaoCliente>().ReverseMap();

            CreateMap<ClienteViewModel, Cliente>().ReverseMap();

        }
    }

}
