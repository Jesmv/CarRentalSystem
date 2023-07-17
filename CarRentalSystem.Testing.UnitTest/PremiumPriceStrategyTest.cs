using CarRentalSystem.Domain.Core.Services;
using CarRentalSystem.Domain.Entities;
using DomainServices;
using System.Collections.Generic;

namespace CarRentalSystem.Testing.UnitTest
{
    public class PremiumPriceStrategyTest
    {
       

        [Theory(DisplayName = "Check prices for premium category")]
        [InlineData(10, 3000)]
        [InlineData(5, 1500)]
        [InlineData(0, 0)]
        public void calculateRentalPriceTest(int days, double expectedPrice)
        {
            PremiumPriceStrategy strategy = new PremiumPriceStrategy();
            double result = strategy.calculatePrice(days);

            Assert.Equal(expectedPrice, result);
        }

        [Theory(DisplayName = "Check extra days prices for premium category")]
        [InlineData(2, 720)]
        [InlineData(0, 0)]
        public void calculateExtraDaysTest(int days, double expectedPrice)
        {
            PremiumPriceStrategy strategy = new PremiumPriceStrategy();
            double result = strategy.calculateExtraDays(days);

            Assert.Equal(expectedPrice, result);
        }
    }
}