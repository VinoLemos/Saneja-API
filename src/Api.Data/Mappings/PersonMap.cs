using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Cpf)
                    .IsUnique();

            builder.Property(p => p.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.Property(p => p.Rg)
                    .IsRequired()
                    .HasMaxLength(9);

            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(60);

            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(60);
        }
    }
}