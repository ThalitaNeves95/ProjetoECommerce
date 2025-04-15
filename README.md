# Projeto E-Commerce 🛒

### 1. Modelar o banco de dados (Conceitual, Lógico e Físico)
<ins>Pode utilizar a ferramenta draw.io</ins>
    
### 2. Criar o banco de dados (Arquivos DDL e DML)

### 3. Instalar os pacotes necessários para rodar a aplicação
    3.1 EntityFrameworkCore.Design
    3.2 EntityFrameworkCore.SqlServer
    3.3 EntityFrameworkCore.Tools
    
### 4. Realizar o Scaffold

Utilizar os comandos abaixo no terminal - o segundo comando instala as ferramentas do EntityFrameWork:
```
dotnet tool install --global dotnet-ef
```    
    dotnet ef dbcontext scaffold "Data Source=NOTE-VINICIO\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Context --output-dir Models
       
    
### 5. Caso dê algum erro no passo anterior, pode adicionar o código abaixo no arquivo/pasta API-ECommerce:
    - <GenerateRuntimeConfigurationFiles>True</GenerateRuntimeConfigurationFiles>
    
![image](https://github.com/user-attachments/assets/0e48b397-85df-4669-92b9-2a360c8532ca)


### 6. Criar a estrutura e pastas do projeto:
    6.1 Controlles
    6.2 Interfaces
    6.3 Repositories  
![Screenshot 2025-04-14 212635](https://github.com/user-attachments/assets/2dcdbbd5-2589-4282-815e-9bd3dced1075)


### 7. Criar os arquivos de Interface - Definir Metodos de CRUD:

    using API_ECommerce.Models;

    namespace API_ECommerce.Interfaces
    {
        // Fachada do controller
        public interface IProdutoRepository
        {
            // R - Read (Leitura)
            // Retorno
            List<Produto> ListarTodos();
            // Recebe um identificador, e retorna o produto correspondente
            Produto BuscarPorId(int id);
    
            // C - Create (Cadastro)
            // produto = argumento
            void Cadastrar(Produto produto);
    
            // U - Update (Atualização)
            // Recebe um identificador para achar o Produto, e recebe o Produto Novo para subistituir o Antigo
            void Atualizar(int id, Produto produto);
    
            // D - Delete (Deleção)
            // Recebe o identificador de quem quero excluir
            void Deletar(int id);
        }
    }


### 8. Criar Repository
    8.1 Herdar da Interface
    8.2 Implementar Interface
    8.3 Criar a Variável Contexto
    8.4 Injetar o Contexto
    8.5 Implementar Metódos

<ins> </ins>

    using API_ECommerce.Context;
    using API_ECommerce.Interfaces;
    using API_ECommerce.Models;

    namespace API_ECommerce.Repositories
    {
        // Repository - Métodos que acessam o Banco de Dados
        public class ProdutoRepository : IProdutoRepository
        {
            // Injetar o Context - Banco de Dados
            // Injeção de dependência
            // Variavel privada, porque só vai ser usada nessa classe.
            private readonly EcommerceContext _context;
    
            // Método Construtor - ctor
            // Quando criar um objeto o que eu preciso ter?
            // É semelhante ao new()
            public ProdutoRepository(EcommerceContext context)
            {
                _context = context;
            }
    
            public void Atualizar(int id, Produto produto)
            {
                throw new NotImplementedException();
            }
    
            public Produto BuscarPorId(int id)
            {
                throw new NotImplementedException();
            }
    
            public void Cadastrar(Produto produto)
            {
                _context.Produtos.Add(produto);
                // 2 - Salvo a Alteração
                _context.SaveChanges();
            }
    
            public void Deletar(int id)
            {
                throw new NotImplementedException();
            }
    
            public List<Produto> ListarTodos()
            {
                return _context.Produtos.ToList();
            }
        }
    }


### 9. Configurar Injeção de Dependência - Arquivo Program.cs
    using API_ECommerce.Context;
    using API_ECommerce.Interfaces;
    using API_ECommerce.Repositories;
    
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services.AddControllers();
    
    builder.Services.AddSwaggerGen();
    
    // O .NET vai criar os objetos (Injeção de Dependencia)
    // AddTransiente - O C# cria uma instancia nova, toda vez que um método é chamado
    // AddScoped - O C# cria uma instancia nova, toda vez que criar um Controller
    // AddSingleton - 
    
    builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
    builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
    builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
    builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
    builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
    builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
    
    var app = builder.Build();
    
    app.UseSwagger();
    
    app.UseSwaggerUI();
    
    app.MapControllers();
    
    app.Run();

### 10. Criar a Classe Controller
    10.1 Injetar o Repository
    10.2 Criar Metodos do CRUD
        10.2.1 Listar
        10.2.2 Criar
        10.2.3 Editar
        10.2.4 Deletar

<ins> </ins>

    using API_ECommerce.Context;
    using API_ECommerce.Interfaces;
    using API_ECommerce.Models;
    using API_ECommerce.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    
    // O Controller precisa de um repository
    namespace API_ECommerce.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProdutoController : ControllerBase
        {
            private IProdutoRepository _produtoRepository;
    
            // Injeção de Dependência
            // Ao invés de instanciar a classe manualmente, eu aviso que dependo dela. E a responsabilidade de criar a mesma se torna do (C#)
            public ProdutoController(IProdutoRepository produtoRepository)
            {
                // Criar o repository não deve ser uma responsabilidade do Controller
                _produtoRepository = produtoRepository;
            }
    
            // GET - Listar
            [HttpGet]
            public IActionResult ListarProdutos()
            {
                return Ok(_produtoRepository.ListarTodos());
            }
    
            // Navegador so faz o GET
            // Post - Cadastrar
            [HttpPost]
            public IActionResult CadastrarProduto(Produto prod)
            {
                // 1 - Coloco o produto no Banco de Dados
                _produtoRepository.Cadastrar(prod);
    
                // 3 - Retorno o resultado
                // 201 - Created
                return Created();
            }
        }
    }


    



