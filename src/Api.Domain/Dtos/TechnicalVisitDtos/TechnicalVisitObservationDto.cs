namespace Domain.Dtos.TechnicalVisitDtos
{
    public class TechnicalVisitObservationDto
    {
        public Guid VisitId { get; set; }
        public string? Observation { get; set; }
    }
}