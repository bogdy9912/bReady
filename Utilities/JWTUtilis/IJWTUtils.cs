using bReady.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bReady.Utilities.JWTUtilis
{
    public interface IJWTUtils
    {
        public string GenerateJWTToken(User user);
        public Guid ValidateJWTToken(string token);
    }
}
