using System.Collections.Generic;
using System.Linq;

namespace Modelo.Domain.Entities
{
    public class Carrinho
    {
        public Carrinho(int clienteId)
        {
            ClienteId = clienteId;
        }

        public int Id { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public int ClienteId { get; private set; }
        public virtual List<Produto> Produtos { get; private set; }
        public int Quantidade { get; set; }
    }
}
