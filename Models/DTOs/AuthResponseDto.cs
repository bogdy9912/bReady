using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Models.DTOs
{
    public class AuthResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public string Token { get; set; }


        public AuthResponseDto(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }
    }
}
