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

    public class UsersController : ControllerBase
    {

        private IUserService _userService;


        public UsersController(IUserService userService) { 
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequestDto user)
        {
            if (ModelState.IsValid)
            {
                var authResponseDto = await _userService.Register(user);

                return Ok(authResponseDto);
            }
            return new JsonResult("Smth is wrong") { StatusCode = 500 };
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequestDto authCredentials)
        {
            if (ModelState.IsValid)
            {
                var authResponseDto = await _userService.Login(authCredentials);
                return Ok(authResponseDto);
            }
            return new JsonResult("Smth is wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {

            var userDto = await _userService.GetUserById(id);

            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }



        
        [Authorization(Role.Admin)]
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }


        // [HttpPost("{id}")]
        // public async Task<IActionResult> UpdateUser(UserDto user)
        // {
        //     await _userService.UpdateUser(user);
        //         // return BadRequest();


        //     await _unitOfWork.Users.Upsert(user);
        //     await _unitOfWork.CompleteAsync();

        //     return NoContent();
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var status = await _userService.DeleteUser(id);
            if (status)
            {
                return Ok(id);
            }
            return NotFound();

        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAll()
        {
            var status = await _userService.DeleteAllUsers();
            if (status)
            {
                return Ok();
            }
            return BadRequest();
        }

    }


}
