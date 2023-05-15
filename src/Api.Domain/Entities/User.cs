using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "VARCHAR(80)")]
        public string? Name { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public override string Email { get; set; }
        [Column(TypeName = "VARCHAR(9)")]
        public string? Rg { get; set; }
        public int Cpf { get; set; }
        public DateTime? Birthday { get; set; }
    }
}