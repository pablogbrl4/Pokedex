using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTeste.Models
{
    public class Pokemon_Types : BaseModel
    {
        public string Pokemon_Id { get; set; }

        public string Type_Id { get; set; }

        public Types Types { get; set; }

        public _Pokemon_ _Pokemon_ { get; set; }
    }
}
