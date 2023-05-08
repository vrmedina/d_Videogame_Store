using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Rental_Videogame
    {
        // To be able to know which videogame is the most rented
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int VideogameId { get; set; }
    }
}