using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Persistence.Repositories.RentedCarRepositories
{
    public interface IRentedCarRepository
    {
        Task<List<RentedCar>> GetAllRentedCarsAsync();
        Task<RentedCar> GetByIdRentedCarAsync(int id);
        Task CreateRentedCarAsync(RentedCar model);
        Task UpdateRentedCarAsync(RentedCar model);
        Task DeleteRentedCarAsync(RentedCar model);
    }
}
