using CarRentalSystem.Domain.Interfaces.Services;

namespace CarRentalSystem.Domain.Core.Services
{
    public class SuvPriceStrategy : IPriceStrategy
    {
        double PRICE_PER_DAY = 150;

        public double calculateExtraDays(int extraDays)
        {
            return (PRICE_PER_DAY * extraDays) + (50 * 0.6 * extraDays);
        }

        public double calculatePrice(int days)
        {
            double total = Math.Min(days, 7) * PRICE_PER_DAY;

            if (days > 7 && days <= 30)
            {
                total += (days - 7) * 0.8 * PRICE_PER_DAY;
            }

            if (days > 30)
            {
                total += (days - 30) * 0.5 * PRICE_PER_DAY;
            }

            return total;

        }
    }
}