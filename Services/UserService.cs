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
    public class UserService : IUserService
    {

        public ApplicationDbContext _applicationDbContext;
        private IJWTUtils _iJWtUtils;
        private readonly AppSettings _appSettings;


        private readonly IUnitOfWork _unitOfWork;

        public UserService(ApplicationDbContext applicationDbContext, IJWTUtils iJWtUtils, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _applicationDbContext = applicationDbContext;
            _iJWtUtils = iJWtUtils;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;


        }


        public AuthResponseDto Authentificate(AuthRequestDto model)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.Username == model.Username);

            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; //or throw exception
            }

            // jwt generation
            var jwtToken = _iJWtUtils.GenerateJWTToken(user);
            return new AuthResponseDto(user, jwtToken);
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _unitOfWork.Users.GetById(id);
            
        }


        public async Task<AuthResponseDto> Register(AuthRequestDto user)
        {
            var userToCreate = new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password),
                Email = user.Email,
                LastName = user.LastName
            };
            await _unitOfWork.Users.Add(userToCreate);
            var jwtToken = _iJWtUtils.GenerateJWTToken(userToCreate);
            await _unitOfWork.CompleteAsync();
            return new AuthResponseDto(userToCreate, jwtToken);
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto authCredentials)
        {
            var user = await _unitOfWork.Users.GetByIdOrUsername(null, authCredentials.Username);
            var jwtToken = _iJWtUtils.GenerateJWTToken(user);
            return new AuthResponseDto(user, jwtToken);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            return new UserDto(await _unitOfWork.Users.GetById(id));
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.Users.All();
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var item = await _unitOfWork.Users.GetById(id);

            if (item == null)
            {
                return false;
            }
            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.CompleteAsync();

            return true;
        }
        public async Task<bool> DeleteAllUsers()
        {
            var items = await _unitOfWork.Users.All();

            Console.Write(items);
            if (items == null)
            {
                return false;
            }

            foreach (var item in items)
            {
                await _unitOfWork.Users.Delete(item.Id);

            }

            await _unitOfWork.CompleteAsync();

            return true;
        }

    }
}
