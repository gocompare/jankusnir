using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Internal.Interfaces
{
    internal interface IOfferApplicator
    {
        decimal ApplyOffers(Dictionary<string, int> shoppingCart, Dictionary<string, Product> productCatalog, List<IOffer> offers);
    }
}
