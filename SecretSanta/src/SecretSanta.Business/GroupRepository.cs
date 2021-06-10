using System;
using System.Collections.Generic;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            using DbContext dbContext = new DbContext();
            dbContext.Add<Group>(item);
            foreach (User user in item.Users)
            {
              //  AddToGroup(item.Id, user.Id);
            }
            dbContext.SaveChangesAsync();
            return item;
        }

        public Group? GetItem(int id)
        {
            if (MockData.Groups.TryGetValue(id, out Group? user))
            {
                return user;
            }
            return null;
        }

        public ICollection<Group> List()
        {
            using DbContext dbContext = new DbContext();
            List<Group> groupList = new List<Group>();
            foreach (var group in dbContext.Groups)
            {
                groupList.Add(group);
            }
            return groupList;
        }

        public bool Remove(int id)
        {
            using DbContext dbContext = new DbContext();
                Group item = dbContext.Groups.Find(id);
                dbContext.Groups.Remove(item);
                dbContext.SaveChangesAsync();
                return true;
        }

        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            using DbContext dbContext = new DbContext();

            Group temp = dbContext.Groups.Find(item.GroupId);
            if (temp is null)
            {
                Create(item);
            }
            else
            {
                dbContext.Groups.Remove(dbContext.Groups.Find(item.GroupId));
                Create(item);
            }
            dbContext.SaveChangesAsync();
        }

        public AssignmentResult GenerateAssignments(int groupId)
        {
            Assignment assignment;
            using DbContext dbContext = new DbContext();

            Group group = GetItem(groupId)!;
            if (group is null)
            {
                return AssignmentResult.Error("Group not found");
            }

            Random random = new();
            var groupUsers = new List<User>(group.Users);

            if (groupUsers.Count < 3)
            {
                return AssignmentResult.Error($"Group {group.Name} must have at least three users");
            }

            var users = new List<User>();
            //Put the users in a random order
            while(groupUsers.Count > 0)
            {
                int index = random.Next(groupUsers.Count);
                users.Add(groupUsers[index]);
                groupUsers.RemoveAt(index);
            }

            //The assignments are created by linking the current user to the next user.
            group.Assignments.Clear();
            for(int i = 0; i < users.Count; i++)
            {
                int endIndex = (i + 1) % users.Count;
                group.Assignments.Add(new Assignment(users[i], users[endIndex]));
            }
            return AssignmentResult.Success();
        }
    }
}
