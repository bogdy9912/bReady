using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bReady.Core.IRepositories{
    public interface IGenericRepository<T> where T : class{
        Task<IEnumerable<T>> All();

        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Delete(Guid id);
        Task<T> Upsert(T entity);
    }
}