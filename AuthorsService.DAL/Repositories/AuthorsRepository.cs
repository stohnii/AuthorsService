using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AuthorsService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsService.DAL.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly AuthorsDbContext _context;

        public AuthorsRepository(AuthorsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync(bool onlyActive = true)
        {
            try
            {
                return await _context.Authors
                    .Where(a => onlyActive ? a.IsActive : true)
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<EntityEntry<Author>> AddAsync(Author author)
        {
            return await _context.Authors.AddAsync(author);
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.IsActive = author.IsActive;

            return existingAuthor;
        }
    }
}
