using AutoMapper;
using BackAPI.DTO;
using BackAPI.Model;

namespace BackAPI.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
