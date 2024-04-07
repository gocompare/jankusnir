using CheckoutBL.Interfaces;
using CheckoutBL.Internal.DiscountCalculator;
using CheckoutBL.Internal.Offer;
using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Services
{
    internal class CheckoutService : ICheckoutService
    {
        private readonly Dictionary<string, Product> _productCatalog;
        private readonly List<IOffer> _offers;
        private readonly IDiscountCalculator _discountCalculator;

        public CheckoutService(Dictionary<string, Product> productCatalog, List<IOffer> offers, IDiscountCalculator discountCalculator)
        {
            _productCatalog = productCatalog;
            _offers = offers;
            _discountCalculator = discountCalculator;
        }

        public decimal CalculatePrice(string shoppingList)
        {
            var shoppingCart = new Dictionary<string, int>();
            decimal fullPrice = 0;

            foreach (char c in shoppingList)
            {
                if (!_productCatalog.ContainsKey(c.ToString()))
                {
                    continue;
                }

                fullPrice += _productCatalog[c.ToString()].Price;

                if (shoppingCart.ContainsKey(c.ToString()))
                {
                    shoppingCart[c.ToString()]++;
                } else
                {
                    shoppingCart[c.ToString()] = 1;
                }
            }

            decimal discount = _discountCalculator.CalculateDiscount(shoppingCart, _productCatalog, _offers);

            return fullPrice - discount;
        }
    }
}
