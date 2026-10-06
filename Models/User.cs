using System;

namespace Mika2027.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PName { get; set; }
        public string FName { get; set; }
        public DateTime BirthDate { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Email = username;
            Password = password;
        }

        public string GetUserName() => Email;
        public void SetUsername(string username) => Email = username;

        public string GetPassword() => Password;
        public void SetPassword(string password) => Password = password;
    }
}