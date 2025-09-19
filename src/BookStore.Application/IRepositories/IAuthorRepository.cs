using BookStore.Domain.Entities;

namespace BookStore.Application.IRepositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task UpdateAsync(Author Author);
        Task<Author> AddAsync(Author book);
        Task DeleteAsync(int id);
    }
}
