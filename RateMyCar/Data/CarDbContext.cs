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
                new Car { CarId = 1, Make = "Toyota", Model = "Rav 4", Category = "SUV", Year = 2017 },
                new Car { CarId = 2, Make = "Toyota", Model = "Supra", Category = "Sedan", Year = 2024 },
                new Car { CarId = 3, Make = "Toyota", Model = "Tundra", Category = "Truck", Year = 2018 },
                new Car { CarId = 4, Make = "Toyota", Model = "4 Runner", Category = "SUV", Year = 2024 },
                new Car { CarId = 5, Make = "Toyota", Model = "Tacoma", Category = "Truck", Year = 2022 },
                new Car { CarId = 6, Make = "Ford", Model = "Focus", Category = "Sedan", Year = 2014 },
                new Car { CarId = 7, Make = "Honda", Model = "Accord", Category = "Sedan", Year = 2020 },
                new Car { CarId = 8, Make = "Lexus", Model = "LS", Category = "Sedan", Year = 2023 },
                new Car { CarId = 9, Make = "Lexus", Model = "ES", Category = "Sedan", Year = 2025 },
                new Car { CarId = 10, Make = "Lexus", Model = "LX", Category = "SUV", Year = 2024 },
                new Car { CarId = 11, Make = "BMW", Model = "E30", Category = "Sedan", Year = 1995 }

            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "mahlonreese", Email = "mahlon@gmail.com", Password = "Test123", Fullname = "Mahlon Reese"},
                new User { UserId = 2, Username = "melanieehrlich", Email = "melanie@gmail.com", Password = "Test321", Fullname = "Melanie Ehrlich" },
                new User { UserId = 3, Username = "thumrang", Email = "thum@gmail.com", Password = "Password123", Fullname = "Thum Rangsiyawaranon" }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, Rating = 5, Comments = "Amazing car, probably the best ever", PhotoUrl = "https://www.motortrend.com/uploads/sites/5/2016/12/2017-Toyota-RAV4-SE-front-three-quarter-in-motion-02-e1502926043520.jpg", DatePosted = new DateOnly(2023, 2, 20), UserId = 1, CarId = 1 },
                new Review { ReviewId = 2, Rating = 1, Comments = "Would not buy again, not 10/10", PhotoUrl = "https://s1.1zoom.me/b5154/579/Toyota_Supra_mk5_GR_A90_Gazoo_Racing_mkV_2.0L_584944_2560x1440.jpg", DatePosted = new DateOnly(2024, 4, 23), UserId = 2, CarId = 2 },
                new Review { ReviewId = 3, Rating = 4, Comments = "Got the job done, it is very reliable", PhotoUrl = "https://th.bing.com/th/id/R.6cd93fbb1d81f90a05c82098668438e5?rik=BSK8s2gRoss4uw&pid=ImgRaw&r=0", DatePosted = new DateOnly(2020, 11, 10), UserId = 3, CarId = 3 },
                new Review { ReviewId = 4, Rating = 2, Comments = "Stay away, it worked for 3 months", PhotoUrl = "https://th.bing.com/th/id/OIP.bw6h6Chq7Hz65Js0ZmHVEQHaEJ?rs=1&pid=ImgDetMain", DatePosted = new DateOnly(2024, 9, 28), UserId = 1, CarId = 4 },
                new Review { ReviewId = 5, Rating = 3, Comments = "Very reliable, just not that stylish", PhotoUrl = "https://cdn.motor1.com/images/mgl/zOXX4/s1/2021-toyota-tacoma-trd-off-road-driving-notes.jpg", DatePosted = new DateOnly(2024, 2, 27), UserId = 2, CarId = 5 }

            );
        }
    }
}
