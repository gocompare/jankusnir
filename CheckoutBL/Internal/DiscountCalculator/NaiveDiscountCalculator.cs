using CheckoutBL.Internal.Offer;
using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Internal.DiscountCalculator
{
    internal class NaiveDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(Dictionary<string, int> shoppingCart, List<IOffer> offers)
        {
            decimal discount = 0;
            foreach (var offer in offers)
            {
                discount += offer.CalculateOfferDiscount(shoppingCart);
            }

            return discount;
        }
    }
}
