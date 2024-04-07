using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBL.Models
{
    public class Product
    {
        public required string SKU { get; set; }
        public decimal Price { get; set; }
    }
}
