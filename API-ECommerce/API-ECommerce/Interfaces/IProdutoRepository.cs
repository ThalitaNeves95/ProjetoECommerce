using API_ECommerce.DTO;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces
{
    // Fachada do controller
    public interface IProdutoRepository
    {
        // R - Read (Leitura)
        // Retorno
        List<Produto> ListarTodos();
        // Recebe um identificador, e retorna o produto correspondente
        Produto BuscarPorId(int id);

        // C - Create (Cadastro)
        // produto = argumento
        void Cadastrar(CadastrarProdutoDto produto);

        // U - Update (Atualização)
        // Recebe um identificador para achar o Produto, e recebe o Produto Novo para subistituir o Antigo
        void Atualizar(int id, CadastrarProdutoDto prod);

        // D - Delete (Deleção)
        // Recebe o identificador de quem quero excluir
        void Deletar(int id);
    }
}
