using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

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
        public void Atualizar(int id, Cliente cliente)
        {
            // Encontrar o produto a ser atualizado
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Senha = cliente.Senha;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();
        }

        /// <summary>
        /// Vai acessar o Banco de Dados e Encontra o Cliente com E-mail e Senha fornecidos
        /// </summary>
        /// <returns>Um cliente ou null</returns>

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o Cliente que possui o e-mail e senha fornecidos
            // Quando eu quero 1 só coisa, utilizo o FirstOrDefault
            Cliente clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente? BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado!");
            }

            _context.Clientes.Remove(clienteEncontrado);

            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
