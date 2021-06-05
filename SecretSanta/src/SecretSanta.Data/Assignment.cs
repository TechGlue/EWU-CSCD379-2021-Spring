using System;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public int AssignmentID { get; set;}
        public User Giver { get;}
        public User Receiver { get;}
        public String? GiverAndReceiver { get; set; } = "";
        public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));
        }

        public Assignment()
        {
            Giver = new User();
            Receiver = new User();
        }
    }
}
