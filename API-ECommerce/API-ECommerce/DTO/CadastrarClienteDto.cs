namespace API_ECommerce.DTO
{
    public class CadastrarClienteDto
    {
        // É utilizado em casos de cadastrar e editar - Front para o Back
        public int IdCliente { get; set; }

        public string NomeCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string? Endereco { get; set; }
    }
}
