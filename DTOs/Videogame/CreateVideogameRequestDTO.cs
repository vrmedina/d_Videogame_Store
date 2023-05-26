using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.DTOs.Videogame
{
    public class CreateVideogameRequestDTO
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Protagonists { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Platform { get; set; }
    }
}