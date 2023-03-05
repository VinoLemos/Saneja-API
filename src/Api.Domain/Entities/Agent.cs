using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Agent : BaseUser
    {
        [JsonIgnore]
        public virtual List<TechnicalVisit>? Visits { get; set; }
    }
}