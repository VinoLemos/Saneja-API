using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.ResidentialPropertyDtos;
using Domain.Dtos.TechnicalVisitDtos;
using Domain.Dtos.User;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateResultDto, User>().ReverseMap();
            CreateMap<UserUpdateResultDto, User>().ReverseMap();
            CreateMap<UserDetailsDto, User>().ReverseMap();
            CreateMap<TechnicalVisitDto, TechnicalVisit>().ReverseMap();
            CreateMap<TechnicalVisitCreateDto, TechnicalVisit>().ReverseMap();
            CreateMap<ResidentialPropertyDto, ResidentialProperty>().ReverseMap();
        }
    }
}
