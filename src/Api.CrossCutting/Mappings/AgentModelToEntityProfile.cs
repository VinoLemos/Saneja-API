using Api.Domain.Entities;
using AutoMapper;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class AgentModelToEntityProfile : Profile
    {
        public AgentModelToEntityProfile()
        {
            CreateMap<Agent, UserModel>().ReverseMap();
        }
    }
}
