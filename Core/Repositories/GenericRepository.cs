using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bReady.Core.IRepositories;
using bReady.Data;
using Microsoft.EntityFrameworkCore;

namespace bReady.Core.Repositories{
    public class GenericRepository<T> : IGenericRepository<T> where T: class{
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;


        public GenericRepository(
            ApplicationDbContext context
        ){
            _context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
           return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

    }
}