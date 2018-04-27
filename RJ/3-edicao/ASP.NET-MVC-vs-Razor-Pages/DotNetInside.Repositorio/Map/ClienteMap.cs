using DotNetInside.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetInside.Repositorio
{
    public class ClienteMap: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Nome).HasColumnName("nome").HasMaxLength(60).IsRequired();
            builder.Property(u => u.Telefone).HasColumnName("telefone").HasMaxLength(20);
            builder.Property(u => u.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
