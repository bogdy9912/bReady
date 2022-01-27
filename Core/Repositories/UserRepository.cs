using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bReady.Core.IRepositories;
using bReady.Data;
using bReady.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace bReady.Core.Repositories{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context, ILogger logger) : base(_context, logger)
        {
            
        }

        public Task<string> GetFirstNameAndLastName(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<User>> All(){
            try{
                return await dbSet.ToListAsync();
            }catch(Exception ex){
                    _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                    return new List<User>();
            }
        }
        public override async Task<bool> Upsert(User entity){
            try{
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null){
                    await Add(entity);
                    return true;
                }

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;

                return true;
                
                
            }catch(Exception ex){
                    _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                    return false;
            }
        }

                public override async Task<bool> Delete(Guid id){
            try{
                var existingUser = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (existingUser != null){
                    dbSet.Remove(existingUser);
                    return true;
                }

                return false;
                
                
            }catch(Exception ex){
                    _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                    return false;
            }
    
    }
    }
}