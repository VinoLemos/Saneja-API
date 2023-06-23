using Api.Domain.Entities;
using AutoMapper;
using Data.Repository;
using Domain.Dtos.ResidentialPropertyDtos;
using Domain.Dtos.TechnicalVisitDtos;

namespace Api.Service.Services.TechnicalVisitServices
{
    public class TechnicalVisitService
    {
        private readonly TechnicalVisitRepository _repository;
        private readonly ResidentialPropertyRepository _propertyRepository;
        private readonly PersonRepository _personRepository;
        private readonly IMapper _mapper;
        private const int InProgress = 2;
        private const int Canceled = 4;

        public TechnicalVisitService(TechnicalVisitRepository repository, ResidentialPropertyRepository propertyRepository, PersonRepository personRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyRepository = propertyRepository;
            _personRepository = personRepository;
        }

        public async Task<TechnicalVisitDto> Get(Guid id)
        {
            var visit = await _repository.SelectAsync(id);

            return _mapper.Map<TechnicalVisitDto>(visit);
        }

        public List<VisitStatusDto> GetVisitStatuses()
        {
            var statuses = _repository.SelectStatusList();

            var statusList = new List<VisitStatusDto>();

            statuses.ForEach(st =>
            {
                statusList.Add(new VisitStatusDto
                {
                    Id = st.Id,
                    Status = st.Status
                });
            });

            return statusList;
        }

        public async Task<TechnicalVisitDetailsDto> GetVisitDetails(Guid visitId)
        {
            var visit = await _repository.SelectAsync(visitId);

            if (visit == null) return null;

            var property = await _propertyRepository.SelectAsync(visit.ResidencialPropertyId);
            var propertyDto = _mapper.Map<ResidentialPropertyDto>(property);
            var propertyOwner = await _personRepository.SelectAsync(property.PersonId);
            var agent = visit.UserId != null ? await _personRepository.SelectUserAsync((Guid)visit.UserId) : null;
            var statuses = _repository.SelectStatusList();

            return new TechnicalVisitDetailsDto()
            {
                VisitId = visit.Id,
                AgentId = visit.UserId ?? null,
                VisitStatusId = visit.StatusId,
                PropertyOwner = propertyOwner.Name ?? "",
                AgentName = agent != null ? agent.Name : "",
                VisitStatus = statuses.FirstOrDefault(v => v.Id == visit.StatusId).Status,
                Property = propertyDto,
                VisitRequestDate = visit.VisitDate,
                HomologationDate = visit.UpdatedAt != DateTime.MinValue? visit.UpdatedAt : null,
                ReturnDate = visit.ReturnDate != DateTime.MinValue? visit.ReturnDate : null
            };
        }

        public IEnumerable<TechnicalVisitDto> GetPendingVisits()
        {
            var visits = _repository.SelectPendingVisits();

            var visitsDto = _mapper.Map<List<TechnicalVisitDto>>(visits);

            visitsDto.ForEach(async dto =>
            {
                var owner = _repository.SelectUserByPropertyId(dto.ResidencialPropertyId);
                dto.PropertyOwner = owner.Name;
                var statuses = _repository.SelectStatusList();
                dto.Status = statuses.FirstOrDefault(v => v.Id == dto.StatusId).Status;
            });

            return visitsDto;
        }

        public IEnumerable<TechnicalVisitDto> SelectCanceledVisits()
        {
            var visits = _repository.SelectCanceledVisits();

            var visitsDto = _mapper.Map<List<TechnicalVisitDto>>(visits);

            visitsDto.ForEach(async dto =>
            {
                var owner = _repository.SelectUserByPropertyId(dto.ResidencialPropertyId);
                dto.PropertyOwner = owner.Name;
                var statuses = _repository.SelectStatusList();
                dto.Status = statuses.FirstOrDefault(v => v.Id == dto.StatusId).Status;
            });

            return visitsDto;
        }

        public List<TechnicalVisitDto> GetAgentVisits(Guid agentId)
        {
            var visits = _repository.SelectAgentVisits(agentId);

            var visitsDto = _mapper.Map<List<TechnicalVisitDto>>(visits);

            visitsDto.ForEach(async dto =>
            {
                var owner = _repository.SelectUserByPropertyId(dto.ResidencialPropertyId);
                dto.PropertyOwner = owner.Name;
                var statuses = _repository.SelectStatusList();
                dto.Status = statuses.FirstOrDefault(v => v.Id == dto.StatusId).Status;
            });

            return visitsDto;
        }
        public List<TechnicalVisitDetailsDto> GetPersonVisits(Guid personId)
        {
            var visits = _repository.SelectPersonVisits(personId);

            var visitsDto = new List<TechnicalVisitDetailsDto>();

            var visitStatuses = _repository.SelectStatusList();

            visits.ForEach(async v =>
            {
                var status = visitStatuses.FirstOrDefault(st => st.Id == v.StatusId);
                var owner = _repository.SelectUserByPropertyId(v.ResidencialPropertyId);
                var property = _propertyRepository.Select(v.ResidencialPropertyId);
                var propertyDto = _mapper.Map<ResidentialPropertyDto>(property);

                visitsDto.Add(new TechnicalVisitDetailsDto
                {
                    VisitId = v.Id,
                    Property = propertyDto,
                    Homologated = v.Homologated,
                    HomologationDate = v.HomologationDate,
                    Observation = v.Observation,
                    ReturnDate = v.ReturnDate,
                    VisitStatusId = v.StatusId,
                    VisitStatus = status.Status,
                    AgentId = v.UserId,
                    VisitRequestDate = v.VisitDate,
                    PropertyOwner = owner.Name
                });
            });

            return visitsDto;
        }

        public async Task<bool> Post(TechnicalVisitCreateDto technicalVisit)
        {
            try
            {
                var visit = _mapper.Map<TechnicalVisit>(technicalVisit);
                var created = await _repository.InsertAsync(visit, technicalVisit.ResidentialPropertyId);

                return created != null;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public bool AcceptVisit(Guid visitId, Guid agentId)
        {
            var accepted = _repository.AcceptVisit(visitId, agentId);

            return accepted;
        }

        public async Task<bool> FinishVisit(Guid visitId)
        {
            var finished = await _repository.FinishVisit(visitId);

            return finished;
        }

        public bool PostVisitObservation(TechnicalVisitObservationDto observation)
        {
            try
            {
                var posted = _repository.UpdateVisitObservation(observation.VisitId, observation.Observation);

                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public async Task<bool> CancelVisit(Guid visitId)
        {
            try
            {
                var visit = await _repository.SelectAsync(visitId);

                return await _repository.CancelVisit(visitId);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}