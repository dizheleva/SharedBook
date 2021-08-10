﻿namespace SharedBook.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Models;
    using System.Linq;

    public class SharedBookDbContext : IdentityDbContext
    {
        public SharedBookDbContext(DbContextOptions<SharedBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Book> Books { get; init; }

        public DbSet<Address> Locations { get; init; }
        
        public DbSet<Reservation> Reservations { get; init; }

        public DbSet<BookSharing> SharedBooks { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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

            foreach (IMutableForeignKey relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);
        }
    }
}