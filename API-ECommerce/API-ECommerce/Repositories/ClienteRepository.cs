﻿using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Services;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    // 1 - Herda da Interface
    // 2 - Implementa a Interface
    // 3 - Injetar o Contexto
    public class ClienteRepository : IClienteRepository
    {
        // 4 - Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        // Ação de Injetar

        // Metodo Construtor - É um metodo que tem o mesmo nome da classe
        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, CadastrarClienteDto cliente)
        {
            // Instanciar o PasswordService
            var passwordService = new PasswordService();

            // Encontrar o produto a ser atualizado
            var clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Senha = cliente.Senha;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;

            clienteEncontrado.Senha = passwordService.HashPassword(clienteEncontrado);

            _context.SaveChanges();
        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            //Where - traz todos que atendem uma condicao
            //var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto.Contains(nome)).ToList();

            return listaClientes;
        }

        /// <summary>
        /// Vai acessar o Banco de Dados e Encontra o Cliente com E-mail e Senha fornecidos
        /// </summary>
        /// <returns>Um cliente ou null</returns>

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o Cliente que possui o e-mail e senha fornecidos
            // Quando eu quero 1 só coisa, utilizo o FirstOrDefault
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email);

            // Caso não encontre, retorno nulo
            if(clienteEncontrado == null)
            return null;

            var passwordService = new PasswordService();

            // Verificar se a senha do usuário gera a mesma Hash
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);

            if(resultado == true) return clienteEncontrado;
            return null;
        }

        public Cliente? BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDto cliente)
        {
            // Instanciar o PasswordService
            var passwordService = new PasswordService();

            Cliente clienteCadastrar = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone,
                Email = cliente.Email,
                Senha = cliente.Senha,
                DataCadastro = DateOnly.FromDateTime(DateTime.Now)
            };

            clienteCadastrar.Senha = passwordService.HashPassword(clienteCadastrar);

            _context.Clientes.Add(clienteCadastrar);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            _context.Clientes.Remove(clienteEncontrado);

            _context.SaveChanges();
        }

        public List<ListarClienteViewModel> ListarTodos()
        {
            // Select permite que eu selecione quais campos eu quero pegar
            return _context.Clientes.Select(c => new ListarClienteViewModel
            {
                IdCliente = c.IdCliente,
                NomeCompleto = c.NomeCompleto, 
                Endereco = c.Endereco, 
                Telefone = c.Telefone,
                Email = c.Email
            }).ToList();
        }
    }
}
