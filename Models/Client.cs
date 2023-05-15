using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; } // Foreign Key
        public User User { get; set; } = null!; // Navigation Property
    }
}