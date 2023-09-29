using Microsoft.EntityFrameworkCore;
using hikitocAPI.Models.Domain;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace hikitocAPI.Data
{
    public class HikitocDbContext : DbContext
    {
        public HikitocDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<Water> Waters { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Planet>().ToTable("NewPlanets");
        //    modelBuilder.Entity<SolarSystem>().ToTable("NewSolarSystems");
        //    modelBuilder.Entity<Water>().ToTable("NewWaters");
        //}
    }
}
