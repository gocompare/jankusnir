using CheckoutBL.Models;
using CheckoutBL.Offer;

namespace CheckoutBL.Tests
{
    public class MultiBuyOfferTests
    {
        [Fact]
        public void CalculateDiscount_ReturnsCorrectDiscount()
        {
            var offer = new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 3, 130);
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 5},
                {"X", 2},
            };

            var discount = offer.CalculateOfferDiscount(shoppingCart);

            Assert.Equal(expected: 20, actual: discount);
        }

        [Fact]
        public void ConstructOffer_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 0, 130));
        }

        [Fact]
        public void CalculateDiscount_DiscountEveryItem_ReturnsCorrectDiscount()
        {
            var offer = new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 1, 30);
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 5},
                {"X", 2},
            };
            var discount = offer.CalculateOfferDiscount(shoppingCart);

            Assert.Equal(expected: 100, actual: discount);
        }

        [Fact]
        public void CalculateDiscount_ReturnsNegativeDiscount()
        {
            var offer = new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 2, 110);
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 3},
            };
            var discount = offer.CalculateOfferDiscount(shoppingCart);

            Assert.Equal(expected: -10, actual: discount);
        }

        [Fact]
        public void CalculateDiscount_DiscountEveryItem_ReturnsNegativeDiscount()
        {
            var offer = new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 1, 70);
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 3},
            };
            var discount = offer.CalculateOfferDiscount(shoppingCart);

            Assert.Equal(expected: -60, actual: discount);
        }

        [Fact]
        public void CalculateDiscount_ReturnsZeroDiscount()
        {
            var offer = new MultiBuyOffer(new Product { SKU = "A", Price = 50 }, 3, 130);
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 2},
                {"X", 2},
                {"B", 1},
                {"T", 2},
            };

            var discount = offer.CalculateOfferDiscount(shoppingCart);

            Assert.Equal(expected: 0, actual: discount);
        }
    }
}