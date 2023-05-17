using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {

                entity.HasKey(c => c.Id);

                entity.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(c => c.Email)
                 .IsRequired()
                 .HasMaxLength(255);


                entity.HasMany(entity => entity.BookList);

            });
            modelBuilder.Entity<Book>(entity =>
            {

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(c => c.Cover)
                .IsRequired()
                .HasMaxLength(255);

                entity.Property(c => c.Category)
                 .IsRequired()
                 .HasMaxLength(255);

                entity.Property(c => c.DatePublication)
                .IsRequired()
                .HasMaxLength(255);

                entity.HasOne(entity => entity.Author);

            });
        }
    }
}