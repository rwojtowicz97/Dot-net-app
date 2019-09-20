using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {

        }

        public User(Guid userId, string email, string username, 
            string password, string role, string salt)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            //SetPassword(password);
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            Role = role;
        }

        public void SetEmail(string email)
        {
            //Email validation with regex
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(email, pattern))
            {
                Email = email.ToLowerInvariant();
            }
            else
            {
                throw new Exception("Email is invalid.");
            }
        }

        public void SetUsername(string username)
        {
             if(!string.IsNullOrWhiteSpace(username))
            {
                Username = username;

            }
            else 
            {
                throw new Exception("Username is invalid.");
            }
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                throw new Exception("Password is to short or involves white space");
            }
            else 
            {
                Password = password;
            }
        }
    }
}
