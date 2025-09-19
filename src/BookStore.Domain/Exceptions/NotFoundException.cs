namespace BookStore.Domain.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int bookId) : base($"Bookk with id {bookId} was not found.") { }
    }

    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(int bookId) : base($"Author with id {bookId} was not found.") { }
    }

}
