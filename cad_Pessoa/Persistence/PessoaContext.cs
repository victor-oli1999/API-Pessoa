using Microsoft.EntityFrameworkCore;
using API_Pessoa.cad_Pessoa.Entities;

namespace API_Pessoa.cad_Pessoa.Persistence
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .ToTable("cad_Pessoa")
                .HasKey(x => x.IdPessoa);

            base.OnModelCreating(modelBuilder);
        }
    }
}
