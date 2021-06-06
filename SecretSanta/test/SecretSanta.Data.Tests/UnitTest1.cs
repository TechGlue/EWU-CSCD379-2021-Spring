using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using DbContext dbContext = new DbContext();
            int countBefore = dbContext.Groups.Count();
            dbContext.Groups.Add(new Group() { Id = 420, Name = "Pedro's party"});
            dbContext.SaveChanges();
            Assert.AreEqual<int>(countBefore + 1, dbContext.Groups.Count());
        }
    }
}
