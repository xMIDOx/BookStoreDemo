using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Seed
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder builder)
        {


            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    ExternalId = "",
                    Email = "Admin@bookstore.com",
                    FirstName = "System",
                    LastName = "Admin",
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    ExternalId = "",
                    Email = "User@bookstore.com",
                    FirstName = "System",
                    LastName = "User",
                    IsActive = true
                }
            );
        }
    }
}
