using Domain.Dtos.User;
using Domain.Models;
using AutoMapper;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}
