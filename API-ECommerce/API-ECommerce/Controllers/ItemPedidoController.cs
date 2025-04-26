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
        public IActionResult CadastrarItemPedido(CadastrarItemPedidoDto itemPedido)
        {
            // 1 - Coloco o produto no Banco de Dados
            _itemPedidoRepository.Cadastrar(itemPedido);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var itemPedidoEncontrado = _itemPedidoRepository.BuscarPorId(id);

            if (itemPedidoEncontrado == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(itemPedidoEncontrado);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, CadastrarItemPedidoDto itemPedido)
        {
            try
            {
                _itemPedidoRepository.Atualizar(id, itemPedido);
                return Ok(itemPedido);
            }
            catch (Exception ex)
            {

                return NotFound("Item pedido não encontrado!");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _itemPedidoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Item pedido não encontrado!");
            }
        }
    }
}
