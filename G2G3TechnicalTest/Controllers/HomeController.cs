using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models.POCO;
using G2G3TechnicalTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace G2G3TechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBasketQueryHandler _queryHandler;
        private readonly IBasketCommandHandler _commandHandler;

        public HomeController(IBasketQueryHandler queryHandler, IBasketCommandHandler commandHandler)
        {
            _queryHandler = queryHandler;
            _commandHandler = commandHandler;
        }

        public ActionResult Index()
        {
            var basketModel = _queryHandler.GetUserBasket();
            var postageModel = _queryHandler.GetPostageOptions();

            //In real world scenario user would be authenticated at this point and details would come from
            //login provider (e.g ASP.NET Identity)
            var userDetailsModel = _queryHandler.GetUserDetails();

            return View(new CompositionModel
            {
                BasketViewModel = basketModel,
                Postage = new List<Postage> { postageModel },
                UserViewModel = userDetailsModel,
                BasketValue = _commandHandler.SumBasketPrices(basketModel),
                CurrencySymbol = _commandHandler.ConvertCurrencyStringToSymbol(userDetailsModel.Currency)
            });
        }

        [HttpPost]
        public ActionResult SaveBasket(CompositionModel model)
        {

            //Example of EF saving, not wired up to the front yet..
            _commandHandler.SaveBasket(model.BasketViewModel);

            model.BasketSavedSuccessfully = true;
            return View("Index", model);
        }

    }
}