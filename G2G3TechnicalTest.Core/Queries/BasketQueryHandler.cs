using G2G3TechnicalTest.Core.Contracts;
using G2G3TechnicalTest.Core.Models;
using G2G3TechnicalTest.Core.Models.POCO;
using System;
using System.Collections.Generic;
using System.Net;
using static System.String;

namespace G2G3TechnicalTest.Core.Queries
{
    public class BasketQueryHandler : IBasketQueryHandler
    {

        private string _jsonData;
        private IJsonHandler _jsonHandler;

        public BasketQueryHandler(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }
        public virtual IEnumerable<BasketItem> GetUserBasket()
        {
            //In real app this would probably take a user object/id to query the datasource
            //Static Json file for now..

            return GetTransportDto().Basket;
        }

        public virtual Postage GetPostageOptions()
        {
            return GetTransportDto().Postage;
        }

        public virtual User GetUserDetails()
        {
            //In real app would get this from authenticated login..
            return GetTransportDto().User;
        }

        public TransportDto GetTransportDto()
        {
            var deserialisedDto = _jsonHandler.Deserialise(GetMockData());

            if (deserialisedDto == null)
                throw new ArgumentNullException(nameof(deserialisedDto));

            return deserialisedDto;
        }

        public string GetMockData()
        {
            if (!IsNullOrEmpty(_jsonData))
                return _jsonData;

            using (var wc = new WebClient())
            {
                _jsonData = wc.DownloadString("http://unattended-test.azurewebsites.net/basket.json");

                if (IsNullOrEmpty(_jsonData))
                    throw new ArgumentNullException(nameof(_jsonData));

                return _jsonData;
            }
        }
    }
}
