using System.Text;

using LibraryZh.Models;

using Microsoft.EntityFrameworkCore;

namespace LibraryZh.Repository;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public LibraryDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity => {
            entity.HasKey(book => book.Id);
            entity.Property(book => book.Title);
            entity.Property(book => book.Author);
            entity.Property(book => book.PublishedYear);
            entity.Property(book => book.IsAvailable);
        });

        modelBuilder.Entity<Loan>(entity => {
            entity.HasKey(loan => loan.Id);
            entity.Property(loan => loan.BorrowerName);
            entity.Property(loan => loan.BorrowedAt);
            entity.Property(loan => loan.ReturnedAt);
 
        });
    }
}
