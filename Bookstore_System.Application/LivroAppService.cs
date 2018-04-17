using Bookstore_System.Application.Interface;
using Bookstore_System.Domain.Entities;
using Bookstore_System.Domain.Interfaces.Services;

namespace Bookstore_System.Application
{
    public class LivroAppService : AppServiceBase<LIVRO>, ILivroAppService
    {
        private readonly ILivroService _LivroService;

        public LivroAppService(ILivroService LivroService) : base(LivroService)
        {
            _LivroService = LivroService;
        }
    }
}
