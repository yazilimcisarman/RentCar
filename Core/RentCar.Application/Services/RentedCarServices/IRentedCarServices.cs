using RentCar.Application.Dtos.RentedCarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.RentedCarServices
{
    public interface IRentedCarServices
    {
        Task<List<ResultRentedCarDto>> GetAllRentedCars();
        Task<GetByIdRentedCarDto> GetByIdRentedCar(int id);
        Task CreateRentedCar(CreateRentedCarDto dto);
        Task UpdateRentedCar(UpdateRentedCarDto dto);
        Task DeleteRentedCar(int id);
    }
}
