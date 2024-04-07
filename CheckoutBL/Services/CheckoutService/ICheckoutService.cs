using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Services.CheckoutService
{
    public interface ICheckoutService
    {
        decimal CalculatePrice(string shoppingList);
    }
}
