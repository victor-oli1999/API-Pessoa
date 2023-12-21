using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using API_Pessoa.cad_Cliente.Entities;

namespace API_Pessoa.Entities_Config
{
    internal class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cad_Cliente")
                .HasKey(x => x.IdCliente);

            builder.Property(x => x.IdCliente)
                .HasColumnName("IdPessoa")
                .IsRequired(true);

            builder.Property(x => x.IdFuncionario_Responsavel)
                .HasColumnName("IdFuncionario_Responsavel")
                .IsRequired(false);

            builder.Property(x => x.IdVendedor_Responsavel)
                .HasColumnName("IdVendedor_Responsavel")
                .IsRequired(false);

            builder.Property(x => x.Tipo_Cliente)
                .HasColumnName("Tipo_Cliente")
                .IsRequired(true);

            builder.Property(x => x.Cliente_)
                .HasColumnName("Cliente")
                .IsRequired(true);

            builder.Property(x => x.Importador_)
                .HasColumnName("Importador")
                .IsRequired(true);

            builder.Property(x => x.Exportador_)
                .HasColumnName("Exportador")
                .IsRequired(true);
        }
    }
}
