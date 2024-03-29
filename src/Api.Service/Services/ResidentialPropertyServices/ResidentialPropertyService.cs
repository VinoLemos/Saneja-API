using Api.Domain.Entities;
using AutoMapper;
using Data.Repository;
using Domain.Dtos.ResidentialPropertyDtos;

namespace Api.Service.Services.ResidencialPropertyServices
{
    public class ResidentialPropertyService
    {
        private readonly ResidentialPropertyRepository _repository;
        private readonly IMapper _mapper;

        public ResidentialPropertyService(ResidentialPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResidentialPropertyDto> Get(Guid propertyId)
        {
            var property = await _repository.SelectAsync(propertyId);
            return _mapper.Map<ResidentialPropertyDto>(property);
        }

        public async Task<ResidentialProperty> GetByRgi(string? rgi)
        {
            return await _repository.SelectByRgi(rgi);
        }

        public async Task<List<ResidentialPropertyDto>> GetUserProperties(Guid userId)
        {
            var properties = await _repository.SelectUserProperties(userId);

            var propertyList = _mapper.Map<List<ResidentialPropertyDto>>(properties);

            return propertyList;
        }

        public async Task<bool> Post(ResidentialPropertyDto residentialProperty, Guid userId)
        {
            try
            {
                var property = _mapper.Map<ResidentialProperty>(residentialProperty);
                var newProperty = await _repository.InsertAsync(property, userId);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Put(ResidentialPropertyDto residentialProperty)
        {
            try
            {
                var currentProperty = _mapper.Map<ResidentialProperty>(residentialProperty);
                var updated = await _repository.UpdateAsync(currentProperty);

                return updated ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}