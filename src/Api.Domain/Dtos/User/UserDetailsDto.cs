namespace Domain.Dtos.User
{
    public class UserDetailsDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Rg { get; set; }
        public int Cpf { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
