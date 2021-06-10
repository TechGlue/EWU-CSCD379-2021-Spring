using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        public User Create(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            using var dbContext = new DbContext();
            dbContext.Users.Add(item);
            dbContext.SaveChanges();
            return item;
        }

        public User? GetItem(int id)
        {
            using var dbContext = new DbContext();
            User user = dbContext.Users.Find(id);
            return user;
        }

        public ICollection<User> List()
        {
            using var dbContext = new DbContext();
            List<User> userList = new List<User>();
            foreach (var user in dbContext.Users)
            {
                userList.Add(user);
            }
            return userList;
        }

        public bool Remove(int id)
        {
            using var dbContext = new DbContext();
            User item = dbContext.Users.Find(id);
            dbContext.Users.Remove(item);
            dbContext.SaveChanges();
            return true;
        }

        public void Save(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            using var dbContext = new DbContext();

            User temp = dbContext.Users.Find(item.UserId);
            
            if (temp is null)
            {
                Create(item);
            }
            else
            {
                dbContext.Users.Remove(dbContext.Users.Find(item.UserId));
                dbContext.Users.Add(item);
            }
            
            dbContext.SaveChanges();
        }
    }
}
