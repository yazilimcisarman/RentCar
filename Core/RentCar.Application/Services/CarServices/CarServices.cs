using RentCar.Application.Dtos.CarDtos;
using RentCar.Domain.Entities;
using RentCar.Persistence.Repositories.CarRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.CarServices
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _repository;

        public CarServices(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCar(CreateCarDto dto)
        {
            var value = new Car
            {
                ImageUrl = dto.ImageUrl,
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                KM = dto.KM,
                Type = dto.Type,
                Fuel = dto.Fuel,
                DailyPrice = dto.DailyPrice,
                IsAvailable = dto.IsAvailable,
            };
            await _repository.CreateCarAsync(value);
        }

        public async Task DeleteCar(int id)
        {
            var value = await _repository.GetByIdCarAsync(id);
            await _repository.DeleteCarAsync(value);
        }

        public async Task<List<ResultCarDto>> GetAllCars()
        {
            var value = await _repository.GetAllCarsAsync();
            var result = value.Select(x => new ResultCarDto
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Brand = x.Brand,
                Model = x.Model,
                Year = x.Year,
                KM = x.KM,
                Type = x.Type,
                Fuel = x.Fuel,
                DailyPrice = x.DailyPrice,
                IsAvailable = x.IsAvailable,
            }).ToList();
            return result;
        }

        public async Task<GetByIdCarDto> GetByIdCar(int id)
        {
            var value = await _repository.GetByIdCarAsync(id);
            var result = new GetByIdCarDto 
            {
                Id = value.Id,
                ImageUrl= value.ImageUrl,
                Brand = value.Brand,
                Model = value.Model,
                Year = value.Year,
                KM = value.KM,
                Type = value.Type,
                Fuel = value.Fuel,
                DailyPrice = value.DailyPrice,
                IsAvailable = value.IsAvailable,
            };
            return result;
        }

        public async Task UpdateCar(UpdateCarDto dto)
        {
            var value = await _repository.GetByIdCarAsync(dto.Id);
            value.ImageUrl = dto.ImageUrl;
            value.Brand = dto.Brand;
            value.Model = dto.Model;
            value.Year = dto.Year;
            value.KM = dto.KM;
            value.Type = dto.Type;
            value.Fuel = dto.Fuel;
            value.DailyPrice = dto.DailyPrice;
            value.IsAvailable = dto.IsAvailable;

            await _repository.UpdateCarAsync(value);
        }
    }
}
