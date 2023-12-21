using Microsoft.EntityFrameworkCore;
using API_Pessoa.Entities;
using API_Pessoa.Objt;

namespace API_Pessoa.Persistence
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Entry).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
