using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bReady.Models;

namespace bReady.Models
{
    public class ModelsRelation
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }


        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
