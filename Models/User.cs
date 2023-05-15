using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public string Role { get; set; } = string.Empty;
        public Client? Client { get; set; }
    }
}