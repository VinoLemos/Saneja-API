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

            builder.HasIndex(p => p.Id)
                    .IsUnique();

            builder.Property(p => p.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.Property(p => p.Rg)
                    .IsRequired()
                    .HasMaxLength(9);
        }
    }
}