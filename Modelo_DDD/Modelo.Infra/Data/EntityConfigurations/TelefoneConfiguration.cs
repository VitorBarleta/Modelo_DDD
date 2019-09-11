using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.EntityConfigurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.Property(x => x.CodigoRegiao)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasKey(x => x.Id);
        }
    }
}
