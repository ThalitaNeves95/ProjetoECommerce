using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        // Váriavel privada que traz o Repository
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        // GET - Listar
        // 1. Definir o VERBO
        [HttpGet]
        // IActionResult = Interface que vem do .net - Permite que um metodo retorne um status code
        public IActionResult ListarPagamentos()
        {
            // Retorna a váriavel privada que traz o Repository
            return Ok(_pagamentoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            // 1 - Coloco o produto no Banco de Dados
            _pagamentoRepository.Cadastrar(pagamento);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }
    }
}
