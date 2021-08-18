namespace SharedBook.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Models;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;

    public class SharedBookDbContext : IdentityDbContext
    {
        public SharedBookDbContext(DbContextOptions<SharedBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Book> Books { get; init; }

        public DbSet<BookShare> BookShares { get; init; }

        public DbSet<Borrower> Borrowers { get; init; }

        public DbSet<Reservation> Reservations { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Borrower>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Borrower>(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // builder
            //     .Entity<Address>()
            //     .HasOne<IdentityUser>()
            //     .WithOne()
            //     .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Book>()
                .HasOne(o => o.Owner)
                .WithMany(b => b.OwnedBooks)
                .HasForeignKey(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Reservation>()
                .HasOne(s => s.Book)
                .WithMany(r => r.Reservations)
                .HasForeignKey(s => s.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Reservation>()
                .HasOne(s => s.Sender)
                .WithMany(r => r.SentReservationRequests)
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Reservation>()
                .HasOne(s => s.Receiver)
                .WithMany(r => r.ReceivedReservationRequests)
                .HasForeignKey(s => s.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BookShare>()
                .HasOne(s => s.Book)
                .WithMany(r => r.Shares)
                .HasForeignKey(s => s.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BookShare>()
                .HasOne(s => s.Borrower)
                .WithMany(r => r.BorrowedBooks)
                .HasForeignKey(s => s.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BookShare>()
                .HasOne(s => s.Owner)
                .WithMany(r => r.SharedBooks)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            foreach (IMutableForeignKey relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }
    }
}
