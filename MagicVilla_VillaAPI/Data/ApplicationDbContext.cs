using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Villa> villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
                  new Villa
                  {
                      Id = 1,
                      Name = "Royal Villa",
                      Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                      Rate = 200,
                      Sqft = 550,
                      Occupancy = 4,
                      ImageUrl = "https://placehold.co/600x400/000000/FFFFFF?text=Royal+Villa",
                      Amenity = "",
                      CreateDate = new DateTime(2023, 10, 26),
                      UpdateDate = new DateTime(2023, 10, 26)
                  },
            new Villa
            {
                Id = 2,
                Name = "Premium Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Rate = 300,
                Sqft = 580,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x401/000000/FFFFFF?text=Premium+Pool+Villa",
                Amenity = "",
                CreateDate = new DateTime(2023, 10, 26),
                UpdateDate = new DateTime(2023, 10, 26)
            },
            new Villa
            {
                Id = 3,
                Name = "Luxury Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Rate = 400,
                Sqft = 750,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x402/000000/FFFFFF?text=Luxury+Pool+Villa",
                Amenity = "",
                CreateDate = new DateTime(2023, 10, 26),
                UpdateDate = new DateTime(2023, 10, 26)
            },
            new Villa
            {
                Id = 4,
                Name = "Diamond Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Rate = 550,
                Sqft = 900,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x403/000000/FFFFFF?text=Diamond+Pool+Villa",
                Amenity = "",
                CreateDate = new DateTime(2023, 10, 26),
                UpdateDate = new DateTime(2023, 10, 26)
            },
            new Villa
            {
                Id = 5,
                Name = "King Pool Villa",
                Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Rate = 600,
                Sqft = 1100,
                Occupancy = 4,
                ImageUrl = "https://placehold.co/600x404/000000/FFFFFF?text=King+Pool+Villa",
                Amenity = "",
                CreateDate = new DateTime(2023, 10, 26),
                UpdateDate = new DateTime(2023, 10, 26)
            });
        }
    }
}
