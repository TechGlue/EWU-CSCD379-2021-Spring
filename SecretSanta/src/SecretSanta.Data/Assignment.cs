﻿using System;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int AssignmentID { get; set;}
        public User Giver { get; set; }
        public User Receiver { get; set; }
        public String? GiverAndReceiver { get; set; } = "";
        public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));

            GiverAndReceiver = Giver.FirstName +" "+ Receiver.FirstName;
        }

        public Assignment()
        {
            Giver = new User();
            Receiver = new User();
        }
    }
}
