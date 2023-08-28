using Microsoft.EntityFrameworkCore;

namespace BooksStore.Models
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }


    }
}
