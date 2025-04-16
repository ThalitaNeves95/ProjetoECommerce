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
            throw new NotImplementedException();
        }

        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Produtos.Remove(produtoEncontrado);

            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
