using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    public class PedidoRepository : IPedidoRepository
    {
        // Injetar o Context - Banco de Dados
        // Injeção de dependência
        // Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pedido pedido)
        {

            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            if (pedidoEncontrado == null)
            {
                throw new Exception();
            }

            pedidoEncontrado.DataPedido = pedido.DataPedido;
            pedidoEncontrado.StatusPedido = pedido.StatusPedido;
            pedidoEncontrado.ValorTotal = pedido.ValorTotal;
            pedidoEncontrado.IdCliente = pedido.IdCliente;

            _context.SaveChanges();
        }

        public Pedido BuscarPorId(int id)
        {
            // Pode ser utilizado para buscar qualquer campo
            return _context.Pedidos.FirstOrDefault(c => c.IdPedido == id);

        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Find pode ser utilizado somento por chave primaria (ID)
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            if (pedidoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pedidos.Remove(pedidoEncontrado);

            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.ToList();
        }
    }
}
