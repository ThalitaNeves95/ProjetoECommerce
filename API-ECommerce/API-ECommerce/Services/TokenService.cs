using System.Security.Claims;

namespace API_ECommerce.Services
{
    public class TokenService
    {
        public string GenerateToken(string email, string nome)
        {
            // Criar as Claims - Informações do Usuário que eu quero guardar
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, nome)
            };


        }
    }
}
