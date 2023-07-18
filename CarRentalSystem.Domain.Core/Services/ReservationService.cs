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
    public class ReservationService : IReservationService
    {
        private readonly IPriceService _priceService;
        private readonly ICarRepository _carRepository;
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private ReservationRS reservationRS;

        public ReservationService(IPriceService priceService, ICarRepository carRepository, ILoyaltyProgramRepository loyaltyProgram) 
        { 
            _priceService = priceService;
            _carRepository = carRepository;
            _loyaltyProgramRepository = loyaltyProgram;
            reservationRS = new ReservationRS();
        }

        public ReservationRS ReservationCars(ReservationRQ reservationRQ)
        {
            reservationRS.Cars = new Dictionary<string, double>();
            List<LoyaltyProgram> loyaltyProgram = _loyaltyProgramRepository.GetAll().ToList();
            List<Car> AllCars = _carRepository.GetCars().ToList();

            foreach (Car car  in reservationRQ.Cars)
            {
                if (AllCars.Any(x => x.Id == car.Id && x.IsRent == true)) continue;

                double carPrice = _priceService.calculateRentalPrice(car, reservationRQ.Days);
                reservationRS.Cars.Add(car.Model, carPrice);
                reservationRS.Total += carPrice;
                reservationRS.LoyaltyPoints += loyaltyProgram.First(x => x.Category == car.Category).Points;
                ChangeIsRentValueToCars(car);
            }

            return reservationRS;
        }

        private void ChangeIsRentValueToCars(Car car)
        {
            car.IsRent = true;
            _carRepository.Update(car);
        }

       
    }
}
