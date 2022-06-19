using AutoMapper;
using ProyectoPruebaAleix.Domain;

namespace ProyectoPruebaAleix.Infrastructure.Settings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ClientDto, Client>().ReverseMap();
        }
    }
}
