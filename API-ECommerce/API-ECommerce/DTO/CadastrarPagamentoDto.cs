namespace API_ECommerce.DTO
{
    public class CadastrarPagamentoDto
    {
        public string FormaPagamento { get; set; } = null!;

        public string StatusPagamento { get; set; } = null!;

        public int IdPedido { get; set; }
    }
}
