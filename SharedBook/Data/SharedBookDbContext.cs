namespace SharedBook.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SharedBookDbContext : IdentityDbContext
    {
        public SharedBookDbContext(DbContextOptions<SharedBookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; init; }
        public DbSet<Category> Categories { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>()
                .HasOne(c => c.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(c => c.Category)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
