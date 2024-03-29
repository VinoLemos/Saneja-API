﻿using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TechnicalVisitRepository : IBaseRepository<TechnicalVisit>
    {
        private readonly MyContext _context;

        public TechnicalVisitRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<TechnicalVisit> InsertAsync(TechnicalVisit item, Guid propertyId)
        {
            try
            {
                var pendingStatus = await _context.VisitStatuses.FirstOrDefaultAsync(vt => vt.Status == "Pending");
                var property = await _context.ResidencialProperties.FirstOrDefaultAsync(p => p.Id == propertyId);

                item.StatusId = pendingStatus.Id;
                item.ResidencialPropertyId = property.Id;
                var created = await _context.TechnicalVisits.AddAsync(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TechnicalVisit> InsertAsync(TechnicalVisit item)
        {
            throw new NotImplementedException();
            ;
        }

        public async Task<VisitStatus?> SelectStatusById(Guid statusId)
        {
            return await _context.VisitStatuses.FirstOrDefaultAsync(v => v.Id == statusId);
        }

        public User SelectUserByPropertyId(Guid id)
        {
            var user = (from property in _context.ResidencialProperties
                        from u in _context.Users.Where(u => u.Id == property.PersonId)
                        where property.Id == id
                        select u).FirstOrDefault();

            return user ?? throw new ArgumentException("Proprietário não encontrado");
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

        public List<VisitStatus> SelectStatusList()
        {
            return _context.VisitStatuses.ToList();
        }

        public List<TechnicalVisit> SelectAgentVisits(Guid agentId)
        {
            var visits = _context.TechnicalVisits.Where(t => t.UserId == agentId).ToList();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas para o agente informado.");
        }

        public List<TechnicalVisit> SelectPersonVisits(Guid personId)
        {
            var visits = (from v in _context.TechnicalVisits
                          join properties in _context.ResidencialProperties on v.ResidencialPropertyId equals properties.Id
                          join user in _context.Users on properties.PersonId equals user.Id
                          where user.Id == personId
                          select v).ToList();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas para o agente informado.");
        }

        public async Task<TechnicalVisit> SelectAgentActiveVisit(Guid agentId)
        {
            var visit = await (from v in _context.TechnicalVisits
                               from vt in _context.VisitStatuses.Where(vt => vt.Id == v.StatusId)
                               where vt.Status == "In Progress"
                               && v.UserId == agentId
                               select v).FirstOrDefaultAsync();

            return visit ?? throw new ArgumentException("Não foi encontrada uma visita ativa para o agente informado.");
        }

        public IEnumerable<TechnicalVisit> SelectPendingVisits()
        {
            var visits = (from v in _context.TechnicalVisits
                          from vt in _context.VisitStatuses.Where(vt => vt.Id == v.StatusId)
                          where vt.Status == "Pending"
                          select v).ToList();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas pendentes.");
        }

        public IEnumerable<TechnicalVisit> SelectFinishedVisits()
        {
            var visits = (from v in _context.TechnicalVisits
                                from vt in _context.VisitStatuses.Where(vt => vt.Id == v.StatusId)
                                where vt.Status == "Finished"
                                select v).ToList();

            return visits ?? throw new ArgumentException("Não foram encontradas visitas completas.");
        }

        public IEnumerable<TechnicalVisit> SelectCanceledVisits()
        {
            var visits = (from v in _context.TechnicalVisits
                          from vt in _context.VisitStatuses.Where(vt => vt.Id == v.StatusId)
                          where vt.Status == "Canceled"
                          select v).ToList();

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

                var inProgressStatus = _context.VisitStatuses.FirstOrDefault(vt => vt.Status == "In Progress") ?? throw new ArgumentException("Status não encontrado");
                var finishedStatus = _context.VisitStatuses.FirstOrDefault(vs => vs.Status == "Finished");

                if (visit.StatusId != inProgressStatus.Id) throw new ArgumentException("A visita precisa estar ativa para adicionar uma observação");

                visit.Observation = observation;
                visit.Homologated = true;
                visit.HomologationDate = DateTime.Now;
                visit.StatusId = finishedStatus.Id;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateVisitReturnDate(Guid visitId, Guid agentId, DateTime returnDate)
        {
            var visit = _context.TechnicalVisits.FirstOrDefault(visit => visit.Id == visitId) ?? throw new ArgumentException("Visita não encontrada");

            if (visit.UserId != agentId) throw new ArgumentException("Um agente só pode cancelar uma visita atribuída a ele mesmo.");

            visit.ReturnDate = returnDate;

            _context.SaveChanges();

            return true;
        }

        public bool AcceptVisit(Guid visitId, Guid agentId)
        {
            try
            {
                var visit = _context.TechnicalVisits.FirstOrDefault(v => v.Id == visitId);

                if (visit == null) throw new ArgumentException("Visita inválida");

                var agent = (from u in _context.Users
                             join userRoles in _context.UserRoles on u.Id equals userRoles.UserId
                             join roles in _context.Roles on userRoles.RoleId equals roles.Id
                             where roles.Name == "Agent"
                             && u.Id == agentId
                             select u).FirstOrDefault();

                if (agent == null) throw new ArgumentException("Agente inválido");

                var inProgressStatus = _context.VisitStatuses.FirstOrDefault(vt => vt.Status == "In Progress") ?? throw new ArgumentException("Status não encontrado");

                visit.StatusId = inProgressStatus.Id;
                visit.UserId = agentId;
                visit.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> FinishVisit(Guid visitId)
        {
            var visit = await _context.TechnicalVisits.FirstOrDefaultAsync(v => v.Id == visitId);

            if (visit == null) throw new ArgumentException("Visita não encontrada.");

            var InProgressStatus = await _context.VisitStatuses.FirstOrDefaultAsync(vs => vs.Status == "In Progress");

            if (visit.StatusId != InProgressStatus.Id) throw new ArgumentException("Só é possível finalizar visitas em progresso.");

            var finishedStatus = await _context.VisitStatuses.FirstOrDefaultAsync(vs => vs.Status == "Finished");

            visit.StatusId = finishedStatus.Id;

            _context.Update(visit);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelVisit(Guid visitId)
        {
            try
            {
                var visit = (_context?.TechnicalVisits.FirstOrDefault(v => v.Id == visitId)) ?? throw new ArgumentException("Visita não encontrada.");

                var inProgress = await _context.VisitStatuses.FirstOrDefaultAsync(vt => vt.Status == "In Progress");
                var canceled = await _context.VisitStatuses.FirstOrDefaultAsync(vt => vt.Status == "Canceled");
                var finished = await _context.VisitStatuses.FirstOrDefaultAsync(vt => vt.Status == "Finished");

                if (visit.StatusId == inProgress.Id) throw new ArgumentException("Só é possível cancelar visitas pendentes.");
                if (visit.StatusId == canceled.Id) throw new ArgumentException("Visita já cancelada.");
                if (visit.StatusId == finished.Id) throw new ArgumentException("Visita já finalizada.");

                visit.StatusId = canceled.Id; // Cancelada

                await _context.SaveChangesAsync();

                return true;

            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
