﻿using RentCar.Application.Dtos.AuthDtos;
using RentCar.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Services.UserServices
{
    public interface IUserServices
    {
        Task<List<ResultUserDto>> GetAllUsers();
        Task<List<ResultUserDto>> GetAllUsersCreaByChatGpt();
        Task<GetByIdUserDto> GetByIdUser(int id);
        Task CreateUser(CreateUserDto dto);
        Task UpdateUser(UpdateUserDto dto);
        Task DeleteUser(int id);
        Task<OnlyInfoUserDto> CheckUser(LoginDto dto);
    }
}
