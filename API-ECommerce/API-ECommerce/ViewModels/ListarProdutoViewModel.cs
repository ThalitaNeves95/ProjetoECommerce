namespace API_ECommerce.ViewModels
{
    public class ListarProdutoViewModel
    {
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; } = null!;
    }
}
