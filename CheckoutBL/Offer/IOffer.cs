using CheckoutBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Offer
{
    internal interface IOffer
    {
        decimal CalculateOfferDiscount(Dictionary<string, int> shoppingCart);
    }
}
