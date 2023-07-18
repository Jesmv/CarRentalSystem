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
    public class ReturnCarService : IReturnCarService
    {
        private readonly IPriceService _priceService;
        private readonly ICarRepository _carRepository;
        private ReturnCarRS returnCarRS;

        public ReturnCarService(IPriceService priceService, ICarRepository carRepository) 
        { 
            _priceService = priceService;
            _carRepository = carRepository;
            returnCarRS = new ReturnCarRS();
        }

        public ReturnCarRS ReturnCarExtraDay(ReturnCarRQ returnCarRQ)
        {
            List<Car> AllCars = _carRepository.GetCars().ToList();
            returnCarRS.Cars = new Dictionary<string, double>();

            foreach (Car car in returnCarRQ.Cars)
            {
                if (AllCars.Any(x => x.Id == car.Id && x.IsRent == true)) continue;

                double carPrice = _priceService.calculateExtraDayPrice(car, returnCarRQ.ExtraDays);
                returnCarRS.Cars.Add(car.Model, carPrice);
                returnCarRS.Total += carPrice;
                ChangeIsRentValueToCars(car);
            }
            return returnCarRS;
        }

        private void ChangeIsRentValueToCars(Car car)
        {
            car.IsRent = false;
            _carRepository.Update(car);
        }
    }
}
