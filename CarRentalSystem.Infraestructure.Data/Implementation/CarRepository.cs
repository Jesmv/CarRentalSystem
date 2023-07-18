using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Infraestructure.Data.Implementation
{
    public class CarRepository : ICarRepository
    {
        protected readonly CarRentalDbContext _context;
        public CarRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public void AddCar(Car car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }
        public void Update(Car car)
        {
            Car original = _context.Cars.Where(x => x.Id == car.Id).First();
            _context.Entry(original).CurrentValues.SetValues(car);
            _context.SaveChanges();
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);
        }

    }
}
