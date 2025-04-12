using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly EcommerceContext _context;

        // Váriavel privada que traz o Repository
        private IPedidoRepository _pedidoRepository;

        public PedidoController(EcommerceContext context)
        {
            _context = context;
            _pedidoRepository = new PedidoRepository(_context);
        }

        // GET - Listar
        // 1. Definir o VERBO
        [HttpGet]
        // IActionResult = Interface que vem do .net - Permite que um metodo retorne um status code
        public IActionResult ListarPedidos()
        {
            // Retorna a váriavel privada que traz o Repository
            return Ok(_pedidoRepository.ListarTodos());
        }
    }
}
