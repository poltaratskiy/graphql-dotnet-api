using GraphQLvsRest.Data.Dto;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace GraphQLvsRest.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
