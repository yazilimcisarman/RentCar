using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Persistence.Repositories.RentedCarRepositories
{
    public class RentedCarRepository : IRentedCarRepository
    {
        private readonly RentCarDbContext _context;

        public RentedCarRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task CreateRentedCarAsync(RentedCar model)
        {
            await _context.RentedCars.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentedCarAsync(RentedCar model)
        {
            _context.RentedCars.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RentedCar>> GetAllRentedCarsAsync()
        {
            var value = await _context.RentedCars.ToListAsync();
            return value;
        }

        public async Task<RentedCar> GetByIdRentedCarAsync(int id)
        {
            var value = await _context.RentedCars.FirstOrDefaultAsync(x => x.Id == id);
            return value;
        }

        public async Task<List<RentedCar>> GetRentedCarsByUserId(int userId)
        {
            var value = await _context.RentedCars.Where(x => x.UserId == userId).ToListAsync();
            return value;
        }

        public async Task UpdateRentedCarAsync(RentedCar model)
        {
            _context.RentedCars.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
