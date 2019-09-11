using System;

namespace Modelo.Domain.Entities
{
    public class Cliente
    {
        private Cliente() { }

        public Cliente(string nome, string email, string cpf, Telefone telefone, Endereco endereco) : base()
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
            DataCadastro = DateTime.UtcNow;
            Especial = false;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public virtual Telefone Telefone { get; private set; }
        public int TelefoneId { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }
        public bool Especial { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public int TotalProdutosComprados { get; private set; }

        public void AlterarEndereco(Endereco newEdereco)
        {
            Endereco = newEdereco;
            DataAlteracao = DateTime.UtcNow;
        }

        public void AlterarTelefone(Telefone newTelefone)
        {
            Telefone = newTelefone;
            DataAlteracao = DateTime.UtcNow;
        }

        public void AlterarEmail(string newEmail)
        {
            Email = newEmail;
            DataAlteracao = DateTime.UtcNow;
        }

        public bool ClienteEspecial()
        {
            if (TotalProdutosComprados > 9)
                return true;

            return false;
        }
    }
}
