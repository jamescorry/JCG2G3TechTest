using G2G3TechnicalTest.Core.Context;
using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;
using System.Linq;

namespace G2G3TechnicalTest.Core.Commands
{
    public class BasketCommandHandler : IBasketCommandHandler
    {
        public BasketCommandHandler()
        {

        }


        public decimal SumBasketPrices(IEnumerable<BasketItem> basket)
        {
            return basket.Sum(x => x.Cost);
        }

        public string ConvertCurrencyStringToSymbol(string currency)
        {
            switch (currency)
            {
                case "GBP":
                    return "&pound;";
            }

            //Crashing for now, could handle with a default or raise an error page? 
            throw new KeyNotFoundException();
        }

        public void SaveBasket(IEnumerable<BasketItem> basket)
        {
            //Sample data model requires ID to be meaningful. Simply showing data persistance
            using (var context = new ExampleDbContext())
            {
                context.Basket.Add(basket);
                context.SaveChanges();
            }
        }

    }
}
