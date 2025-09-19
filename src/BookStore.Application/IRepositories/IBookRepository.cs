using BookStore.Domain.Entities;

namespace BookStore.Application.IRepositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> UpdateAsync(Book book);
        Task<Book> AddAsync(Book book);
        Task DeleteAsync(int id);
        Task<Book?> GetByIsbnAsync(string isbn);
    }
}
