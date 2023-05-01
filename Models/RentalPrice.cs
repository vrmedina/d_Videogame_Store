using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class RentalPrice
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public decimal PricePerDay { get; set; }
    }
}