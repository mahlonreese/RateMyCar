using Microsoft.EntityFrameworkCore;
using RateMyCar.Models;
using System.Collections.Generic;

namespace RateMyCar.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, Make = " ", Model = " ", Category = " ", Year=2024 },
                new Car { CarId = 2, Make = " ", Model = " ", Category = " ", Year = 2024 },
                new Car { CarId = 3, Make = " ", Model = " ", Category = " ", Year = 2024 },
                new Car { CarId = 4, Make = " ", Model = " ", Category = " ", Year = 2024 },
                new Car { CarId = 5, Make = " ", Model = " ", Category = " ", Year = 2024 },
                new Car { CarId = 6, Make = " ", Model = " ", Category = " ", Year = 2024 },
                new Car { CarId = 7, Make = " ", Model = " ", Category = " ", Year = 2024 }

            );
        }
    }
}
