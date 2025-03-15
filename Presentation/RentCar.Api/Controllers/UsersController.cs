using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Dtos.UserDtos;
using RentCar.Application.Services.UserServices;

namespace RentCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userServices.GetAllUsers();
            return Ok(result);
        }
        //bu endpoint calismiyor chtgpt yapamadi.
        [HttpGet("getAllUsersChtGpt")]
        public async Task<IActionResult> GetAllUsersChtGpt()
        {
            var result = await _userServices.GetAllUsersCreaByChatGpt();
            return Ok(result);
        }
        [HttpGet("getByIdUser")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var result = await _userServices.GetByIdUser(id);
            return Ok(result);
        }
        [Authorize(Roles ="admin")]
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            await _userServices.CreateUser(user);
            return Ok("Kulanici Olusturuldu.");
        }
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            await _userServices.UpdateUser(user);
            return Ok("Kulanici Guncellendi.");
        }
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userServices.DeleteUser(id);
            return Ok("Kullanici Silindi.");
        }

    }
}
