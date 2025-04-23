using API_ECommerce.Context;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {
        // Read - Ler
        List<Cliente> ListarTodos();

        Cliente? BuscarPorId(int id);

        Cliente? BuscarPorEmailSenha(string email, string senha);

        // Create
        void Cadastrar(Cliente cliente);

        // Update
        void Atualizar(int id, Cliente cliente);

        // Delete
        void Deletar(int id);
    }
}
