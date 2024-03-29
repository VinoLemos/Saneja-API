﻿namespace Domain.Dtos.ResidentialPropertyDtos
{
    public class ResidentialPropertyDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public int? Cep { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Rgi { get; set; }
        public int Hidrometer { get; set; }
    }
}
