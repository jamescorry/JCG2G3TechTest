using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;

namespace G2G3TechnicalTest.Core.Models
{
    public class TransportDto
    {
        public User User { get; set; }
        public IEnumerable<BasketItem> Basket { get; set; }
        public Postage Postage { get; set; }

    }
}
