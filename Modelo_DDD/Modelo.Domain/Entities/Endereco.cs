namespace Modelo.Domain.Entities
{
    public class Endereco
    {
        private Endereco() { }
        public Endereco(string estado, string cidade, string rua, int numero, string cep)
        {
            AlterarEndereco(estado, cidade, rua, numero, cep);
        }

        public int Id { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string CEP { get; private set; }

        public void AlterarEndereco(string estado, string cidade, string rua, int numero, string cep)
        {
            Estado = estado;
            Cidade = cidade;
            Rua = rua;
            Numero = numero;
            CEP = cep;
        }
    }
}
