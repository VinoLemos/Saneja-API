using Domain.Dtos.ResidentialPropertyDtos;

namespace Domain.Dtos.TechnicalVisitDtos
{
    public class TechnicalVisitDetailsDto
    {
        public Guid VisitId { get; set; }
        public Guid? AgentId { get; set; }
        public Guid VisitStatusId { get; set; }
        public string VisitStatus { get; set; }
        public DateTime? VisitRequestDate { get; set; }
        public bool Homologated { get; set; }
        public DateTime? HomologationDate { get; set; }
        public string? Observation { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string PropertyOwner { get; set; }
        public string AgentName { get; set; }
        public ResidentialPropertyDto Property { get; set; }

    }
}
