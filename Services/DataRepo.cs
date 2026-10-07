using Mika2027.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mika2027.Services
{
    class DataRepo
    {
        public static List<User> users = new List<User>();


        public static User GetUser(string username)
        {
            foreach (User user in users)
            {
                if(user.GetUsername() == username)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
