namespace API_ECommerce.DTO
{
    // Eu recebo os dados do pedido
    // E recebo os produtos comprados (ID)
    public class CadastrarPedidoDto
    {
        public DateOnly DataPedido { get; set; }

        public string StatusPedido { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int? IdCliente { get; set; }

        // Produtos Comprados - Uma lista de produtos
        public List<int> Produtos { get; set; }
    }
}
