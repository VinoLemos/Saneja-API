using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public abstract class BaseUser : BaseEntity
    {
        public string Name { get; set; }
        public string Rg { get; set; }
        public long Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}