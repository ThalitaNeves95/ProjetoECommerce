using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPagamentoRepository
    {
        // Read - Ler
        List<Pagamento> ListarTodos();

        Pagamento BuscarPorId(int id);

        // Create
        void Cadastrar(Pagamento pagamento);

        // Update
        void Atualizar(int id, Pagamento pagamento);

        // Delete
        void Deletar(int id);
    }
}
