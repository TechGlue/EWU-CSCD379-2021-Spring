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

            using DbContext dbContext = new DbContext();
            dbContext.Users.Add(item);
            dbContext.SaveChangesAsync();
            return item;
        }

        public User? GetItem(int id)
        {
            using DbContext dbContext = new DbContext();
            User user = dbContext.Users.Find(id);
            return user;
        }

        public ICollection<User> List()
        {
            using DbContext dbContext = new DbContext();
            List<User> userList = new List<User>();
            foreach (var user in dbContext.Users)
            {
                userList.Add(user);
            }
            return userList;
        }

        public bool Remove(int id)
        {
            using DbContext dbContext = new DbContext();
                User item = dbContext.Users.Find(id);
                dbContext.Users.Remove(item);
                dbContext.SaveChangesAsync();
                return true;
        }

        public void Save(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            User temp = dbContext.Users.Find(item.Id);
            if (temp is null)
            {
                Create(item);
            }
            else
            {
                dbContext.Users.Remove(dbContext.Users.Find(item.Id));
                dbContext.Users.Add(item);
            }
            dbContext.SaveChangesAsync();
        }
    }
}
