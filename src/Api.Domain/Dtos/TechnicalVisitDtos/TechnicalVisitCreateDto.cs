namespace Domain.Dtos.TechnicalVisitDtos
{
    public class TechnicalVisitCreateDto
    {
        public Guid ResidentialPropertyId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
