using bReady.Data;
using bReady.Models;
using bReady.Models.DTOs;
using bReady.Utilities;
using bReady.Utilities.JWTUtilis;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;

namespace bReady.Services
{
    public class CountryService : ICountryService
    {

        public ApplicationDbContext _applicationDbContext;
        private IJWTUtils _iJWtUtils;
        private readonly AppSettings _appSettings;


        private readonly IUnitOfWork _unitOfWork;

        public CountryService(ApplicationDbContext applicationDbContext, IJWTUtils iJWtUtils, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _applicationDbContext = applicationDbContext;
            _iJWtUtils = iJWtUtils;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetAllCountries(){
            return await _unitOfWork.Countries.All();
        }

        public async Task<bool> AddCountry(Country country){
            await _unitOfWork.Countries.Add(country);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        public async Task<Country> GetCountryById(Guid id){
            var country = await _unitOfWork.Countries.GetById(id);
            await _unitOfWork.CompleteAsync();
            return country;
        }
        public async Task<bool> Delete(Guid id){
            await _unitOfWork.Countries.Delete(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        
        public async Task<bool> Update(Country newCountry){
            await _unitOfWork.Countries.Update(newCountry);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public Object Retrieve(Guid id){
            var query = _applicationDbContext.Countries.Join(_applicationDbContext.Flags, c => c.Id, f => f.CountryId, (c,f) => new {Country = c, Flag = f}).Where(countryAndFlag => countryAndFlag.Country.Id==id);
            return query;
        }



    }
}
