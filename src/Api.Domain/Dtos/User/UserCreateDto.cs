namespace Domain.Dtos.User
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public int Cpf { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
    }
}
