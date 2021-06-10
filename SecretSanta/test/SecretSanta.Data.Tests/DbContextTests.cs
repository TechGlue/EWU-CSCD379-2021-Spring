using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class DbContextTests
    {
        [TestMethod]
        public void GroupDb_AddingGroup_Success()
        {
            using var db = new DbContext();
            Group group = new Group() {GroupId = 412, Name = "Pedro's Diner"};

            int count = db.Groups.Count();
            db.Groups.Add(group);
            db.SaveChanges();
            
            Assert.AreEqual(count+1, db.Groups.Count());
        }

        [TestMethod]
        public void UserDB_AddingUser_Success()
        {
            using DbContext db = new DbContext();
            int count = db.Users.Count();

            db.Users.Add(new User() {UserId = 9, FirstName = "t", LastName = "yagami"});
            db.SaveChanges();
              
            Assert.AreEqual(count+1, db.Users.Count());
        }
    }
}
