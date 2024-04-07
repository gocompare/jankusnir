using CheckoutBL.Models;
using CheckoutBL.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.DataRepository
{
    public class DummyDataRepository : IDataRepository
    {
        public IEnumerable<IOffer> GetOffers()
        {
            var offers = new List<IOffer>
            {
                new MultiBuyOffer(new Product {SKU = "A", Price = 50}, 3, 130),
                new MultiBuyOffer(new Product {SKU = "B", Price = 30}, 2, 45)
            };
            throw new NotImplementedException();
        }

        public IDictionary<string, Product> GetProducts()
        {
            return new Dictionary<string, Product>
            {
                {"A", new Product {SKU = "A", Price = 50}},
                {"B", new Product {SKU = "B", Price = 30}},
                {"C", new Product {SKU = "C", Price = 20}},
                {"D", new Product {SKU = "D", Price = 15}},
            };
        }
    }
}
