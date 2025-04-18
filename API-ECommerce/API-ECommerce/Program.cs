// 0 - Importa
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;

// 1 - NUNCA MEXER - Onde come�a meu projeto/Program.cs - Sempre a primeira linha
var builder = WebApplication.CreateBuilder(args);
// 3- 
builder.Services.AddControllers();
// 4 -
builder.Services.AddSwaggerGen();

// O .NET vai criar os objetos (Inje��o de Dependencia)
// AddTransiente - O C# cria uma instancia nova, toda vez que um m�todo � chamado
// AddScoped - O C# cria uma instancia nova, toda vez que criar um Controller
// AddSingleton - 
// 5 -
builder.Services.AddDbContext<EcommerceContext>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();

// Controi a aplica��o
// 6 -
var app = builder.Build();
// 7 -
app.UseSwagger();
// 8 -
app.UseSwaggerUI();
// 9 -
app.MapControllers();
// 10 -
app.Run();