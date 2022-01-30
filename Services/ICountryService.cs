using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bReady.Models;

namespace bReady.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<bool> AddCountry(Country country);

        Task<Country> GetCountryById(Guid id);
        Task<bool> Delete(Guid id);

        Task<bool> Update(Country newCountry);
      
    }
}
