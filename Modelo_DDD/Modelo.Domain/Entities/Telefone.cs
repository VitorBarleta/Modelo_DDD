namespace Modelo.Domain.Entities
{
    public class Telefone
    {
        public Telefone(string codigoRegiao, string numero)
        {
            AlterarTelefone(codigoRegiao, numero);
        }

        public int Id { get; private set; }
        public string CodigoRegiao { get; private set; }
        public string Numero { get; private set; }

        public void AlterarTelefone(string codigoRegiao, string numero)
        {
            CodigoRegiao = codigoRegiao;
            Numero = numero;
        }
    }
}
