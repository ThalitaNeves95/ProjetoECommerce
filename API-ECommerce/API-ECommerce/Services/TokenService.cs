using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace API_Ecommerce.Services
{
    public class TokenService
    {
        public string GenerateToken(string email)
        {
            // Claims - informacoes do usuário que quero guardar
            // Definição das informações (claims) que serão armazenadas no token
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            // Criação da chave secreta utilizada para assinar o token
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-mega-ultra-segura-senai"));

            // Criptografando a chave de segurança
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // Montar um token
            var token = new JwtSecurityToken(
                issuer: "ecommerce",
                audience: "ecommerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}