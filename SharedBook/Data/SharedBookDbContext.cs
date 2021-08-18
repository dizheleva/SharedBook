namespace SharedBook.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SharedBookDbContext : IdentityDbContext<User>
    {
        public SharedBookDbContext(DbContextOptions<SharedBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Book> Books { get; init; }

        public DbSet<BookShare> BookShares { get; init; }

        public DbSet<Reservation> Reservations { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>()
                .HasOne(o => o.Owner)
                .WithMany(b => b.OwnedBooks)
                .HasForeignKey(o => o.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Reservation>(reservation =>
                {
                    reservation
                        .HasOne(b => b.Book)
                        .WithMany(r => r.Reservations)
                        .HasForeignKey(s => s.BookId)
                        .OnDelete(DeleteBehavior.Restrict);

                    reservation
                        .HasOne(s => s.Sender)
                        .WithMany(r => r.SentReservationRequests)
                        .HasForeignKey(s => s.SenderId)
                        .OnDelete(DeleteBehavior.Restrict);

                    reservation
                        .HasOne(s => s.Receiver)
                        .WithMany(r => r.ReceivedReservationRequests)
                        .HasForeignKey(s => s.ReceiverId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<BookShare>(share =>
                {
                    share
                        .HasOne(s => s.Book)
                        .WithMany(r => r.Shares)
                        .HasForeignKey(s => s.BookId)
                        .OnDelete(DeleteBehavior.Restrict);

                    share
                        .HasOne(s => s.Borrower)
                        .WithMany(r => r.BorrowedBooks)
                        .HasForeignKey(s => s.BorrowerId)
                        .OnDelete(DeleteBehavior.Restrict);

                    share
                        .HasOne(s => s.Owner)
                        .WithMany(r => r.SharedBooks)
                        .HasForeignKey(s => s.OwnerId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
