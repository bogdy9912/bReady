using System;
using System.Linq;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;
using bReady.Core.IRepositories;
using bReady.Core.Repositories;
using bReady.Models;
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
            Countries = new CountryRepository(context);
            //  var studentToStandard = ((IQueryable<Car>)Cars.All()).Join(((IQueryable<User>)Users.All()), 
            //             student => student.StandardRefId,
            //             standard => standard.StandardId,
            //             (stud, stand) => new { Student=stud, Standard=stand }).ToList();
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