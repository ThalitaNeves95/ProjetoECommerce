using API_ECommerce.Models;

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
        void Cadastrar(Produto produto);

        // U - Update (Atualização)
        // Recebe um identificador para achar o Produto, e recebe o Produto Novo para subistituir o Antigo
        void Atualizar(int id, Produto prod);

        // D - Delete (Deleção)
        // Recebe o identificador de quem quero excluir
        void Deletar(int id);
    }
}
