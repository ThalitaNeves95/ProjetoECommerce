using API_ECommerce.Context;
using API_ECommerce.DTO;
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
        public IActionResult CadastrarProduto(CadastrarProdutoDto prod)
        {
            // 1 - Coloco o produto no Banco de Dados
            _produtoRepository.Cadastrar(prod);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        // Buscar produto por id
        // api/produtos
        // api/produto/1
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Produto prod)
        {
            try
            {
                _produtoRepository.Atualizar(id, prod);
                return Ok(prod);
            }
            catch (Exception ex)
            {

                return NotFound("Produto não encontrado!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Produto não encontrado!");
            }
        }
    }
}
