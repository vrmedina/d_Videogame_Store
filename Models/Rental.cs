using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal RentalPrice { get; set; }
    }
}