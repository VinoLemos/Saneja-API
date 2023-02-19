using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseUser
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value == null ? DateTime.Now : value; }
        }

        public DateTime? UpdatedAt { get; set; }
    }
}