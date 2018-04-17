using Bookstore_System.Domain.Entities;
using Bookstore_System.Domain.Interfaces.Repositories;

namespace Bookstore_System.Infrastructure.Data.Repositories
{
    public class LivroRepository : RepositoryBase<LIVRO>, ILivroRepository
    {
    }
}
