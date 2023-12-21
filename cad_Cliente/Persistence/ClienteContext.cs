using Microsoft.EntityFrameworkCore;
using API_Pessoa.cad_Cliente.Entities;
using API_Pessoa.cad_Cliente.Objt;

namespace API_Pessoa.cad_Cliente.Persistence
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
