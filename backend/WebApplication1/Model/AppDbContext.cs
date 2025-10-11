using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relationship setup many to many between user and user
            modelBuilder.Entity<Friend>()
                .HasKey(f => new { f.UserId, f.FriendId });
            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User)
                .WithMany(f => f.FriendList)
                .HasForeignKey(f => f.FriendId);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.UserFriend)
                .WithMany()
                .HasForeignKey(f => f.UserId);

            //relationship setup for many to many between user and group
            modelBuilder.Entity<GroupMember>()
                .HasKey(k => new
                {
                    k.GroupId,
                    k.MemberId
                });
            modelBuilder.Entity<GroupMember>()
                .HasOne(g => g.Group)
                .WithMany(m => m.MemberList)
                .HasForeignKey(f => f.GroupId);
            modelBuilder.Entity<GroupMember>()
                .HasOne(m => m.Member)
                .WithMany(g => g.GroupList)
                .HasForeignKey(f => f.MemberId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ExpenseList)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            
                
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember>GroupMembers { get; set; }
    }
}
