using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Persistence.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByIdUserAsync(int id);
        Task CreateUserAsync(User model);
        Task UpdateUserAsync(User model);
        Task DeleteUserAsync(User model);
        Task<User> CheckUser(string email,string password);
    }
}
