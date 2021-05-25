﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        private Random rng = new Random();
        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
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
            return MockData.Groups.Values;
        }

        public bool Remove(int id)
        {
            return MockData.Groups.Remove(id);
        }

        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
        }

        public AssignmentResult GenerateAssignments(int id)
        {
            Group group = GetItem(id);

            if (group is null)
            {
                throw new NullReferenceException();
            }
            if (group.Users.Count < 3)
            {
                return AssignmentResult.Error("Sorry, there are not enough members in the group.");
            }
            //begin randomizing.
            group.Assignments.Clear();

            List<User> randomizedReceiverList = group.Users;
            Console.WriteLine("The following number of users are in the count:" + randomizedReceiverList.Count);
            
            Shuffle(randomizedReceiverList);

            //Distributing users technique with randomized list from my review partner pedro.
            for (int i = 0; i < group.Users.Count; i++)
            {
                MockData.Groups[id].Assignments.Add(i < randomizedReceiverList.Count - 1
                    ? new Assignment(randomizedReceiverList[i], randomizedReceiverList[i + 1])
                    : new Assignment(randomizedReceiverList[i], randomizedReceiverList[0]));
            }
            Console.WriteLine(group.Assignments[0].Receiver.FirstName);
            Console.WriteLine("The number of assignments: " + group.Assignments.Count);
            return AssignmentResult.Success();
        }

        //list shuffling method from stack overflow
        //source - https://stackoverflow.com/questions/273313/randomize-a-listt
        private void Shuffle<T>(IList<T> list)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }
          
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
