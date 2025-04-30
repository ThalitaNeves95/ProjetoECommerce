// 0 - Importa
using System.Text;
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.IdentityModel.Tokens;

// 1 - NUNCA MEXER - Onde começa meu projeto/Program.cs - Sempre a primeira linha
var builder = WebApplication.CreateBuilder(args);
// 3- 
builder.Services.AddControllers();
// 4 -
builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos (Injeção de Dependencia)
// AddTransiente - O C# cria uma instancia nova, toda vez que um método é chamado
// AddScoped - O C# cria uma instancia nova, toda vez que criar um Controller
// AddSingleton - 
// 5 -
builder.Services.AddDbContext<EcommerceContext>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

// AddJwtBearer só aparece se instalar a extensão
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ecommerce",
            ValidAudience = "ecommerce",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-secreta-mega-ultra-segura-senai"))
        };
    });

builder.Services.AddAuthorization();

// Controi a aplicação
// 6 -
var app = builder.Build();
// 7 -
app.UseSwagger();
// 8 -
app.UseSwaggerUI();
// 9 -
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

// 10 -
app.Run();