using Domain.Enums.User;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class Person : BaseUser
    {
        [JsonIgnore]
        public virtual List<ResidentialProperty>? ResidentialProperties { get; set; }
        public UserType UserType { get; } = UserType.Person;
    }
}