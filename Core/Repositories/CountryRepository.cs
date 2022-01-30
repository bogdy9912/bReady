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
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Country>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Country>();
            }
        }
        public override async Task<bool> Upsert(Country entity)
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
           public async Task<bool> Update(Country entity)
        {
            try
            {
                var existingCountry = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
        
                existingCountry.Name = entity.Name;


                dbSet.Update(existingCountry);

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