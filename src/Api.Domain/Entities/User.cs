using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public long Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
    }
}