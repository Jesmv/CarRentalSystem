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
            { "Premium", new SuvPriceStrategy() },
            { "Premium", new SmallPriceStrategy() }
        };

        public PriceService() { }

        public double calculateRentalPrice(List<Car> cars, int days)
        {

            double total = 0;

            foreach (var car in cars)
            {
                var calculator = getPriceCalculatorForCar(car);
                total += calculator.calculatePrice(days);
            }

            return total;
        }

        private IPriceStrategy getPriceCalculatorForCar(Car car)
        {
            return calculators[car.Category];
        }
    }
}
