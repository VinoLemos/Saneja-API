using Domain.Dtos.User;
using Domain.Models;
using AutoMapper;
using Api.Domain.Entities;
using Domain.Dtos.TechnicalVisitDtos;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserCreateDto>().ReverseMap();
            CreateMap<UserModel, UserUpdateDto>().ReverseMap();
            CreateMap<UserModel, UserDetailsDto>().ReverseMap();
            CreateMap<TechnicalVisit, TechnicalVisitDto>().ReverseMap();
        }
    }
}
