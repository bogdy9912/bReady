using System;
using System.Text.Json.Serialization;
using bReady.Models.Base;

namespace bReady.Models{
    public class User : BaseEntity{

        public string FirstName {get; set;}

        public string LastName {get; set;}


        public string Email {get; set;}
        
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public Role Role { get; set; }
        
        
        public Car car{get; set;}
    }
}