using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class TechnicalVisit : BaseEntity
    {
        [ForeignKey("ResidencialProperty")]
        public Guid ResidencialPropertyId { get; set; }
        public virtual ResidentialProperty ResidencialProperty { get; set; }
        [ForeignKey("Agent")]
        public Guid AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        public VisitStatus Status { get; set; }
        private DateTime _requestDate;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value == null ? DateTime.Now : value; }
        }
        private DateTime _visitDate;
        public DateTime VisitDate
        {
            get { return _visitDate; }
            set { _visitDate = value == null ? DateTime.Now : value; }
        }
        public DateTime? ReturnDate { get; set; }
        public bool Homologated { get; set; }
        public DateTime? HomologationDate { get; set; }
        public string? Observation { get; set; }
    }
}