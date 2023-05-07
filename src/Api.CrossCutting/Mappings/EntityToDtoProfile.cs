using Api.Domain.Entities;
using AutoMapper;
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
        }
    }
}
