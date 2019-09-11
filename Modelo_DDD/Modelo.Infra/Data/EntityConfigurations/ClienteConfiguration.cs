using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modelo.Domain.Entities;
using System;

namespace Modelo.Infra.Data.EntityConfigurations
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Telefone)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(x => x.TotalProdutosComprados)
                .ValueGeneratedNever()
                .IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
