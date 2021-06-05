using System;
using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Gift
    {
        public int GiftId { get; set;}
        public String? Title { get; set; } = "";
        public String? Description { get; set; } = "";
        public String? URL { get; set; } = "";
        public int Priority { get; set;}
        public int UserId { get; set;}
    }
}
