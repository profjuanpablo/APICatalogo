using APICatalogo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Data
{
    public class APICatalogContext : IdentityDbContext<ApplicationUser>
    {
        public APICatalogContext(DbContextOptions<APICatalogContext> options)
            : base(options) { }


        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
