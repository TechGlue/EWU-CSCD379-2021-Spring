using System.Collections.Generic;

namespace SecretSanta.Data
{
    public static class UserBase
    {
        public static List<User> Users{get;} = new()
        {
            new User(){Id = 0, FirstName = "Luis", LastName = "Garcia"},
            new User(){Id = 1, FirstName = "Ted", LastName = "Bundy"},
            new User(){Id = 2, FirstName = "Bill", LastName = "Tree"},
            new User(){Id = 3, FirstName = "Rock", LastName = "G"},
            new User(){Id = 4, FirstName = "Burr", LastName = "Bill"},
            new User(){Id = 5, FirstName = "Jordan", LastName = "Michael"}
        };
    }
    
}