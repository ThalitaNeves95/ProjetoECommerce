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
            Cliente ClienteEncontrado = _context.Clientes.Find(id);

            if (ClienteEncontrado == null)
            {
                throw new Exception();
            }

            ClienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            ClienteEncontrado.Email = cliente.Email;
            ClienteEncontrado.Telefone = cliente.Telefone;
            ClienteEncontrado.Endereco = cliente.Endereco;
            ClienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
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
                throw new Exception();
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
