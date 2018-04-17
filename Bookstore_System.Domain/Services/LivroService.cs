using Bookstore_System.Domain.Entities;
using Bookstore_System.Domain.Interfaces.Repositories;
using Bookstore_System.Domain.Interfaces.Services;

namespace Bookstore_System.Domain.Services
{
    public class LivroService : ServiceBase<LIVRO>, ILivroService
    {
        private ILivroRepository _LivroRepository;

        public LivroService(ILivroRepository LivroRepository) : base(LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }
    }
}
