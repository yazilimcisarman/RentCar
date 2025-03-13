using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Persistence.Repositories.CarRepositories
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetByIdCarAsync(int id);
        Task CreateCarAsync(Car entity);
        Task UpdateCarAsync(Car entity);
        Task DeleteCarAsync(Car entity);
    }
}
