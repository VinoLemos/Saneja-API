using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class TechnicalVisit : BaseEntity
    {
        public int ResidencialPropertyId { get; set; }
        public ResidencialProperty ResidencialProperty { get; set; }
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
        public VisitStatus Status { get; set; }
        private DateTime _requestDate;
        public DateTime RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value == null ? DateTime.Now : value; }
        }
        private DateTime _visitDate;
        public DateTime VisitDate
        {
            get { return _visitDate; }
            set { _visitDate = value == null ? DateTime.Now : value; }
        }
        public DateTime? ReturnDate { get; set; }
        public bool Homologated { get; set; }
        public DateTime? HomologationDate { get; set; }
        public string? Observation { get; set; }
    }
}