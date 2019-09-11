using System;

namespace Modelo.Domain.Entities
{
    public class Produto
    {
        private Produto() { }

        public Produto(string nome, double valor, string marca)
        {
            Nome = nome;
            Valor = valor;
            Marca = marca;
            DataCadastro = DateTime.UtcNow;
        }

        public Produto(string nome, double valor, string marca, DateTime dataFabricacao)
        {
            Nome = nome;
            Valor = valor;
            Marca = marca;
            DataCadastro = DateTime.UtcNow;
            DataFabricacao = dataFabricacao;
        }

        public int Id { get; private set; }
        public int? CarrinhoId { get; private set; }
        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public string Marca { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        public void AdicionarNoCarrinho(int carrinhoId)
        {
            CarrinhoId = carrinhoId;
        }

        public void RemoverDoCarrinho()
        {
            CarrinhoId = null;
        }

        public bool AlterarValor(double newValor)
        {
            if ((DataCadastro.Add(TimeSpan.FromDays(2)) - DateTime.UtcNow) > TimeSpan.FromDays(-1))
            {
                Valor = newValor;
                DataAlteracao = DateTime.UtcNow;

                return true;
            }

            return false;
        }
    }
}
