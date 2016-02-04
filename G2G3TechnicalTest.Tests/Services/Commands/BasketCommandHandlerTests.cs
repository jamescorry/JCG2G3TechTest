using G2G3TechnicalTest.Core.Commands;
using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;
using Xunit;

namespace G2G3TechnicalTest.Tests.Services.Commands
{

    public class BasketCommandHandlerTests
    {

        [Theory]
        [InlineData(3.20, 1.80, 8.99, 13.99)]
        [InlineData(1.22, 13, 2.34, 16.56)]
        [InlineData(250, 0.22, 1.99, 252.21)]
        [InlineData(12, 1.45, 18.23, 31.68)]
        [InlineData(2.33, 8.45, 2.32, 13.10)]
        public void SumMethodReturnsCorrectTotalValue(decimal basketAmount, decimal basketAmount2, decimal basketAmount3, decimal expectedTotal)
        {
            //Arrange
            var basketCommandHandler = new BasketCommandHandler();
            var basketList = new List<BasketItem>
            {
                new BasketItem {Cost = basketAmount },
                new BasketItem {Cost = basketAmount2 },
                new BasketItem {Cost = basketAmount3 }
            };

            //Act

            var totalBasketValue = basketCommandHandler.SumBasketPrices(basketList);

            //Assert

            Assert.True(totalBasketValue == expectedTotal);
        }

        [Fact]
        public void ConvertCurrencyMethodThrowsKeyNotFoundExceptionIfCurrencyIsUnrecognised()
        {
            //Arrange
            var basketCommandHandler = new BasketCommandHandler();

            //Act
            try
            {
                basketCommandHandler.ConvertCurrencyStringToSymbol("load of rubbish");
            }
            catch (KeyNotFoundException e)
            {
                return;
            }

            Assert.True(false, "Exception not raised.");
        }

    }
}
