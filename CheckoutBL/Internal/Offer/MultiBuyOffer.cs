using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Internal.Offer
{
    internal class MultiBuyOffer : IOffer
    {
        private readonly Product product;
        private readonly int requiredCount;
        private readonly decimal newPrice;

        public MultiBuyOffer(Product product, int requiredCount, decimal newPrice)
        {
            this.product = product;
            this.requiredCount = requiredCount;
            this.newPrice = newPrice;
        }

        public decimal CalculateOfferDiscount(Dictionary<string, int> shoppingCart)
        {
            int itemsCount = shoppingCart[product.SKU];
            decimal fullPrice = itemsCount * product.Price;

            var offersApplied = itemsCount / requiredCount;
            decimal discountedPrice = offersApplied * newPrice + (itemsCount - offersApplied * requiredCount);

            return fullPrice = discountedPrice;
        }
    }
}
