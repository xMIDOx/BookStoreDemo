public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public decimal? Price { get; set; }
    public string AuthorName { get; set; }
    public int AuthorId { get; set; }
    public int? Year { get; set; }
}

public class CreateBookDto
{
    public string Title { get; set; }
    public string Isbn { get; set; }
    public decimal? Price { get; set; }
    public int? Year { get; set; }
    public int AuthorId { get; set; }
}

public class UpdateBookDto : CreateBookDto
{
    public int Id { get; set; }
}
