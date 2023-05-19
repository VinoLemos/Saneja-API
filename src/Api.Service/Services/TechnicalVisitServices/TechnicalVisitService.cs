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

        public async Task<bool> Post(TechnicalVisitDto technicalVisit)
        {
            var visit = _mapper.Map<TechnicalVisit>(technicalVisit);
            var created = await _repository.InsertAsync(visit);

            return created;
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

                if (visit == null) throw new ArgumentException("Visita n�o encontrada.");
                if (visit.StatusId == InProgress) throw new ArgumentException("S� � poss�vel cancelar visitas pendentes.");
                if (visit.StatusId == Canceled) throw new ArgumentException("Visita j� cancelada.");

                return _repository.CancelVisit(visitId);
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