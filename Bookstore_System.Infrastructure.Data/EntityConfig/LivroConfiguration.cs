using Bookstore_System.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Bookstore_System.Infrastructure.Data.EntityConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<LIVRO>
    {

        public LivroConfiguration()
        {
            Property(e => e.NOME)
            .IsUnicode(false);

            Property(e => e.AUTOR)
                .IsUnicode(false);

            Property(e => e.EDITORA)
                .IsUnicode(false);
        }
    }
}
