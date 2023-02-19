using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class ResidencialProperty : BaseEntity
    {
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public int Rgi { get; set; }
        public int Hidrometer { get; set; }
        public int PersonId { get; set; }
    }
}