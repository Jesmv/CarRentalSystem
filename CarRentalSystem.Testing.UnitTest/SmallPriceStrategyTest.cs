using CarRentalSystem.Domain.Core.Services;
using CarRentalSystem.Domain.Entities;
using DomainServices;
using System.Collections.Generic;

namespace CarRentalSystem.Testing.UnitTest
{
    public class SmallPriceStrategyTest
    {
       

        [Theory(DisplayName = "Check prices for small category")]
        [InlineData(10, 440)]
        [InlineData(2, 100)]
        [InlineData(0, 0)]
        public void calculateRentalPriceTest(int days, double expectedPrice)
        {
            SmallPriceStrategy strategy = new SmallPriceStrategy();
            double result = strategy.calculatePrice(days);

            Assert.Equal(expectedPrice, result);
        }

        [Theory(DisplayName = "Check extra days prices for small category")]
        [InlineData(2, 130)]
        [InlineData(0, 0)]
        public void calculateExtraDaysTest(int days, double expectedPrice)
        {
            SmallPriceStrategy strategy = new SmallPriceStrategy();
            double result = strategy.calculateExtraDays(days);

            Assert.Equal(expectedPrice, result);
        }
    }
}