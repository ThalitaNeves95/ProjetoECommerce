using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IItemRepository
    {
        // Read - Ler
        List<ItemPedido> ListarTodos();

        ItemPedido BuscarPorId(int id);

        // Create
        void Cadastrar(ItemPedido itemPedido);

        // Update
        void Atualizar(int id, ItemPedido itemPedido);

        // Delete
        void Deletar(int id);
    }
}
