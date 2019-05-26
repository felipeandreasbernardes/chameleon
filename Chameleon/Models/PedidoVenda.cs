using System;

namespace Chameleon.Models
{
    public class PedidoVenda
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string FormaPagamento { get; set; }
    }
}
