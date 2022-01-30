using System;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;
using bReady.Models;
using bReady.Models.DTOs;
using bReady.Services;
using bReady.Utilities.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace bReady.Controllers
{


    [ApiController]
    [Route("[controller]")]

    public class CountriesController : ControllerBase
    {

        private ICountryService _countryService;


        public CountriesController(ICountryService countryService) { 
            _countryService = countryService;
        }



        
        [HttpGet("get-countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetAllCountries();
            if (countries == null){
                return NotFound();
            } 
            return Ok(countries);
        }

        [HttpPost("add-country")]
         public async Task<IActionResult> AddCountry(Country country){
             
            await _countryService.AddCountry(country);
            return Ok();

        }
        [HttpGet("{id}")]
         public async Task<IActionResult> GetCountryById(Guid id){
             
            var country = await _countryService.GetCountryById(id);
            return Ok(country);

        }

        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteCountry(Guid id){
            //  if (id == Guid.Empty){
                // return BadRequest("ID field is mandatory");
            //  }
            var country = await _countryService.Delete(id);
            return Ok(country);

        }
           [HttpPost("update")]
        public async Task<IActionResult> Update(Country newCountry)
        {
            if (newCountry.Id == null || newCountry.Id == Guid.Empty){
                return BadRequest("ID field is mandatory");
            }
            
            var status = await _countryService.Update(newCountry);
            if (status)
            {
                return Ok();
            }
            return BadRequest();
        }

        

    }
}