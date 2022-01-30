using bReady.Models;
using bReady.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Services
{
    public interface ICarService
    {
         Task<IEnumerable<Car>> GetAllCars();
        Task<bool> AddCar(Car car);

        Task<bool> Update(Car newCar);
      
    }
}
