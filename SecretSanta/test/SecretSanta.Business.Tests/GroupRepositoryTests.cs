using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Data;
using DbContext = SecretSanta.Data.DbContext;


namespace SecretSanta.Business.Tests
{
    [TestClass]
    public class GroupRepositoryTests
    {
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_NullItem_ThrowsArgumentException()
        {
            using DbContext context = new DbContext();
            GroupRepository sut = new(context);

            sut.Create(null!);
        }

        [TestMethod]
        public async Task Create_WithItem_CanGetItem()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            Group user = new()
            {
                GroupId = 42
            };

            Group createdGroup = sut.Create(user);

            Group? retrievedGroup = sut.GetItem(createdGroup.GroupId);
            Assert.AreEqual(user, retrievedGroup);
        }

        [TestMethod]
        public void GetItem_WithBadId_ReturnsNull()
        {
            
            using var context = new DbContext();
            GroupRepository sut = new (context);

            Group? user = sut.GetItem(-1);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetItem_WithValidId_ReturnsGroup()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            sut.Create(new() 
            { 
                GroupId = 423,
                Name = "Group",
            });

            Group? user = sut.GetItem(42);

            Assert.AreEqual(42, user?.GroupId);
            Assert.AreEqual("Group", user!.Name);
        }

        [TestMethod]
        public void List_WithGroups_ReturnsAllGroup()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            sut.Create(new()
            {
                GroupId = 422,
                Name = "Group",
            });

            ICollection<Group> users = sut.List();

            Assert.AreEqual(context.Groups.Count(), users.Count);
            foreach(var mockGroup in context.Groups)
            {
                Assert.IsNotNull(users.SingleOrDefault(x => x.Name == mockGroup.Name));
            }
        }

        [TestMethod]
        [DataRow(-1, false)]
        [DataRow(42, true)]
        public void Remove_WithInvalidId_ReturnsTrue(int id, bool expected)
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            sut.Create(new()
            {
                GroupId = 4322,
                Name = "Group"
            });

            Assert.AreEqual(expected, sut.Remove(id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_NullItem_ThrowsArgumentException()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            sut.Save(null!);
        }

        [TestMethod]
        public void Save_WithValidItem_SavesItem()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);

            sut.Save(new Group() { GroupId = 42 });

            Assert.AreEqual(42, sut.GetItem(42)?.GroupId);
        }

        [TestMethod]
        public void GenerateAssignments_WithInvalidId_ReturnsError()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);

            AssignmentResult result = sut.GenerateAssignments(42);

            Assert.AreEqual("Group not found", result.ErrorMessage);
        }

        [TestMethod]
        public void GenerateAssignments_WithLessThanThreeUsers_ReturnsError()
        {
            using var context = new DbContext();
            GroupRepository sut = new(context);
            sut.Create(new()
            {
                GroupId = 42,
                Name = "Group"
            });

            AssignmentResult result = sut.GenerateAssignments(42);

            Assert.AreEqual($"Group Group must have at least three users", result.ErrorMessage);
        }

        [TestMethod]
        public void GenerateAssignments_WithValidGroup_CreatesAssignments()
        {
            using var context = new DbContext();
            GroupRepository sut = new (context);
            Group group = sut.Create(new()
            {
                GroupId = 42,
                Name = "Group"
            });
            group.Users.Add(new User { FirstName = "John", LastName = "Doe" });
            group.Users.Add(new User { FirstName = "Jane", LastName = "Smith" });
            group.Users.Add(new User { FirstName = "Bob", LastName = "Jones" });

            AssignmentResult result = sut.GenerateAssignments(42);

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(3, group.Assignments.Count);
            Assert.AreEqual(3, group.Assignments.Select(x => x.Giver.FirstName).Distinct().Count());
            Assert.AreEqual(3, group.Assignments.Select(x => x.Receiver.FirstName).Distinct().Count());
            Assert.IsFalse(group.Assignments.Any(x => x.Giver.FirstName == x.Receiver.FirstName));
        }
    }
}
