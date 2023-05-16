using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace d_Videogame_Store.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context; 
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();

            // Get the user from the database
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            // Check if the user exists
            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect password";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
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

            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            // Check if the username exists in the database
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
            // Here we are using the HMACSHA512 class to create the password hash and salt
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // This method is used to verify the password hash and salt
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Create a new instance of the HMACSHA512 class
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                // Compute the hash of the password that is passed in
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                // Compare the computed hash with the password hash that is stored in the database
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        // This method is used to create the JWT token
        private string CreateToken(User user)
        {
            // Create the claims that will be used to create the token
            var claims = new List<Claim>
            {
                // Add the user id to the claims
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                // Add the username to the claims
                new Claim(ClaimTypes.Name, user.Username)
            };

            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;

            if(appSettingsToken is null)
            {
                throw new Exception("Token not found");
            }

            // Create the key that will be used to sign the token
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettingsToken));

            // Create the credentials that will be used to sign the token
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Add the claims to the token descriptor
                Subject = new ClaimsIdentity(claims),
                // Set the expiration date of the token
                Expires = DateTime.Now.AddDays(1),
                // Add the credentials to the token descriptor
                SigningCredentials = creds
            };

            // Create the token handler
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            // Create the token
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the token
            return tokenHandler.WriteToken(token);
        }
    }
}