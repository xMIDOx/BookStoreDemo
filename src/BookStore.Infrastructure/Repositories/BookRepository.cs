using BookStore.Application.IRepositories;
using BookStore.Domain.Entities;
using BookStore.Domain.Exceptions;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext dBContext;

        public BookRepository(BookStoreDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            await dBContext.Books.AddAsync(book);
            await dBContext.SaveChangesAsync();

            return book;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await dBContext.Books.FindAsync(id) ??
                throw new BookNotFoundException(id);

            dBContext.Books.Remove(book);
            await dBContext.SaveChangesAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await dBContext.Books.Include(a => a.Author).Where(b => b.Id == id).FirstOrDefaultAsync() ??
                throw new BookNotFoundException(id);

            return book;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await dBContext.Books.Include(a => a.Author).ToListAsync();
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var bookDB = await dBContext.Books.FindAsync(book.Id) ??
                throw new BookNotFoundException(book.Id);

            bookDB.AuthorId = book.AuthorId;
            bookDB.Title = book.Title;
            bookDB.Price = book.Price;
            bookDB.Summary = book.Summary;
            bookDB.Image = book.Image;
            bookDB.Year = book.Year;

            await dBContext.SaveChangesAsync();
            return bookDB;
        }

        public async Task<Book?> GetByIsbnAsync(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                throw new ArgumentNullException(nameof(isbn));

            return await dBContext.Books.Where(b => b.Isbn == isbn).FirstOrDefaultAsync();
        }
    }
}
