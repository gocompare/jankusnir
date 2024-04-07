using CheckoutBL.Models;
using CheckoutBL.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.DiscountCalculator
{
    public class NaiveDiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(IDictionary<string, int> shoppingCart, IEnumerable<IOffer> offers)
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
