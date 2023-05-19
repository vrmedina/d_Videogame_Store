using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public List<string> Protagonists { get; set; } = new List<string>();
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public User? User { get; set; }
    }
}