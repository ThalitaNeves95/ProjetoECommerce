﻿using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;

        private IClienteRepository _clienteRepository;
        // Todo metodo contrutor, tem que ter o mesmo nome da class
        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(_context);
        }

        // GET - Listar
        [HttpGet]
        public IActionResult ListarClientes()
        {
            return Ok(_clienteRepository.ListarTodos());
        }
    }
}
