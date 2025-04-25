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
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // GET - Listar
        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

        // Navegador so faz o GET
        // Post - Cadastrar
        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDto pedido)
        {
            // 1 - Coloco o produto no Banco de Dados
            _pedidoRepository.Cadastrar(pedido);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Pedido pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {

                return NotFound("Pedido não encontrado!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Pedido não encontrado!");
            }
        }

    }
}
