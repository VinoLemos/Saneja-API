using Api.Domain.Entities;

namespace Domain.Entities
{
    public class Notification : BaseEntity
    {
        public new int Id { get; set; }
        public bool IsRead { get; set; }
        public string? Message { get; set; }
        public int UserId { get; set; }
        public int TechnicalVisitId { get; set; }
    }
}
