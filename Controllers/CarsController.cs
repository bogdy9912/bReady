
using bReady.Models;
using bReady.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("get-cars")]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carService.GetAllCars();
            if (cars == null){
                return NotFound();
            } 
            return Ok(cars);
        }

        [HttpPost("add-car")]
         public async Task<IActionResult> AddCar(Car car){
             Console.WriteLine("A intrat in request");
            await _carService.AddCar(car);
            return Ok();

        }

           [HttpPost("update")]
        public async Task<IActionResult> Update(Car newCar)
        {
            Console.WriteLine("Update Controller");
            var status = await _carService.Update(newCar);
            if (status)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
