using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {
        // Read - Ler
        List<Cliente> ListarTodos();

        Cliente? BuscarPorId(int id);

        List<Cliente> BuscarClientePorNome(string nome);

        Cliente? BuscarPorEmailSenha(string email, string senha);

        // Create
        void Cadastrar(CadastrarClienteDto cliente);

        // Update
        void Atualizar(int id, Cliente cliente);

        // Delete
        void Deletar(int id);
    }
}
