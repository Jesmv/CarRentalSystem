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

            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Pepito Palotes",
                    LoyaltyCard = "N0000001",
                    TotalLoyaltyPoints = 0,
                },
                new Customer
                {
                    Id = 2,
                    Name = "Manolita Palomitas",
                    LoyaltyCard = "N0000002",
                    TotalLoyaltyPoints = 0,
                },
                new Customer
                {
                    Id = 3,
                    Name = "Bilbo Bolson",
                    LoyaltyCard = "N0000003",
                    TotalLoyaltyPoints = 0,
                },
            };

            modelBuilder.Entity<Car>().HasData(cars);
            modelBuilder.Entity<Customer>().HasData(customers);
        }

    }
}