using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Data
{
    public static class DbInitializer
    {
        public static List<User> Users()
        {
            return new List<User>
            {
                new User() {UserId = 1, FirstName = "Luis", LastName = "Garcia"},
                new User(){UserId = 2, FirstName = "Jeff", LastName = "Kapplan"},
                new User(){UserId = 3, FirstName = "Terry", LastName = "Crews"}
            };
        }

        public static List<Group> Groups()
        {
            return new List<Group>();
        }
    }
 
}
