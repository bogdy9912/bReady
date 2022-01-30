using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using bReady.Models.Base;

namespace bReady.Models{
    public class Flag : BaseEntity{

        public string Name {get; set;}

        
        public Country Country { get; set; }

        public Guid CountryId { get; set; }

        
   }
}