using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
            
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            
            if(await UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            // Create the password hash and salt
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // Add the password hash and salt to the user object
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // This method is used to create the password hash and salt
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}