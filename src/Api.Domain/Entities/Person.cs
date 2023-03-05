using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Person : BaseUser
    {
        [JsonIgnore]
        public virtual List<ResidentialProperty>? ResidentialProperties { get; set; }
    }
}