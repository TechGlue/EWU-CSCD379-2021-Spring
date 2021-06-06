using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DbContext = SecretSanta.Data.DbContext;

namespace SecretSanta.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext()
            : base(new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=main.db").Options)
        { }

        public DbSet<Group> Groups => Set<Group>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Gift> Gifts => Set<Gift>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<User>()
                .HasAlternateKey(user => new { user.FirstName, user.LastName});
            modelBuilder.Entity<Gift>()
                .HasAlternateKey(gift => new {gift.Title, gift.UserId});
            modelBuilder.Entity<Group>()
                .HasAlternateKey(group => new {group.Name});
            modelBuilder.Entity<Assignment>()
                .HasAlternateKey(assignment => new {assignment.GiverAndReceiver});
        }
    }
}
