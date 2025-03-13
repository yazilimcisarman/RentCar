using RentCar.Application.Dtos.UserDtos;
using RentCar.Domain.Entities;
using RentCar.Persistence.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(CreateUserDto dto)
        {
            var value = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone,
                Password = dto.Password,
                Role = dto.Role,
            };
            await _userRepository.CreateUserAsync(value);
        }

        public async Task DeleteUser(int id)
        {
            var value = await _userRepository.GetByIdUserAsync(id);
            await _userRepository.DeleteUserAsync(value);
        }

        public async Task<List<ResultUserDto>> GetAllUsers()
        {
            var value = await _userRepository.GetAllUsersAsync();
            var result = value.Select(x => new ResultUserDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                Role = x.Role,
                RentedCars = new List<RentedCar>()

            }).ToList();
            return result;
        }

        public async Task<GetByIdUserDto> GetByIdUser(int id)
        {
            var value = await _userRepository.GetByIdUserAsync(id);
            var result = new GetByIdUserDto
            {
                Id = value.Id,
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Phone = value.Phone,
                Password = value.Password,
                Role = value.Role,
                RentedCars = new List<RentedCar>()
            };
            return result;
        }

        public async Task UpdateUser(UpdateUserDto dto)
        {
            var value = await _userRepository.GetByIdUserAsync(dto.Id);
            value.Name = dto.Name;
            value.Surname = dto.Surname;
            value.Email = dto.Email;
            value.Phone = dto.Phone;
            value.Password = dto.Password;
            value.Role = dto.Role;
            await _userRepository.UpdateUserAsync(value);
        }
    }
}
