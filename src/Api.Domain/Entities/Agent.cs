using Domain.Enums.User;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    public class Agent : BaseUser
    {
        [JsonIgnore]
        public virtual List<TechnicalVisit>? Visits { get; set; }
        public UserType UserType { get; } = UserType.Agent;
    }
}