using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;
using System.Data.Entity;

namespace G2G3TechnicalTest.Core.Context
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext() :
            base("BasketDatabase")
        { }
        public DbSet<IEnumerable<BasketItem>> Basket { get; set; }
    }
}
