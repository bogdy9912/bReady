using bReady.Models;
using bReady.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Services
{
    public interface IUserService
    {
        AuthResponseDto Authentificate(AuthRequestDto model);
        IEnumerable<User> GetAllUsers();
        Task<User> GetById(Guid id);
        Task<AuthResponseDto> Register(AuthRequestDto user);

        Task<AuthResponseDto> Login(AuthRequestDto user);
        Task<UserDto> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> DeleteUser(Guid id);
        Task<bool> DeleteAllUsers();
        Task<bool> UpdateUser(UserDto newUser);
    }
}
