using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mappings
{
    public class TechnicalVisitMap : IEntityTypeConfiguration<TechnicalVisit>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TechnicalVisit> builder)
        {
            builder.ToTable("Technical_Visit");

            builder.HasKey(v => v.Id);
            builder.Property(v => v.Observation)
                   .HasMaxLength(150);
        }
    }
}