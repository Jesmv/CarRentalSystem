using CarRentalSystem.Domain.Core.Services;
using CarRentalSystem.Domain.Entities;
using DomainServices;
using System.Collections.Generic;

namespace CarRentalSystem.Testing.UnitTest
{
    public class SuvPriceStrategyTest
    {
       

        [Theory(DisplayName = "Check prices for suv category")]
        [InlineData(9, 1290)]
        [InlineData(2, 300)]
        [InlineData(0, 0)]
        public void calculateRentalPriceTest(int days, double expectedPrice)
        {
            SuvPriceStrategy strategy = new SuvPriceStrategy();
            double result = strategy.calculatePrice(days);

            Assert.Equal(expectedPrice, result);
        }

        [Theory(DisplayName = "Check extra days prices for suv category")]
        [InlineData(1, 180)]
        [InlineData(0, 0)]
        public void calculateExtraDaysTest(int days, double expectedPrice)
        {
            SuvPriceStrategy strategy = new SuvPriceStrategy();
            double result = strategy.calculateExtraDays(days);

            Assert.Equal(expectedPrice, result);
        }
    }
}