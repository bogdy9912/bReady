using System.Threading.Tasks;
using bReady.Core.IRepositories;

namespace bReady.Core.IConfiguration{

    
    public interface IUnitOfWork{
        IUserRepository Users{get;}
        Task CompleteAsync();
    }

}