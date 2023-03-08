using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            var seedData = new LibraryContextSeedData(this);
            seedData.SeedData();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Ratings)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}