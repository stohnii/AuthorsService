using AuthorsService.DAL.Repositories;
using System.Threading.Tasks;

namespace AuthorsService.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthorsDbContext _context;
        private IAuthorsRepository _authorsRepository;

        public UnitOfWork(AuthorsDbContext context)
        {
            _context = context;
        }

        public IAuthorsRepository AuthorsRepository 
        { 
            get 
            { 
                return _authorsRepository ?? new AuthorsRepository(_context); 
            } 
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Rollback()
        {
            await _context.DisposeAsync();
        }
    }
}
