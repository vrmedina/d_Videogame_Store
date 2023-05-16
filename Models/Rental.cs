using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Videogame? VideogameId { get; set; } // VideogameId is the foreign key to the Videogame table
        public int ClientId { get; set; } // ClientId is the foreign key to the Client table
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Expired { get; set; } // Expired is boolean to check if the rental is expired
        public RentalPrice? RentalPrice { get; set; } // RentalPrice is the foreign key to the RentalPrice table
    }
}