using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models;
using G2G3TechnicalTest.Core.Queries;
using Moq;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace G2G3TechnicalTest.Tests.Services.Queries
{
    public class BasketQueryHandlerTests
    {
        private readonly BasketQueryHandler _basketQueryHandler;
        private Mock<IJsonHandler> _jsonHandler;

        public BasketQueryHandlerTests()
        {
            _jsonHandler = new Mock<IJsonHandler>();
            _jsonHandler.Setup(x => x.Deserialise(It.IsAny<string>())).Returns((TransportDto)null);

            _basketQueryHandler = new BasketQueryHandler(_jsonHandler.Object);
        }

        [Fact]

        public void HandlerThrowsArgumentNullExceptionWhenGetTransportDtoReturnsNull()
        {
            try
            {
                _basketQueryHandler.GetTransportDto();
            }
            catch (ArgumentNullException e)
            {
                return;
            }

            Assert.True(false, "Exception not raised.");
        }


    }
}
