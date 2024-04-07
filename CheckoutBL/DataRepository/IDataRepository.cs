using CheckoutBL.Models;
using CheckoutBL.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.DataRepository
{
    public interface IDataRepository
    {
        public IEnumerable<IOffer> GetOffers();
        public IDictionary<string, Product> GetProducts();
    }
}
