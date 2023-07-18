using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces.Services;
using DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Core.Services
{
    public class PriceService : IPriceService
    {

        Dictionary<string, IPriceStrategy> calculators = new Dictionary<string, IPriceStrategy>()
        {
            { "Premium", new PremiumPriceStrategy() },
            { "Suv", new SuvPriceStrategy() },
            { "Small", new SmallPriceStrategy() }
        };

        public PriceService() { }

        public double calculateRentalPrice(Car car, int days)
        {
            IPriceStrategy calculator = getPriceCalculatorForCar(car);
            return calculator.calculatePrice(days);
        }

        public double calculateExtraDayPrice(Car car, int extraDays)
        {
            IPriceStrategy calculator = getPriceCalculatorForCar(car);
            return calculator.calculateExtraDays(extraDays);
        }

        private IPriceStrategy getPriceCalculatorForCar(Car car)
        {
            return calculators[car.Category];
        }
    }
}
