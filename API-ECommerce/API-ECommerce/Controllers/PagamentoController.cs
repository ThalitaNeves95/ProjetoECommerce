using API_ECommerce.Context;
using API_ECommerce.DTO;
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
        public IActionResult CadastrarPagamento(CadastrarPagamentoDto pagamento)
        {
            // 1 - Coloco o produto no Banco de Dados
            _pagamentoRepository.Cadastrar(pagamento);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var pagamento = _pagamentoRepository.BuscarPorId(id);

            if (pagamento == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(pagamento);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, CadastrarPagamentoDto pagamento)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pagamento);
                return Ok(pagamento);
            }
            catch (Exception ex)
            {

                return NotFound("Pagamento não encontrado!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pagamentoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Pagamento não encontrado!");
            }
        }
    }
}
