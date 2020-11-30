using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTeste.Models
{
    public class Types : BaseModel
    {
        public string Type { get; set; }

        public List<Pokemon_Types> Pokemon_Types { get; set; }
    }
}
