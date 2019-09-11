using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;

namespace Modelo.Infra.Data.EntityConfigurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Rua)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasKey(x => x.Id);
        }
    }
}
