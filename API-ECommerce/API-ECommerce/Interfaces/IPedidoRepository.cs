using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPedidoRepository
    {
        // Read - Ler
        List<Pedido> ListarTodos();

        Pedido BuscarPorId(int id);

        // Create
        void Cadastrar(Pedido pedido);

        // Update
        void Atualizar(int id, Pedido pedido);

        // Delete
        void Deletar(int id);
        void Cadastrar(Produto pedido);
    }
}
