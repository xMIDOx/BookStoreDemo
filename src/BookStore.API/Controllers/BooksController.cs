using AutoMapper;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IMediator mediator;

        public BooksController(IBookService bookService, IMapper mapper, IMediator mediator)
        {
            _bookService = bookService;
            _mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            //var books = await _bookService.GetBooksAsync();
            var books = await mediator.Send(new GetAllBooksQuery());
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook([FromBody] CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            var created = await _bookService.AddBookAsync(book);

            var result = _mapper.Map<BookDto>(created);
            return CreatedAtAction(nameof(GetBook), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            dto.Id = id;

            var book = _mapper.Map<Book>(dto);
            var updated = await _bookService.UpdateBookAsync(book);

            return Ok(_mapper.Map<BookDto>(updated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}

