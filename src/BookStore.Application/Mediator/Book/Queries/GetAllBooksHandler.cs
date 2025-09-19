using AutoMapper;
using BookStore.Application.Interfaces;
using MediatR;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public GetAllBooksHandler(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookService.GetBooksAsync();
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }
}
