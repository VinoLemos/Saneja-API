using Api.Domain.Entities;
using AutoMapper;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<BaseUser, UserModel>().ReverseMap();
        }
    }
}
