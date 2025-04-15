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
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        // Todo metodo contrutor, tem que ter o mesmo nome da class
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET
        // Criar metodo de listar
        [HttpGet] // Verbo que o endpoint vai ter - Get, Post, Put ou Delete
        // IActionResult = Interface que vem do .net - Permite que um metodo retorne um status code
        public IActionResult ListarClientes()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        // Navegador so faz o GET
        // Post - Cadastrar
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            // 1 - Coloco o cliente no Banco de Dados
            _clienteRepository.Cadastrar(cliente);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }
    }
}
