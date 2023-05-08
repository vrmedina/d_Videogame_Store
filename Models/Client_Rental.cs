using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Client_Rental
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RentalId { get; set; }
    }
}