using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.EntityConfigurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Marca)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
