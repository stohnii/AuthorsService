using AuthorsService.BAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorsService.BAL
{
    public interface IAuthorsManager
    {
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorDto> AddOrUpdateAsync(AuthorDto author);
        Task<IEnumerable<AuthorDto>> GetAllAsync(bool onlyActive = true);
    }
}
