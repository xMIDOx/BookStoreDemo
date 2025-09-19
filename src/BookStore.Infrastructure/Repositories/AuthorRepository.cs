using BookStore.Application.IRepositories;
using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthoryRepository : IAuthorRepository
    {
        private readonly BookStoreDBContext dBContext;

        public AuthoryRepository(BookStoreDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Author> AddAsync(Author author)
        {
            await dBContext.Authors.AddAsync(author);
            await dBContext.SaveChangesAsync();

            return author;
        }

        public async Task DeleteAsync(int id)
        {
            var author = await dBContext.Authors.FindAsync(id) ??
                throw new AuthorNotFoundException(id);

            dBContext.Authors.Remove(author);
            await dBContext.SaveChangesAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await dBContext.Authors.FindAsync(id) ??
                throw new AuthorNotFoundException(id);

            return author;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await dBContext.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            var authorDB = await dBContext.Authors.FindAsync(author.Id) ??
                throw new AuthorNotFoundException(author.Id);

            authorDB.FirstName = author.FirstName;
            authorDB.LastName = author.LastName;
            authorDB.Bio = author.Bio;

            await dBContext.SaveChangesAsync();
        }
    }
}
