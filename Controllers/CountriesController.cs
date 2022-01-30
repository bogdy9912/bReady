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

        private IUserService _countryService;


        public CountriesController(IUserService countryService) { 
            _countryService = countryService;
        }


    }
}