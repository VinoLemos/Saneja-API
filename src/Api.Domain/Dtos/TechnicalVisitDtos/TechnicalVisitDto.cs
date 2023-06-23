namespace Domain.Dtos.TechnicalVisitDtos
{
    public class TechnicalVisitDto
    {
        public Guid Id { get; set; }
        public Guid ResidencialPropertyId { get; set; }
        public Guid? UserId { get; set; }
        public string PropertyOwner { get; set; }
        public Guid StatusId { get; set; }
        public string Status { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Homologated { get; set; }
        public DateTime? HomologationDate { get; set; }
        public string? Observation { get; set; }
    }
}
