using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Portfolio.Models;

namespace Portfolio.Services 
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User> // Mock database
        {
            new User { Id = 1, Username = "user1", PasswordHash = HashPassword("password1") },
            new User { Id = 2, Username = "user2", PasswordHash = HashPassword("password2") }
        };

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Username == username);
            
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }
            
            return user;
        }

        private static string HashPassword(string password)
        {
            // Hashing function (simplified for this example)
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashBytes);
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == passwordHash;
        }
    }

}