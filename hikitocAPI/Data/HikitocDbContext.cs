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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var waters = new List<Water>()
            {
                new Water() { Id = Guid.Parse("89F3868E-F904-4976-BEBE-1F6494EA2540"), Type = "Liquid", Image = "https://en.wikipedia.org/wiki/File:Johny_Cay.jpg"},
                new Water() { Id = Guid.Parse("A1E7B1AE-164E-486E-9EC2-C208DA0550E5"), Type = "Ice", Image = "https://en.wikipedia.org/wiki/Ice#/media/File:Ice_Block,_Canal_Park,_Duluth_(32752478892).jpg"},
                new Water() { Id = Guid.Parse("8C7BC12B-34CF-4D09-8F36-4F34D30E15FF"), Type = "Unknown", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Defense.gov_News_Photo_020221-D-9880W-080.jpg/440px-Defense.gov_News_Photo_020221-D-9880W-080.jpg"},
            };

            modelBuilder.Entity<Water>().HasData(waters);

            var solarSystems = new List<SolarSystem>()
            {
                new SolarSystem() { Id = Guid.Parse("B1F4B631-0680-4D93-B2ED-DEEB858CB930"), Code = "SLRSYS", Name = "Solar System", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/Solar_System_true_color_%28captions%29.jpg/1200px-Solar_System_true_color_%28captions%29.jpg"},
                new SolarSystem() { Id = Guid.Parse("FB336509-20FF-458B-8AA2-978090063FC0"), Code = "TRPST1", Name = "TRAPPIST-1", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f7/PIA21424_-_The_TRAPPIST-1_Habitable_Zone.jpg/880px-PIA21424_-_The_TRAPPIST-1_Habitable_Zone.jpg"},
            };

            modelBuilder.Entity<SolarSystem>().HasData(solarSystems);
        }



    }
}