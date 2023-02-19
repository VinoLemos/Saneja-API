using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Mappings;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<ResidencialProperty> ResidencialProperties { get; set; }
        public DbSet<TechnicalVisit> TechnicalVisits { get; set; }

        public MyContext()
        {
            
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<Person>(new PersonMap().Configure);
            modelBuilder.Entity<Agent>(new AgentMap().Configure);
            modelBuilder.Entity<ResidencialProperty>(new ResidencialPropertyMap().Configure);
            modelBuilder.Entity<TechnicalVisit>(new TechnicalVisitMap().Configure);
        }
    }
}