using System;
using System.Threading.Tasks;
using bReady.Models;
using bReady.Models.DTOs;

namespace bReady.Core.IRepositories{
    public interface IUserRepository : IGenericRepository<User>{
        Task<User> GetByIdOrUsername(Guid? id, string username);
        Task<bool> Update(UserDto user);

    }
}