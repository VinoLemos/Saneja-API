using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class ResidentialProperty : BaseEntity
    {
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public int Rgi { get; set; }
        public int Hidrometer { get; set; }
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}