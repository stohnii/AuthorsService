using Microsoft.EntityFrameworkCore;
using AuthorsService.DAL.Entities;

namespace AuthorsService.DAL
{
    public class AuthorsDbContext : DbContext
    {
        public AuthorsDbContext(DbContextOptions<AuthorsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
    }
}
