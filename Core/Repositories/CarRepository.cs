using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bReady.Core.IRepositories;
using bReady.Data;
using bReady.Models;
using bReady.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace bReady.Core.Repositories
{
    public class CarRepository : GenericRepository<Car>
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Car>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Car>();
            }
        }
        public override async Task<bool> Upsert(Car entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                {
                    await Add(entity);
                    return true;
                }

                // existingUser.FirstName = entity.FirstName;
                // existingUser.LastName = entity.LastName;
                // existingUser.Email = entity.Email;

                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        } 
           public async Task<bool> Update(UserDto entity)
        {
            try
            {
                // var existingUser = await dbSet.Where(x => x.Username == entity.Username).FirstOrDefaultAsync();
        
                // existingUser.FirstName = entity.FirstName;
                // existingUser.LastName = entity.LastName;
                

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                
                var existingUser = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    dbSet.Remove(existingUser);
                    return true;
                }

                return false;


            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}