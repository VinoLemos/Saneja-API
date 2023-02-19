using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mappings
{
    public class ResidencialPropertyMap : IEntityTypeConfiguration<ResidencialProperty>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ResidencialProperty> builder)
        {
            builder.ToTable("Residencial_Property");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Rgi)
                    .IsUnique();
            
            builder.Property(p => p.Street)
                    .HasMaxLength(100);
            
            builder.Property(p => p.Complement)
                    .HasMaxLength(30);

            builder.Property(p => p.Cep)
                    .HasMaxLength(8);

            builder.Property(p => p.City)
                    .HasMaxLength(50);

            builder.Property(p => p.PersonId)
                    .IsRequired();
        }
    }
}