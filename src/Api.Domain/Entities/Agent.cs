using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Agent : BaseUser
    {
        public List<TechnicalVisit> Visits { get; set; }
    }
}