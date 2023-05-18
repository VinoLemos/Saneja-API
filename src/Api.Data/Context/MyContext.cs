using Api.Data.Mappings;
using Api.Domain.Entities;
using Data.Mappings;
using Domain.Entities;
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
            modelBuilder.Entity<ResidentialProperty>(new ResidentialPropertyMap().Configure);
            modelBuilder.Entity<TechnicalVisit>(new TechnicalVisitMap().Configure);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<VisitStatus>(new VisitStatusMap().Configure);
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("User_Roles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("Role_Claims");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("User_Claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("User_Logins");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("User_Tokens");

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Agent", NormalizedName = "AGENT" },
                new IdentityRole<Guid> { Id = Guid.NewGuid(), Name = "Person", NormalizedName = "PERSON" }
                );

            modelBuilder.Entity<VisitStatus>().HasData(
                   new VisitStatus { Id = 1, Status = "Pending" },
                   new VisitStatus { Id = 2, Status = "In Progress" },
                   new VisitStatus { Id = 3, Status = "Finished" }
                );
        }

        public class IdentityUserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                // Configure the key property for User entity
                builder.HasKey(u => u.Id);
            }
        }
    }
}
