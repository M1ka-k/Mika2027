using Mika2027.Models;
using System.Collections.Generic;

namespace Mika2027.Services
{
    class DataRepo
    {
        public static List<User> users = new List<User>();

        public static User GetUser(string username)
        {
            foreach (User user in users)
            {
                if (user.GetUsername() == username)
                {
                    return user;
                }
            }

            return null;
        }

        public static User GetUserByEmail(string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
