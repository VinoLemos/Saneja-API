namespace Domain.Dtos.TechnicalVisitDtos
{
    public class TechnicalVisitCreateDto
    {
        public Guid Id { get; set; }
        public Guid ResidentialPropertyId { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
