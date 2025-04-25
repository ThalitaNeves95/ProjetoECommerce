namespace API_ECommerce.ViewModels
{
    public class ListarClienteViewModel
    {
        // Utilizado para a busca de dados - Get - Back para o Front
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string? Endereco { get; set; }

        public DateOnly? DataCadastro { get; set; }
    }
}
