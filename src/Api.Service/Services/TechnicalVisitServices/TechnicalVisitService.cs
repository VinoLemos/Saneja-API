using Api.Domain.Entities;
using AutoMapper;
using Data.Repository;
using Domain.Dtos.TechnicalVisitDtos;

namespace Api.Service.Services.TechnicalVisitServices
{
    public class TechnicalVisitService
    {
        private readonly TechnicalVisitRepository _repository;
        private readonly IMapper _mapper;
        private const int InProgress = 2;
        private const int Canceled = 4;

        public TechnicalVisitService(TechnicalVisitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TechnicalVisitDto> Get(Guid id)
        {
            var visit = await _repository.SelectAsync(id);

            return _mapper.Map<TechnicalVisitDto>(visit);
        }

        public async Task<List<TechnicalVisitDto>> GetAgentVisits(Guid agentId)
        {
            var visits = await _repository.SelectAgentVisits(agentId);

            var visitsDto = _mapper.Map<List<TechnicalVisitDto>>(visits);

            return visitsDto;
        }
        public async Task<List<TechnicalVisitDto>> GetPersonVisits(Guid personId)
        {
            var visits = await _repository.SelectPersonVisits(personId);

            var visitsDto = new List<TechnicalVisitDto>();

            var visitStatuses = await _repository.SelectStatusListAsync();

            visits.ForEach(v =>
            {
                var status = visitStatuses.FirstOrDefault(st => st.Id == v.StatusId);

                visitsDto.Add(new TechnicalVisitDto
                {
                    Id = v.Id,
                    ResidentialPropertyId = v.ResidencialPropertyId,
                    Homologated = v.Homologated,
                    HomologationDate = v.HomologationDate,
                    Observation = v.Observation,
                    ReturnDate = v.ReturnDate,
                    StatusId = v.StatusId,
                    Status = status.Status,
                    UserId = v.UserId,
                    VisitDate = v.VisitDate
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

                if (visit == null) throw new ArgumentException("Visita não encontrada.");

                return await _repository.CancelVisit(visitId);
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