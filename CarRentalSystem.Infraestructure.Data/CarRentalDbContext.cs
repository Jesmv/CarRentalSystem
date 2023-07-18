using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infraestructure.Data
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
            // Make sure the database is created, else do it
            this.Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Car> cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Model = "BMV 7",
                    Category = "Premium",
                    IsRent = false
                },
                new Car
                {
                    Id = 2,
                    Model = "Kia Sorento",
                    Category = "Suv",
                    IsRent = false
                },
                new Car
                {
                    Id = 3,
                    Model = "Nissan Juke",
                    Category = "Suv",
                    IsRent = false
                },
                new Car
                {
                    Id = 4,
                    Model = "Seat Ibiza",
                    Category = "Small",
                    IsRent = false
                }
            };

            List<LoyaltyProgram> customers = new List<LoyaltyProgram>
            {
                new LoyaltyProgram
                {
                    Id = 1,
                    Category = "Premium",
                    Points = 5
                },
                new LoyaltyProgram
                {
                    Id = 2,
                    Category = "Suv",
                    Points = 3
                },
                new LoyaltyProgram
                {
                    Id = 3,
                    Category = "Small",
                    Points = 1
                },
            };

            modelBuilder.Entity<Car>().HasData(cars);
            modelBuilder.Entity<LoyaltyProgram>().HasData(customers);
        }

    }
}