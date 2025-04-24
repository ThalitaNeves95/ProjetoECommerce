namespace API_ECommerce.DTO
{
    public class CadastrarClienteDto
    {
        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string? Endereco { get; set; }

        public DateOnly? DataCadastro { get; set; }
    }
}
