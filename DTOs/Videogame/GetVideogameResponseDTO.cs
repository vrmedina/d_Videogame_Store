using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Services.VideogameService
{
    public class GetVideogameResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<string> Protagonists { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Platform { get; set; }
    }
}