using Api.Domain.Entities;
using AutoMapper;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class UserModelToEntityProfile : Profile
    {
        public UserModelToEntityProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
