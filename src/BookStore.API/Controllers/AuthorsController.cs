using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetBooks()
        {
            var authors = await _authorService.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

    }
}
