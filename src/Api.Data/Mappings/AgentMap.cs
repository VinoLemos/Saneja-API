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

            builder.HasIndex(a => a.Id)
                    .IsUnique();

            builder.Property(a => a.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.Property(a => a.Rg)
                    .IsRequired()
                    .HasMaxLength(9);
        }
    }
}