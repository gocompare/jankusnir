using CheckoutBL.DataRepository;
using CheckoutBL.DiscountCalculator;
using CheckoutBL.Models;
using CheckoutBL.Offer;
using CheckoutBL.Services.CheckoutService;
using Moq;

namespace CheckoutBL.Tests
{
    public class CheckoutServiceTests
    {
        private readonly CheckoutService _checkoutService;
        private readonly IDataRepository _dataRepository;

        public CheckoutServiceTests()
        {
            var mockDataRepository = new Mock<IDataRepository>();
            mockDataRepository.Setup(d => d.GetProducts()).Returns(new Dictionary<string, Product>
            {
                {"A", new Product {SKU = "A", Price = 50}},
                {"B", new Product {SKU = "B", Price = 30}},
                {"C", new Product {SKU = "C", Price = 20}},
                {"D", new Product {SKU = "D", Price = 15}},
            });

            _dataRepository = mockDataRepository.Object;

            mockDataRepository.Setup(d => d.GetOffers()).Returns(new List<IOffer>
            {
                new MultiBuyOffer(new Product {SKU = "A", Price = 50}, 3, 130),
                new MultiBuyOffer(new Product {SKU = "B", Price = 30}, 2, 45)
            });

            var mockDiscountCalculator = new Mock<IDiscountCalculator>();
            mockDiscountCalculator.Setup(c => c.CalculateDiscount(It.IsAny<IDictionary<string, int>>(), It.IsAny<IEnumerable<IOffer>>()))
                .Returns(0);

            _checkoutService = new CheckoutService(mockDiscountCalculator.Object, _dataRepository);
        }

        [Fact]
        public void CalculatePrice_ReturnsCorrectPrice()
        {
            var price = _checkoutService.CalculatePrice("AABBD");
            Assert.Equal(175, price);
        }

        [Fact]
        public void CalculatePrice_EmptyString_ReturnsCorrectPrice()
        {
            var price = _checkoutService.CalculatePrice("");
            Assert.Equal(0, price);
        }

        [Fact]
        public void CalculatePrice_NonExistantProducts_ReturnsZero()
        {
            var price = _checkoutService.CalculatePrice("TbyqxHhga 2g56");
            Assert.Equal(0, price);
        }

        [Fact]
        public void CalculatePrice_ApplyDiscount_ReturnsCorrectPrice()
        {
            var mockDiscountCalculator = new Mock<IDiscountCalculator>();
            mockDiscountCalculator.Setup(c => c.CalculateDiscount(It.IsAny<IDictionary<string, int>>(), It.IsAny<IEnumerable<IOffer>>()))
                .Returns(50);

            var checkoutService = new CheckoutService(mockDiscountCalculator.Object, _dataRepository);

            var price = checkoutService.CalculatePrice("BAAADDC");
            Assert.Equal(180, price);
        }
    }
}
