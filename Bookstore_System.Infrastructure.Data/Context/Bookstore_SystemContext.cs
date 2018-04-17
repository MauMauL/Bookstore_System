using Bookstore_System.Domain.Entities;
using Bookstore_System.Infrastructure.Data.EntityConfig;
using System.Data.Entity;

namespace Bookstore_System.Infrastructure.Data
{
    public partial class Bookstore_SystemContext : DbContext
    {
        public Bookstore_SystemContext()
            : base("name=Bookstore_SystemConnectionString")
        {
        }

        public virtual DbSet<LIVRO> LIVRO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LivroConfiguration());
        }
    }
}
