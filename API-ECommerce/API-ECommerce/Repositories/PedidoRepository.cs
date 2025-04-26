using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

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

        public void Atualizar(int id, CadastrarPedidoDto pedido)
        {

            var pedidoEncontrado = _context.Pedidos.Find(id);

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

        public Pedido? BuscarPorId(int id)
        {
            // Pode ser utilizado para buscar qualquer campo
            return _context.Pedidos.FirstOrDefault(c => c.IdPedido == id);

        }

        public void Cadastrar(CadastrarPedidoDto pedido)
        {
            Pedido pedidoCadastrar = new Pedido
            {
                DataPedido = pedido.DataPedido,
                StatusPedido = pedido.StatusPedido,
                IdCliente = pedido.IdCliente,
                ValorTotal = pedido.ValorTotal,
            };
            _context.Pedidos.Add(pedidoCadastrar);

            _context.SaveChanges();

            // Cadastrar os ItensPedidos
            // Para cada produto, eu crio um ItemPedido
            // Percorre uma lista/vetor ["mouse", "teclado"]
            for (int i = 0; i < pedido.Produtos.Count; i++)
            {
                // Encontra o produto
                var produto = _context.Produtos.Find(pedido.Produtos[i]);

                // TO-DO: Lançar erro se produto não existir

                // Criando uma váriavel para armazenar os itens do pedido - ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedidoCadastrar.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                // Joga no banco de dados
                _context.ItemPedidos.Add(itemPedido);
                // Salva no banco
                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            // Find pode ser utilizado somento por chave primaria (ID)
            var pedidoEncontrado = _context.Pedidos.Find(id);

            if (pedidoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pedidos.Remove(pedidoEncontrado);

            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos.Include(p => p.ItemPedidos).ThenInclude(p => p.Produto).ToList();

        }
    }
}
