using CheckoutBL.DiscountCalculator;
using CheckoutBL.Models;
using CheckoutBL.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Services.CheckoutService
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IDictionary<string, Product> _productCatalog;
        private readonly IEnumerable<IOffer> _offers;
        private readonly IDiscountCalculator _discountCalculator;

        public CheckoutService(IDictionary<string, Product> productCatalog, IEnumerable<IOffer> offers, IDiscountCalculator discountCalculator)
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
                }
                else
                {
                    shoppingCart[c.ToString()] = 1;
                }
            }

            decimal discount = _discountCalculator.CalculateDiscount(shoppingCart, _offers);

            return fullPrice - discount;
        }
    }
}
