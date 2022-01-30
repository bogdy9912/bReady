using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using bReady.Models.Base;

namespace bReady.Models{
    public class Country : BaseEntity{

        public string Name {get; set;}

        
        public ICollection<ModelsRelation> ModelsRelations { get; set; }

        public Flag Flag{get; set;}

        
   }
}