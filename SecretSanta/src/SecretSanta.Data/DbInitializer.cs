using System;
using System.Linq;

namespace SecretSanta.Data
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Gifts.Any())
            {
                return;
            }

            var groups = new Group[]
            {
                new Group{Id = 1, Name = "Stokes birthday group"}
            };
            
            foreach (Group s in groups)
            {
                context.Groups.Add(s);
            }
            context.SaveChanges();
        }
    }
}
