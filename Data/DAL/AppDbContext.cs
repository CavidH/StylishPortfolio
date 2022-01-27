using Core.Entities;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Project> projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectEntityConfiguration).Assembly);
            modelBuilder.Entity<Project>().HasData(
                    new Project { Id = 1, Name = "Stationary", Summary = "A yellow pencil with envelopes on a clean, blue backdrop!", Image = "portfolio-1.jpg" },
                    new Project { Id = 2, Name = "Stationary", Summary = "A yellow pencil with envelopes on a clean, blue backdrop!", Image = "portfolio-1.jpg" },
                    new Project { Id = 3, Name = "Stationary", Summary = "A yellow pencil with envelopes on a clean, blue backdrop!", Image = "portfolio-1.jpg" },
                    new Project { Id = 4, Name = "Stationary", Summary = "A yellow pencil with envelopes on a clean, blue backdrop!", Image = "portfolio-1.jpg" }
                );
            base.OnModelCreating(modelBuilder);

        }
    }
}
