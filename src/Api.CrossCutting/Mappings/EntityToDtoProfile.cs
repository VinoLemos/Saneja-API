using Api.Domain.Entities;
using AutoMapper;
using Domain.Dtos.User;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, BaseUser>().ReverseMap();
            CreateMap<UserCreateResultDto, BaseUser>().ReverseMap();
            CreateMap<UserUpdateResultDto, BaseUser>().ReverseMap();
        }
    }
}
