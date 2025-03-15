using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.AuthDtos;
using RentCar.Application.Services.UserServices;
using RentCar.Persistence.Services.AuthServices;
using System.Runtime.InteropServices;

namespace RentCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IUserServices _userServices;

        public AuthController(IAuthServices authServices, IUserServices userServices)
        {
            _authServices = authServices;
            _userServices = userServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userServices.CheckUser(model);
            if(user != null)
            {
                var token = _authServices.GenerateToken(user.Id.ToString(),user.Role);
                return Ok(new {jwtToken= token});
            }
            return Unauthorized();
            
        }
    }
}
