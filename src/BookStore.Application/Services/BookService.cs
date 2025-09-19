using BookStore.Application.Interfaces;
using BookStore.Application.IRepositories;
using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IDiscountStrategy _discountStrategy;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IDiscountStrategy discountStrategy)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _discountStrategy = discountStrategy;
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var existing = await _bookRepository.GetByIsbnAsync(book.Isbn);

            if (existing != null)
                throw new ArgumentException($"Book with ISBN {book.Isbn} already exists.");

            var author = await _authorRepository.GetByIdAsync(book.AuthorId ?? 0)
                         ?? throw new AuthorNotFoundException(book.AuthorId ?? 0);

            if (book.Year < 1450 || book.Year > DateTime.UtcNow.Year)
                throw new ArgumentException("Year must be between 1450 (printing press) and current year.");

            if (book.Price < 0)
                throw new ArgumentException("Price cannot be negative.");

            book.Price = _discountStrategy.ApplyDiscount(book.Price ?? 0);

            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book.BorrowerId != null && book.BorrowerId != 0)
                throw new InvalidOperationException("Book has borrower");

            await _bookRepository.DeleteAsync(id);
        }
    }
}
