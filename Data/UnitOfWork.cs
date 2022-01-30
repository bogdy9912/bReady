using System;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;
using bReady.Core.IRepositories;
using bReady.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace bReady.Data{
    public class UnitOfWork : IUnitOfWork, IDisposable{
        protected readonly ApplicationDbContext _context;

     

        public IUserRepository Users {get;private set;}
        public CarRepository Cars {get;private set;}

        public CountryRepository Countries{get; private set;}
        
 
           public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Cars = new CarRepository(context);
        }

        public async Task CompleteAsync(){
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
             _context.Dispose();
            
        }
    }
}