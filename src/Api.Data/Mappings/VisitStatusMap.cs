using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class VisitStatusMap : IEntityTypeConfiguration<VisitStatus>
    {
        public void Configure(EntityTypeBuilder<VisitStatus> builder)
        {
            builder.ToTable("Visit_Status");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
