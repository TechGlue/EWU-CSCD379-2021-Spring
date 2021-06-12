using System;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private bool created = false;
        public DbContext()
            : base(new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=main.db").Options)
        {
        }

        public DbSet<Group> Groups => Set<Group>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Gift> Gifts => Set<Gift>();
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            modelBuilder.Entity<Gift>().ToTable("Gift");
            
            modelBuilder.Entity<User>().HasKey(u => new {u.UserId});
            modelBuilder.Entity<Group>().HasKey(g => new {g.GroupId});
            modelBuilder.Entity<Assignment>().HasKey(a => new {a.AssignmentID});
            modelBuilder.Entity<Gift>().HasKey(g => new {g.Id});

            //setting up alternate keys messing up the edits page. 
            // modelBuilder.Entity<Gift>()
            //      .HasAlternateKey(gift => new {gift.Title, gift.UserId});
            // modelBuilder.Entity<Group>()
            //     .HasAlternateKey(group => new {group.Name});
            // modelBuilder.Entity<Assignment>()
            //     .HasAlternateKey(assignment => new {assignment.GiverAndReceiver});

            modelBuilder.Entity<User>().HasData(DbInitializer.Users());
            modelBuilder.Entity<Group>().HasData(DbInitializer.Groups());
        }
    }
}
