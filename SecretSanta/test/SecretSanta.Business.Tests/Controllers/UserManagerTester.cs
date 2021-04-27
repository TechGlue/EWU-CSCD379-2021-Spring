using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Data;
using SecretSanta.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Business.Tests{
    [TestClass]
    public class UserManagerTester{

        [TestMethod]
        public void Create_WithUser_ReturnsUser()
        {
            UserManager manager = new();
            User? newUser = new User(){Id=2, FirstName = "Yocky", LastName = "Slush"};
            User? createdUser = manager.Create(newUser);
            Assert.AreSame(newUser, createdUser);
        }

        [TestMethod]
        public void List_WithUserData_ReturnsListOfUsers()
        {
            UserManager manager = new UserManager();
            IEnumerable<User?> users = manager.List();
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void GetItem_WithValidId_ReturnsUser(int id)
        {
            UserManager manager = new UserManager();
            User? foundUser = manager.GetItem(id);
            Assert.IsNotNull(foundUser);
        }

        [TestMethod]
        [DataRow(666)]
        [DataRow(444)]
        public void GetItem_WithInvalidId_ReturnsUser(int id)
        {
            UserManager manager = new UserManager();
            User? foundUser = manager.GetItem(id);
            Assert.IsNull(foundUser);
        }

        public void Remove_WithValidId_ReturnsTrue(int id)
        {
            UserManager manager = new UserManager();
            bool foundUser = manager.Remove(id);
            Assert.IsTrue(foundUser);
        }

        public void Remove_WithInvalidId_ReturnsFalse(int id)
        {
            UserManager manager = new UserManager();
            bool foundUser = manager.Remove(id);
            Assert.IsFalse(foundUser);
        }

        public void Save_WithUser_CreatesUser()
        {
            UserManager manager = new();
            User? newUser = new User(){Id=2, FirstName = "Yocky", LastName = "Slush"};
            manager.Save(newUser);
            User? savedUser = manager.GetItem(newUser.Id);
            Assert.AreSame(newUser, savedUser);
        }



    }
}