using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.EntityConfigurations
{
    public class CarrinhoConfiguration : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
