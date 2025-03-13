using RentCar.Application.Dtos.RentedCarDtos;
using RentCar.Domain.Entities;
using RentCar.Persistence.Repositories.CarRepositories;
using RentCar.Persistence.Repositories.RentedCarRepositories;
using RentCar.Persistence.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.RentedCarServices
{
    public class RentedCarServices : IRentedCarServices
    {
        private readonly IRentedCarRepository _rentedCarRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;

        public RentedCarServices(IRentedCarRepository rentedCarRepository, IUserRepository userRepository, ICarRepository carRepository)
        {
            _rentedCarRepository = rentedCarRepository;
            _userRepository = userRepository;
            _carRepository = carRepository;
        }

        public async Task CreateRentedCar(CreateRentedCarDto dto)
        {
            var value = new RentedCar
            {
                UserId = dto.UserId,
                CarId = dto.CarId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                DamagePrice = dto.DamagePrice,
                IsCompleted = dto.IsCompleted,
            };
            await _rentedCarRepository.CreateRentedCarAsync(value);
        }

        public async Task DeleteRentedCar(int id)
        {
            var value = await _rentedCarRepository.GetByIdRentedCarAsync(id);
            await _rentedCarRepository.DeleteRentedCarAsync(value);
        }

        public async Task<List<ResultRentedCarDto>> GetAllRentedCars()
        {
            var value = await _rentedCarRepository.GetAllRentedCarsAsync();
            var users = await _userRepository.GetAllUsersAsync();
            var cars = await _carRepository.GetAllCarsAsync();
            var result = new List<ResultRentedCarDto>();
            //var result = value.Select(x => new ResultRentedCarDto
            //{
            //    Id = x.Id,
            //    UserId = x.UserId,
            //    CarId = x.CarId,
            //    Car = x.Car,
            //    StartDate = x.StartDate,
            //    EndDate = x.EndDate,
            //    TotalPrice = x.TotalPrice,
            //    DamagePrice = x.DamagePrice,
            //    IsCompleted = x.IsCompleted,

            //}).ToList();

            foreach (var rentedCar in value) 
            {
                var user = await _userRepository.GetByIdUserAsync(rentedCar.UserId);
                var car = await _carRepository.GetByIdCarAsync(rentedCar.CarId);
                var newrentedcar = new ResultRentedCarDto
                {
                    Id = rentedCar.Id,
                    UserId = rentedCar.UserId,
                    User = user,
                    CarId = rentedCar.CarId,
                    Car =car,
                    StartDate = rentedCar.StartDate,
                    EndDate = rentedCar.EndDate,
                    TotalPrice = rentedCar.TotalPrice,
                    DamagePrice = rentedCar.DamagePrice,
                    IsCompleted = rentedCar.IsCompleted,
                };
                result.Add(newrentedcar);
            }


            return result;
        }

        public async Task<GetByIdRentedCarDto> GetByIdRentedCar(int id)
        {
            var value = await _rentedCarRepository.GetByIdRentedCarAsync(id);
            var result = new GetByIdRentedCarDto
            {
                Id = value.Id,
                UserId = value.UserId,
                CarId = value.CarId,
                StartDate = value.StartDate,
                EndDate = value.EndDate,
                TotalPrice = value.TotalPrice,
                DamagePrice = value.DamagePrice,
                IsCompleted = value.IsCompleted,
            };
            return result;
        }

        public async Task UpdateRentedCar(UpdateRentedCarDto dto)
        {
            var value = await _rentedCarRepository.GetByIdRentedCarAsync(dto.Id);
            value.UserId = dto.UserId;
            value.CarId = dto.CarId;
            value.StartDate = dto.StartDate;
            value.EndDate = dto.EndDate;
            value.TotalPrice = dto.TotalPrice;
            value.DamagePrice = dto.DamagePrice;
            value.IsCompleted = dto.IsCompleted;

            await _rentedCarRepository.UpdateRentedCarAsync(value);
        }
    }
}
