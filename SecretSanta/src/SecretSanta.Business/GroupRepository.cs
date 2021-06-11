using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;
using DbContext = SecretSanta.Data.DbContext;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        private DbContext Context { get; }
        public GroupRepository(DbContext dbContext)
            => Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        
        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.Groups.Add(item);
            Context.SaveChanges();
            return item;
        }


        public Group? GetItem(int id)
            => List().FirstOrDefault<Group>(i => i.GroupId == id);

        public ICollection<Group> List()
            => Context.Groups
                .Include(group => group.Users)
                .Include(group => group.Assignments)
                .ToList();

        public bool Remove(int id)
        {
            Group item = Context.Groups.Find(id);
            Context.Groups.Remove(item);
            Context.SaveChanges();
            return true;
        }

        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.Groups.Update(item);
            Context.SaveChanges();
        }

        public AssignmentResult GenerateAssignments(int groupId)
        {

            Group? @group = GetItem(groupId);
            
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
                group.Assignments.Add(new Assignment(){GroupId = group.GroupId, Giver = users[i], Receiver =  users[endIndex]});
            }
            Save(group);
            return AssignmentResult.Success();
        }
    }
}
