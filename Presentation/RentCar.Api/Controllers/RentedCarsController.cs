using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Services.RentedCarServices;

namespace RentCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedCarsController : ControllerBase
    {
        private readonly IRentedCarServices _services;

        public RentedCarsController(IRentedCarServices services)
        {
            _services = services;
        }
        [HttpGet("getAllRentedCars")]
        public async Task<IActionResult> GetAllRentedCars()
        {
            var result = await _services.GetAllRentedCars();
            return Ok(result);
        }
    }
}
