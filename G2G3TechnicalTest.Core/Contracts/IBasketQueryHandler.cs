using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;

namespace G2G3TechnicalTest.Core.Contracts
{
    public interface IBasketQueryHandler
    {
        IEnumerable<BasketItem> GetUserBasket();
        Postage GetPostageOptions();
        User GetUserDetails();
        string GetMockData();
    }
}
