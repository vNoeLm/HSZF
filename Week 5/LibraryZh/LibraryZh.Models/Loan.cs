using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryZh.Models;

public class Loan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int BookId { get; set; }

    public string BorrowerName { get; set; } = string.Empty;

    public DateTime BorrowedAt { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public virtual Book? Book { get; set; }
}
