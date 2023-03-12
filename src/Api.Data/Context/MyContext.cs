using Api.Data.Mappings;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : IdentityDbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Agent> Agents { get; set; }
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
            string? connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            if (!optionsBuilder.IsConfigured) 
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(new PersonMap().Configure);
            modelBuilder.Entity<Agent>(new AgentMap().Configure);
            modelBuilder.Entity<ResidentialProperty>(new ResidentialPropertyMap().Configure);
            modelBuilder.Entity<TechnicalVisit>(new TechnicalVisitMap().Configure);
        }
    }
}