using G2G3TechnicalTest.Controllers;
using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models.POCO;
using G2G3TechnicalTest.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Xunit;

namespace G2G3TechnicalTest.Tests.Controllers
{
    public class HomeControllerTest
    {
        private readonly Mock<IBasketQueryHandler> _mockQueryHandler;
        private readonly Mock<IBasketCommandHandler> _mockCommandHandler;

        public HomeControllerTest()
        {
            _mockQueryHandler = new Mock<IBasketQueryHandler>();
            _mockQueryHandler.Setup(x => x.GetUserDetails()).Returns(new User() { Currency = "GBP" });

            _mockCommandHandler = new Mock<IBasketCommandHandler>();
        }


        [Fact]
        public void HomeControllerReturnsNonNullViewResultWhenIndexMethodIsCalled()
        {
            //Arrange
            var controller = new HomeController(_mockQueryHandler.Object, _mockCommandHandler.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void HomeControllerReturnsCorrectViewModelWhenIndexIsCalled()
        {
            //Arrange
            var controller = new HomeController(_mockQueryHandler.Object, _mockCommandHandler.Object);

            // Act
            var result = controller.Index() as ViewResult;
            var expectedModel = result.Model as CompositionModel;

            // Assert
            Assert.NotNull(expectedModel);
        }

        [Fact]
        public void HomeControllerReturnsCorrectUserViewModelDataWhenSeededWithTestData()
        {
            //Arrange
            var firstName = "James";
            var lastName = "James";
            var currency = "GBP";
            var email = "jamescorry@email.com";

            var controller = new HomeController(_mockQueryHandler.Object, _mockCommandHandler.Object);
            _mockQueryHandler.Setup(x => x.GetUserDetails()).Returns(new User
            {
                FirstName = firstName,
                LastName = lastName,
                Currency = currency,
                Email = email
            });

            // Act
            var result = controller.Index() as ViewResult;
            var expectedModel = result.Model as CompositionModel;

            // Assert
            Assert.True(expectedModel.UserViewModel.FirstName == firstName &&
                        expectedModel.UserViewModel.LastName == lastName &&
                        expectedModel.UserViewModel.Currency == currency &&
                        expectedModel.UserViewModel.Email == email);
        }

        [Fact]
        public void HomeControllerReturnsCorrectBasketViewModelDataWhenSeededWithTestData()
        {
            //Arrange
            var productName = "test product";
            var productDescription = "test description";
            var cost = 5.44m;
            var category = "test category";
            var imageUrl = "http://test.image.com/image.jpg";

            var controller = new HomeController(_mockQueryHandler.Object, _mockCommandHandler.Object);
            _mockQueryHandler.Setup(x => x.GetUserBasket()).Returns(new List<BasketItem>
            {
                new BasketItem
                {
                    ProductName = productName,
                    Description = productDescription,
                    Category = category,
                    Cost = cost,
                    Image = imageUrl
                }
            });

            // Act
            var result = controller.Index() as ViewResult;
            var expectedModel = result.Model as CompositionModel;
            var basket = expectedModel.BasketViewModel.FirstOrDefault();

            // Assert
            Assert.NotNull(basket);
            Assert.True(basket.ProductName == productName &&
                        basket.Description == productDescription &&
                        basket.Category == category &&
                        basket.Cost == cost &&
                        basket.Image == imageUrl);
        }

    }
}
