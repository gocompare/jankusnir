﻿using CheckoutBL.Models;
using CheckoutBL.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.DiscountCalculator
{
    public interface IDiscountCalculator
    {
        public decimal CalculateDiscount(Dictionary<string, int> shoppingCart, List<IOffer> offers);
    }
}
