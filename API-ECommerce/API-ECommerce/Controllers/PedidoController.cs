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
        public IActionResult CadastrarPedido(Pedido pedido)
        {
            // 1 - Coloco o produto no Banco de Dados
            _pedidoRepository.Cadastrar(pedido);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }
    }
}
