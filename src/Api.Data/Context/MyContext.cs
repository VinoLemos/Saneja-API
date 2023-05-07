using Api.Data.Mappings;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Context
{
    public class MyContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ResidentialProperty> ResidencialProperties { get; set; }
        public DbSet<TechnicalVisit> TechnicalVisits { get; set; }

        public MyContext()
        {

        }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=saneja_api_dev;Uid=root;Pwd=1234";
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            if (!optionsBuilder.IsConfigured) 
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply the IdentityUser configuration
            modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());
            modelBuilder.Entity<Person>(new PersonMap().Configure);
            modelBuilder.Entity<Agent>(new AgentMap().Configure);
            modelBuilder.Entity<ResidentialProperty>(new ResidentialPropertyMap().Configure);
            modelBuilder.Entity<TechnicalVisit>(new TechnicalVisitMap().Configure);
        }

        public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
        {
            public void Configure(EntityTypeBuilder<IdentityUser> builder)
            {
                // Configure the key property for IdentityUser entity
                builder.HasKey(u => u.Id);
            }
        }
    }
}