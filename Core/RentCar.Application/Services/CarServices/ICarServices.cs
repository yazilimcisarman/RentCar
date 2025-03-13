using RentCar.Application.Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.CarServices
{
    public interface ICarServices
    {
        Task<List<ResultCarDto>> GetAllCars();
        Task<GetByIdCarDto> GetByIdCar(int id);
        Task CreateCar(CreateCarDto dto);
        Task UpdateCar(UpdateCarDto dto);
        Task DeleteCar(int id);
    }
}
