using AutoMapper;
using EncryptionSoftware.Application.Dto;
using EncryptionSoftware.Domain;

namespace EncryptionSoftware.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Productos, ProductDto>().ReverseMap();
            CreateMap<Frases, FrasesDto>().ReverseMap();
        }
    }
}