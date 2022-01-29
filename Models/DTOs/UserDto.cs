using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Models.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }


        public UserDto(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
        }
    }
}
