using Mika2027.Models;
using System.Collections.Generic;

namespace Mika2027.Services
{
    class DataRepo
    {
        public static List<User> users = new List<User>();
        public static List<Yarn> yarns = new List<Yarn>();

        public static void LoadUserFakeData()
        {
            users.Add(new User
            {
                Email = "rom@example.com",
                Password = "ron12345",
                FullName = "Ron Cohen"
            });

            users.Add(new User
            {
                Email = "daniel@example.com",
                Password = "Daniel456",
                FullName = "Daniel Levi"
            });

            users.Add(new User
            {
                Email = "noa@example.com",
                Password = "Noa12345",
                FullName = "Noa Israel"
            });

            users.Add(new User
            {
                Email = "test@example.com",
                Password = "Test12345",
                FullName = "Test User"
            });

            users.Add(new User
            {
                Email = "yarnlover@example.com",
                Password = "Yarn12345",
                FullName = "Emily Brown"
            });
        }
        public static void LoadYarnFakeData()
        {
            yarns.Add(new Yarn
            {
                Name = "Beach Ball",
                Brand = "Lily Sugar N'cream",
                Weight = 4,
                Grams = 57.0,
                Yards = 95,
                Materials = new List<Material>
            {
                new Material { FiberName = "Cotton", Percent = 100 }
            },
                Colors = new List<string> { "Blue", "White", "Purple", "Green" },
                Skeins = 3,
                ColorLot = null,
                IsNaturalFibers = true,
                IsMachineWashable = true,
                IsVarigated = true,
                Image = "beach_ball.png"
            });

            yarns.Add(new Yarn
            {
                Name = "Sugar Jewels",
                Brand = "Lily Sugar N'cream",
                Weight = 4,
                Grams = 57.0,
                Yards = 95,
                Materials = new List<Material>
            {
                new Material { FiberName = "Cotton", Percent = 100 }
            },
                Colors = new List<string> { "Blue", "Purple", "Pink" },
                Skeins = 3,
                ColorLot = null,
                IsNaturalFibers = true,
                IsMachineWashable = true,
                IsVarigated = true,
                Image = "sugar_jewels.png"
            });

            yarns.Add(new Yarn
            {
                Name = "Plush",
                Brand = "BIG TWIST",
                Weight = 6,
                Grams = 300,
                Yards = 153,
                Materials = new List<Material>
            {
                new Material { FiberName = "Polyester", Percent = 100 }
            },
                Colors = new List<string> { "Pink" },
                Skeins = 1,
                ColorLot = null,
                IsNaturalFibers = false,
                IsMachineWashable = true,
                IsVarigated = false,
                Image = "plush_pink.png"
            });

            yarns.Add(new Yarn
            {
                Name = "Heartland-Frosted Ember",
                Brand = "Lion Brand",
                Weight = 4,
                Grams = 142,
                Yards = 251,
                Materials = new List<Material>
            {
                new Material { FiberName = "Acrylic", Percent = 80 },
                new Material { FiberName = "Wool",    Percent = 20 }
            },
                Colors = new List<string> { "Orange" },
                Skeins = 2,
                ColorLot = null,
                IsNaturalFibers = false,
                IsMachineWashable = true,
                IsVarigated = false,
                Image = "heartland_frosted_amber.png"
            });

            yarns.Add(new Yarn
            {
                Name = "Wool-Ease Thick & Quick",
                Brand = "Lion Brand",
                Weight = 6,
                Grams = 170,
                Yards = 106,
                Materials = new List<Material>
            {
                new Material { FiberName = "Acrylic", Percent = 80 },
                new Material { FiberName = "Wool",    Percent = 20 }
            },
                Colors = new List<string> { "Blue" },
                Skeins = 4,
                ColorLot = null,
                IsNaturalFibers = false,
                IsMachineWashable = true,
                IsVarigated = false,
                Image = "thick_and_quick_blue.png"
            });

            yarns.Add(new Yarn
            {
                Name = "Cotton Fair Multi",
                Brand = "Premier Yarns",
                Weight = 4,
                Grams = 100,
                Yards = 317,
                Materials = new List<Material>
            {
                new Material { FiberName = "Cotton",  Percent = 50 },
                new Material { FiberName = "Acrylic", Percent = 50 }
            },
                Colors = new List<string> { "Turquoise", "Coral", "Lime", "Grey" },
                Skeins = 3,
                ColorLot = null,
                IsNaturalFibers = false,
                IsMachineWashable = true,
                IsVarigated = true,
                Image = "cotton_fair_turquoise.png"
            });
        }
        public static User GetUserByEmail(string email)
        {
            foreach (User user in users)
            {
                if (user.Email.ToLower() == email.ToLower())
                {
                    return user;
                }
            }

            return null;
        }
    }
}
