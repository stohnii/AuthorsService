using Microsoft.EntityFrameworkCore.ChangeTracking;
using AuthorsService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsService.DAL.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
        Task<EntityEntry<Author>> AddAsync(Author author);
        Task<IEnumerable<Author>> GetAllAsync(bool onlyActive = true);
    }
}
