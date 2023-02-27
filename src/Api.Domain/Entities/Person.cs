using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Person : BaseUser
    {
        public virtual List<ResidentialProperty> ResidencialProperties { get; set; }
    }
}