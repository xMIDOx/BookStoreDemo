using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Seed
{
    public static class BookSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "1984",
                    Year = 1949,
                    Isbn = "1234567890123",
                    Summary = "A dystopian novel about totalitarianism.",
                    Price = 9.99m,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Year = 1997,
                    Isbn = "9876543210123",
                    Summary = "The first book in the Harry Potter series.",
                    Price = 14.99m,
                    AuthorId = 2
                }
            );
        }
    }
}
