using System;
using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;

namespace SecretSanta.Business
{
    public class UserManager : IUserRepository
    {
        public User Create(User item){
            UserBase.Users.Add(item);
            return item;
        }

        public ICollection<User> List(){
            return UserBase.Users;
        }

        public User? GetItem(int id){
            if(id < 0){
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return UserBase.Users.FirstOrDefault(x => x.Id == id);
        }
        public bool Remove(int id){
            User? foundUser = UserBase.Users.FirstOrDefault(x => x.Id == id);

            if(foundUser is not null){
                UserBase.Users.Remove(foundUser);
                return true;
            }
            return false;
        }
    
        public void Save(User item){
            Remove(item.Id);
            Create(item);
        }
    }
}