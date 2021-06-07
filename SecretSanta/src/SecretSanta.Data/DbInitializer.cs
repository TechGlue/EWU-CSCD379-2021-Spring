using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Data
{
    public static class DbInitializer
    {
        public static List<User> Users()
        {
            return new List<User> {new User() {UserId = 1, FirstName = "Luis", LastName = "Garcia"}};
        }

        public static List<Group> Groups()
        {
            return new List<Group>();
        }
    }
 
}
