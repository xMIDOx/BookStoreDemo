using BookStore.Application.IRepositories;
using BookStore.Application.IServices;
using BookStore.Domain.Entities;

namespace BookStore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await authorRepository.GetAllAsync();
        }
    }
}
