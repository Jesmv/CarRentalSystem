using CarRentalSystem.Domain.Interfaces.Services;

namespace CarRentalSystem.Domain.Core.Services
{
    public class SmallPriceStrategy : IPriceStrategy
    {
        double PRICE_PER_DAY = 50;

        public double calculateExtraDays(int extraDays)
        {
            return (extraDays * PRICE_PER_DAY) + (PRICE_PER_DAY * 0.3 * extraDays);
        }

        public double calculatePrice(int days)
        {

            double weekPrice = 7 * PRICE_PER_DAY;

            double price = days <= 7 ? days * PRICE_PER_DAY : 
                weekPrice + (days - 7) * 0.6 * PRICE_PER_DAY;

            return price;
        }
    }
}