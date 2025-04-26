using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        // Read - Ler
        List<ItemPedido> ListarTodos();

        ItemPedido? BuscarPorId(int id);

        // Create
        void Cadastrar(CadastrarItemPedidoDto itemPedido);

        // Update
        void Atualizar(int id, CadastrarItemPedidoDto itemPedido);

        // Delete
        void Deletar(int id);
    }
}
