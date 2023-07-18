using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly ICarRepository _carRepository;

        public InventoryService(ICarRepository carRepository) 
        { 
            _carRepository = carRepository;
        }
        public List<Car> AvailableCars()
        {
            return _carRepository.GetCars().Where(x => x.IsRent == false).ToList();
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetCars();
        }
    }
}
