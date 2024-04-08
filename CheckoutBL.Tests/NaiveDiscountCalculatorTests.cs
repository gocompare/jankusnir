using CheckoutBL.Offer;
using CheckoutBL.DiscountCalculator;
using Moq;

namespace CheckoutBL.Tests
{
    public class NaiveDiscountCalculatorTests
    {

        [Fact]
        public void CalculateDiscount_ApplyAllOffers_ReturnsCorrectTotal()
        {
            var shoppingCart = new Dictionary<string, int>
            {
                {"A", 5},
                {"X", 2},
            };

            var mockOffer1 = new Mock<IOffer>();
            mockOffer1.Setup(o => o.CalculateOfferDiscount(It.Is<Dictionary<string, int>>(d => d == shoppingCart)))
                .Returns(20);
            var mockOffer2 = new Mock<IOffer>();
            mockOffer2.Setup(o => o.CalculateOfferDiscount(It.Is<Dictionary<string, int>>(d => d == shoppingCart)))
                .Returns(10);

            var offers = new List<IOffer>
            {
                mockOffer1.Object,
                mockOffer2.Object,
            };

            var naiveDiscountCalculator = new NaiveDiscountCalculator();
            var discount = naiveDiscountCalculator.CalculateDiscount(shoppingCart, offers);

            Assert.Equal(30, discount);
        }

        [Fact]
        public void CalculateDiscount_EmptyCollections_ReturnsZero()
        {
            var shoppingCart = new Dictionary<string, int>();
            var offers = new List<IOffer>();

            var naiveDiscountCalculator = new NaiveDiscountCalculator();
            var discount = naiveDiscountCalculator.CalculateDiscount(shoppingCart, offers);

            Assert.Equal(0, discount);
        }
    }
}
