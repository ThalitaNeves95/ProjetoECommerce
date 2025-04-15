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
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedido)
        {
            _itemPedidoRepository = itemPedido;
        }

        // GET - Listar
        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarItemPedido(ItemPedido itemPedido)
        {
            // 1 - Coloco o produto no Banco de Dados
            _itemPedidoRepository.Cadastrar(itemPedido);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }
    }
}
