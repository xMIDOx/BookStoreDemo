using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Domain.Entities;

namespace BookStore.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : string.Empty))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author != null ? src.Author.Id : 0));

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            // Author mappings
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
        }

    }
}

