using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTeste.Models
{
    public class _Pokemon_ : BaseModel
    {
        public int Pokedex_Index { get; set; }

        public string Name { get; set; }

        public int Hp { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Special_attack { get; set; }

        public int Special_defense { get; set; }

        public int Speed { get; set; }

        public int Generation { get; set; }

        public List<Pokemon_Types> Pokemon_Types { get; set; }
    }
}
