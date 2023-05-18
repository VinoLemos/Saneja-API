using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings
{
    public class ResidentialPropertyMap : IEntityTypeConfiguration<ResidentialProperty>
    {
        public void Configure(EntityTypeBuilder<ResidentialProperty> builder)
        {
            builder.ToTable("Residential_Property");

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

            builder.Property(p => p.UF)
                    .HasMaxLength(2);

            builder.Property(p => p.PersonId)
                    .IsRequired();
        }
    }
}