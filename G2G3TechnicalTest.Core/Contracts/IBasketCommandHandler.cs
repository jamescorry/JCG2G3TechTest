using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;

namespace G2G3TechnicalTest.Core.Contracts
{
    public interface IBasketCommandHandler
    {
        decimal SumBasketPrices(IEnumerable<BasketItem> basket);
        string ConvertCurrencyStringToSymbol(string currency);
        void SaveBasket(IEnumerable<BasketItem> basket);

    }
}
