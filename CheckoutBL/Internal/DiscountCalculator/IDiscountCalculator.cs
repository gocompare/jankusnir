using CheckoutBL.Internal.Offer;
using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Internal.DiscountCalculator
{
    internal interface IDiscountCalculator
    {
        decimal CalculateDiscount(Dictionary<string, int> shoppingCart, Dictionary<string, Product> productCatalog, List<IOffer> offers);
    }
}
