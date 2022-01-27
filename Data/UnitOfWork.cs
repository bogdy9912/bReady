using System;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;
using bReady.Core.IRepositories;
using bReady.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace bReady.Data{
    public class UnitOfWork : IUnitOfWork, IDisposable{
        protected readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            Users = new UserRepository(context, _logger);
        }

        public IUserRepository Users {get;private set;}
 
        public async Task CompleteAsync(){
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
             _context.Dispose();
            
        }
    }
}