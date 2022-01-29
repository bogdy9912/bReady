using System;
using System.Threading.Tasks;
using bReady.Core.IConfiguration;
using bReady.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bReady.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UsersController : ControllerBase{
        private readonly IUnitOfWork _unitOfWork;

        public UsersController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user){
                if (ModelState.IsValid){
                    user.Id = Guid.NewGuid();
                    await _unitOfWork.Users.Add(user);
                    await _unitOfWork.CompleteAsync();

                    return CreatedAtAction("GetItem", new {user.Id}, user);
                }
                return new JsonResult("Smth is wrong") {StatusCode = 500};
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(Guid id){
        var user = await _unitOfWork.Users.GetById(id);

        if (user == null){
        return NotFound();
        }
        return Ok();
    }
    }

   
}
