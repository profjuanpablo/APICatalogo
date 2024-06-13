using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Data
{
    public class APICatalogContext : DbContext
    {
        public APICatalogContext(DbContextOptions<APICatalogContext> options)
            : base(options) { }


        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
