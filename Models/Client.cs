using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address {get; set;}
    }
}