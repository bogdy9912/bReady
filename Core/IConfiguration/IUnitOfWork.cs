using System.Threading.Tasks;
using bReady.Core.IRepositories;
using bReady.Core.Repositories;

namespace bReady.Core.IConfiguration{

    
    public interface IUnitOfWork{
        IUserRepository Users{get;}
        CarRepository Cars{get;}
        CountryRepository Countries{get;}

        Task CompleteAsync();
    }

}