using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Persistence.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentCarDbContext _context;

        public UserRepository(RentCarDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User model)
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User model)
        {
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task UpdateUserAsync(User model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
