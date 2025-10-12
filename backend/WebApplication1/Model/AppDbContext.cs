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
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.UserFriend)
                .WithMany()
                .HasForeignKey(f => f.FriendId);

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
            // one to many between user and expense
            modelBuilder.Entity<User>()
                .HasMany(e => e.ExpenseList)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            //one to many expense and request
           modelBuilder.Entity<Expense>()
                .HasMany(e => e.ShareRequests)
                .WithOne(e => e.Expense)
                .HasForeignKey(e => e.ExpenseId);
            //many to many user and share request
            modelBuilder.Entity<ShareRequestUser>()
                .HasKey(e => new {e.ShareRequestId, e.UserId});
            modelBuilder.Entity<ShareRequestUser>()
                .HasOne(e => e.User)
                .WithMany(e => e.ShareRequestRecieveList)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<ShareRequestUser>()
                .HasOne(e => e.ShareRequest)
                .WithMany(e => e.ListSharerequestUser)
                .HasForeignKey(e => e.ShareRequestId);
            modelBuilder.Entity<User>()
                .HasMany(e => e.ShareRequestsLists)
                .WithOne(e => e.ShareOwner)
                .HasForeignKey(e => e.UserId);

            //Payment
            modelBuilder.Entity<Payment>()
               .HasOne(p => p.Expense)
               .WithMany(e => e.Payments)
               .HasForeignKey(p => p.ExpenseId);



            modelBuilder.Entity<Payment>()
                .HasOne(p => p.SenderUser)
                .WithMany(u => u.SendPayments)
                .HasForeignKey(p => p.SenderUserId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.ReceiverUser)
                .WithMany(u => u.ReceivePayments)
                .HasForeignKey(p => p.ReceiverUserId);

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember>GroupMembers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ShareRequest> ShareRequests { get; set; }
        public DbSet<ShareRequestUser> ShareRequestUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
