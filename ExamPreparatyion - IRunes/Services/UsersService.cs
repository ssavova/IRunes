using ExamPreparatyion___IRunes.Models;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ExamPreparatyion___IRunes.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRunesDbContext db;
        public UsersService(IRunesDbContext db)
        {
            this.db = db;
        }
        public bool IsUsernameUsed(string username)
        {
            return this.db.Users.Any(u => u.Username == username);
        }

        public bool IsEmailUsed(string email)
        {
            return this.db.Users.Any(u => u.Email == email);
        }

        public void CreateUser(string username, string password, string email)
        {
            User user = new User()
            {
                Username = username,
                Password = this.Hash(password),
                Email = email,
                Role = IdentityRole.User,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);
            string userId = this.db.Users
                .Where(u => u.Username == username || u.Email == username && u.Password == passwordHash)
                .Select(a => a.Id).FirstOrDefault();

            return userId;
        }
    }
}
