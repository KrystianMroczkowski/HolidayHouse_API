using HolidayHouse_HouseAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HolidayHouse_HouseAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseNumber> HouseNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>().HasData(
               new House
               {
                   Id = 1,
                   Name = "Royal House",
                   Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                   ImageUrl = "https://placehold.co/600x400",
                   Occupancy = 4,
                   Rate = 200,
                   Sqft = 550,
                   Amenity = "",
                   CreatedDate = new DateTime(2000, 01, 01),
               },
              new House
              {
                  Id = 2,
                  Name = "Premium Pool House",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://placehold.co/600x401",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = new DateTime(2000, 01, 01),
              },
              new House
              {
                  Id = 3,
                  Name = "Luxury Pool House",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://placehold.co/600x402",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = new DateTime(2000, 01, 01),
              },
              new House
              {
                  Id = 4,
                  Name = "Diamond House",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://placehold.co/600x403",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = new DateTime(2000, 01, 01),
              },
              new House
              {
                  Id = 5,
                  Name = "Diamond Pool House",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://placehold.co/600x404",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = new DateTime(2000, 01, 01),
              });
        }
    }
}
