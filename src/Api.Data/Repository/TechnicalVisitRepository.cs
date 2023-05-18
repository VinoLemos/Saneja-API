using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TechnicalVisitRepository : IBaseRepository<TechnicalVisit>
    {
        private readonly MyContext _context;
        private const int Pending = 1;
        private const int InProgress = 2;
        private const int Finished = 3;
        private const int Canceled = 1;

        public TechnicalVisitRepository(MyContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(TechnicalVisit item)
        {
            try
            {
                item.StatusId = 1;
                await _context.TechnicalVisits.AddAsync(item);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
;
        }

        public async Task<TechnicalVisit> SelectAsync(Guid id)
        {
            var visit = await _context.TechnicalVisits.FirstOrDefaultAsync(t => t.Id == id);

            return visit ?? throw new ArgumentException("Visita não encontrada.");
        }

        public Task<IEnumerable<TechnicalVisit>> SelectAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<List<TechnicalVisit>> SelectAgentVisits(Guid agentId)
        {
            var visits = await _context.TechnicalVisits.Where(t => t.UserId == agentId).ToListAsync();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas para o agente informado.");
        }
        public async Task<TechnicalVisit> SelectAgentActiveVisit(Guid agentId)
        {
            var visit = await _context.TechnicalVisits.FirstOrDefaultAsync(t => t.UserId == agentId && t.StatusId == InProgress);

            return visit ?? throw new ArgumentException("Não foi encontrada uma visita ativa para o agente informado.");
        }

        public async Task<IEnumerable<TechnicalVisit>> SelectPendingVisits()
        {
            var visits = await _context.TechnicalVisits.Where(t => t.StatusId == Pending).ToListAsync();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas pendentes.");
        }

        public async Task<IEnumerable<TechnicalVisit>> SelectFinishedVisits()
        {
            var visits = await _context.TechnicalVisits.Where(t => t.StatusId == Finished ).ToListAsync();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas completas.");
        }

        public async Task<IEnumerable<TechnicalVisit>> SelectCanceledVisits()
        {
            var visits = await _context.TechnicalVisits.Where(t => t.StatusId == Canceled).ToListAsync();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas canceladas.");
        }

        public void UpdateAsync(TechnicalVisit item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVisitObservation(Guid visitId, string? observation)
        {
            try
            {
                var visit = _context.TechnicalVisits.FirstOrDefault(v => v.Id == visitId) ?? throw new ArgumentException("Visita não encontrada");

                if (visit.StatusId != InProgress) throw new ArgumentException("A visita precisa estar ativa para adicionar uma observação");

                visit.Observation = observation;
                visit.Homologated = true;
                visit.HomologationDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CancelVisit(Guid visitId)
        {
            try
            {
                var visit = (_context?.TechnicalVisits.FirstOrDefault(v => v.Id == visitId)) ?? throw new ArgumentException("Visita não encontrada.");

                visit.StatusId = Canceled; // Cancelada

                return true;

    }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
