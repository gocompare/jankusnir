using CheckoutBL.Services.CheckoutService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var price = _checkoutService.CalculatePrice(value);
            return Ok(price);
        }
    }
}
