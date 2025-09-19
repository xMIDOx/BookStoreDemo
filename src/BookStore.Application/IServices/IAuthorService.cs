using BookStore.Domain.Entities;

namespace BookStore.Application.IServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthors();
    }
}
