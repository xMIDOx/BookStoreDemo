using MediatR;

public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;
