using System;

namespace Mika2027.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }


        public string GetUsername()
        {
            return Username;
        }
        public void SetUsername(string username)
        {
            Username = username;
        }

        public string GetPassword()
        {
            return Password;
        }
        public void SetPassword(string password)
        {
            Password = password;

        }
    }
    }