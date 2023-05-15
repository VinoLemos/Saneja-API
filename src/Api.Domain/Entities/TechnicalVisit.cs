using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class TechnicalVisit : BaseEntity
    {
        [ForeignKey("ResidencialProperty")]
        public Guid ResidencialPropertyId { get; set; }
        public virtual ResidentialProperty ResidencialProperty { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public virtual User Agent { get; set; }
        public VisitStatus Status { get; set; }
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

    public enum VisitStatus
    {
        Pending,
        InProgress,
        Finished
    }
}