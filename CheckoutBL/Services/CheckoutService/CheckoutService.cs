using CheckoutBL.DataRepository;
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
        private readonly IDataRepository _dataRepository;
        private readonly IDiscountCalculator _discountCalculator;

        public CheckoutService(IDiscountCalculator discountCalculator, IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _discountCalculator = discountCalculator;
        }

        public decimal CalculatePrice(string shoppingList)
        {
            var shoppingCart = new Dictionary<string, int>();
            var productCatalog = _dataRepository.GetProducts();
            var offers = _dataRepository.GetOffers();
            decimal fullPrice = 0;

            foreach (char c in shoppingList)
            {
                if (!productCatalog.ContainsKey(c.ToString()))
                {
                    continue;
                }

                fullPrice += productCatalog[c.ToString()].Price;

                if (shoppingCart.ContainsKey(c.ToString()))
                {
                    shoppingCart[c.ToString()]++;
                }
                else
                {
                    shoppingCart[c.ToString()] = 1;
                }
            }

            decimal discount = _discountCalculator.CalculateDiscount(shoppingCart, offers);

            return fullPrice - discount;
        }
    }
}
