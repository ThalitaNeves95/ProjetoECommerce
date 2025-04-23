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

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet("{email}/{senha}")]
        public IActionResult Login(string email, string senha)
        {
            Cliente cliente = _clienteRepository.BuscarPorEmailSenha(email, senha);

            if (cliente == null)
            {
                // 404 - Não Encontrado
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok(cliente);
            }
            catch (ArgumentNullException ex)
            {

                return NotFound("Cliente não encontrado!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }

            catch (ArgumentNullException ex)
            {
                return NotFound("Cliente não encontrado!");
            }
        }
    }
}
