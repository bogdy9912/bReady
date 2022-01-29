using System;
using System.Threading.Tasks;
using bReady.Models;

namespace bReady.Core.IRepositories{
    public interface IUserRepository : IGenericRepository<User>{
        Task<User> GetByIdOrUsername(Guid? id, string username);
    }
}