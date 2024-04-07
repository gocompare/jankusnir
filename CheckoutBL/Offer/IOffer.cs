using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Offer
{
    public interface IOffer
    {
        public decimal CalculateOfferDiscount(Dictionary<string, int> shoppingCart);
    }
}
