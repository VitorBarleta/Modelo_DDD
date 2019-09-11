using Modelo.Domain.Entities;
using Modelo.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Infra.Setup.Seed
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDataContext context)
        {
            var produto = new List<Produto> {
                new Produto("Televisor", 2599.90, "Samsung"),
                new Produto("Notebook", 1899.5, "LG")
            };

            var endereco = new List<Endereco>()
            {
                new Endereco("São Paulo", "Matão", "Rua XV de Novembro", 1368, "15990.060"),
                new Endereco("São Paulo", "Taquaritinga", "Não sei", 0, "14000.000")
            };

            var telefone = new List<Telefone>()
            {
                new Telefone("16", "99999-9999"),
                new Telefone("11", "1111-1111")
            };

            var cliente = new List<Cliente>()
            {
                new Cliente("Vitor", "email@email.com", "111.111.111-11", telefone[0], endereco[0]),
                new Cliente("Neiiva", "neiiva@doceu.com", "999.999.999-99", telefone[1], endereco[1])
            };

            var carrinho = new List<Carrinho>()
            {
                new Carrinho(cliente[0].Id),
                new Carrinho(cliente[1].Id)
            };

            SeedProduto(produto, context);
            SeedEndereco(endereco, context);
            SeedTelefone(telefone, context);
            SeedCliente(cliente, context);
            SeedCarrinho(carrinho, context);

            context.SaveChanges();

        }

        private static void SeedProduto(List<Produto> produtos, ApplicationDataContext context)
        {
            if(!context.Produto.Any() && produtos.Count > 0)
            {
                foreach(var produto in produtos)
                {
                    context.Produto.Add(produto);
                }
            }
        }

        private static void SeedEndereco(List<Endereco> enderecos, ApplicationDataContext context)
        {
            if(!context.Endereco.Any() && enderecos.Count > 0)
            {
                foreach(var endereco in enderecos)
                {
                    context.Endereco.Add(endereco);
                }
            }
        }

        private static void SeedTelefone(List<Telefone> telefones, ApplicationDataContext context)
        {
            if(!context.Telefone.Any() && telefones.Count > 0)
            {
                foreach(var telefone in telefones)
                {
                    context.Telefone.Add(telefone);
                }
            }
        }

        private static void SeedCliente(List<Cliente> clientes, ApplicationDataContext context)
        {
            if(!context.Cliente.Any() && clientes.Count > 0)
            {
                foreach(var cliente in clientes)
                {
                    context.Cliente.Add(cliente);
                }
            }
        }

        private static void SeedCarrinho(List<Carrinho> carrinhos, ApplicationDataContext context)
        {
            if(!context.Carrinho.Any() && carrinhos.Count > 0)
            {
                foreach(var carrinho in carrinhos)
                {
                    context.Carrinho.Add(carrinho);
                }
            }
        }
    }
}
