using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBookAsync(int id);
        Task<List<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
