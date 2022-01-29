using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bReady.Models;

namespace bReady.Core.IRepositories{
    public interface IGenericRepository<T> where T : class{
        Task<IEnumerable<T>> All();

        Task<bool> Add(T entity);
        Task<T> GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
    }
}