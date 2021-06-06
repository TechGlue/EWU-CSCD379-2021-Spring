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
            using DbContext db = new DbContext();
            Group group = new Group() {Id = 41, Name = "Pedro's pizza"};

            int count = db.Groups.Count();
            Group groupAdded = db.Groups.Add(group).Entity;
            db.SaveChanges();
            
            Assert.AreEqual(count+1, db.Groups.Count());
        }
    }
}
