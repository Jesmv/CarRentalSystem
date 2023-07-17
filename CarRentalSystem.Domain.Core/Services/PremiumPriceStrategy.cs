using CarRentalSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public class PremiumPriceStrategy : IPriceStrategy
    {
        private float PRICE_PER_DAY = 300;

        public double calculatePrice(int days)
        {
            return PRICE_PER_DAY * days;
        }

        public double calculateExtraDays(int extraDays)
        {
            return this.calculatePrice(extraDays) +  0.2* PRICE_PER_DAY * extraDays;
        }
    }
}
