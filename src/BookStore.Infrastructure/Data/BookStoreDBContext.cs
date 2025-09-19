using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDBContext).Assembly);

            UserSeed.Seed(modelBuilder);
            AuthorSeed.Seed(modelBuilder);
            BookSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
