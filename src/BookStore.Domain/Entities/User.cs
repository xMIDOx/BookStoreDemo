namespace BookStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? ExternalId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Book> BorrowedBooks { get; set; } = new List<Book>();

    }
}
