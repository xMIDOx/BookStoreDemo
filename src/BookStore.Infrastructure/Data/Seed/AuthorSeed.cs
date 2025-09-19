using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Seed
{
    public static class AuthorSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "George",
                    LastName = "Orwell",
                    Bio = "English novelist and essayist, journalist and critic."
                },
                new Author
                {
                    Id = 2,
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    Bio = "British author, best known for the Harry Potter series."
                }
            );
        }
    }
}
