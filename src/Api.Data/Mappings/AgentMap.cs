using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class AgentMap : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.ToTable("Agent");

            builder.HasKey(a => a.Id);

            builder.HasIndex(a => a.Cpf)
                    .IsUnique();

            builder.Property(a => a.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.Property(a => a.Rg)
                    .IsRequired()
                    .HasMaxLength(9);

            builder.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(60);

            builder.Property(a => a.Email)
                    .IsRequired()
                    .HasMaxLength(60);
        }
    }
}