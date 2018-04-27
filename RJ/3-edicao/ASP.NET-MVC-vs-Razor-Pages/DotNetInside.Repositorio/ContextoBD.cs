using DotNetInside.Dominio;
using Microsoft.EntityFrameworkCore;

namespace DotNetInside.Repositorio
{
    public class ContextoBd : DbContext
    {
        public ContextoBd(DbContextOptions<ContextoBd> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMap());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
