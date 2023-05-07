using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual List<ResidentialProperty>? ResidentialProperties { get; set; }
    }
}