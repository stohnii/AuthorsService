using AuthorsService.DAL.Repositories;
using System.Threading.Tasks;

namespace AuthorsService.DAL
{
    public interface IUnitOfWork
    {
        IAuthorsRepository AuthorsRepository { get; }
        Task Commit();
        Task Rollback();
    }
}
