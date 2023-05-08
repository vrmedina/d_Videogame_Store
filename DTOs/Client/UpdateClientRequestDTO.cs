using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.DTOs.Client
{
    public class UpdateClientRequestDTO
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Document { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address {get; set;}
    }
}