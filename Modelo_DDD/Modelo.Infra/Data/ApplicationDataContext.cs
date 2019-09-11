using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.EntityConfigurations;

namespace Modelo.Infra.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarrinhoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        }
    }
}
