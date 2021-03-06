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
using Microsoft.EntityFrameworkCore;

namespace bReady.Services
{
    public class CarService : ICarService
    {

        public ApplicationDbContext _applicationDbContext;
        private IJWTUtils _iJWtUtils;
        private readonly AppSettings _appSettings;


        private readonly IUnitOfWork _unitOfWork;

        public CarService(ApplicationDbContext applicationDbContext, IJWTUtils iJWtUtils, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _applicationDbContext = applicationDbContext;
            _iJWtUtils = iJWtUtils;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _unitOfWork.Cars.All();
        }

        public async Task<bool> AddCar(Car car)
        {
            await _unitOfWork.Cars.Add(car);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> Update(Car newCar)
        {
            await _unitOfWork.Cars.Update(newCar);
            await _unitOfWork.CompleteAsync();
            return true;
        }


        public IEnumerable<User> Retrieve()
        {
            var _query = _applicationDbContext.Users.Include(a => a.car).Where(o => o.car.Name == "Audi");

            // _query
            return _query;
        }

    }
}
