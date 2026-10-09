namespace LibraryZh.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public bool IsAvailable { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
