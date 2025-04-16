using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    public class ProdutoRepository : IProdutoRepository
    {
        // Injetar o Context - Banco de Dados
        // Injeção de dependência
        // Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Produto BuscarPorId(int id)
        {
            // ToList() - Pegar vários
            // FirstOrDefault - Traz o primeiro que encontrar, ou null

            // Expressão lambda - função sem corpo
            // _context.Produtos - Acesse a tabela Produtos do Contexto
            // p => p.idProduto == id
            // Para cada Produto P, me retorne aquele que tem o IdProduto igual ao ID que eu quero
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        }

        public void Atualizar(int id, Produto produto)
        {
            // Encontrar o produto a ser atualizado
            Produto ProdutoEncontrado = _context.Produtos.Find(id);

            if (ProdutoEncontrado == null)
            {
                throw new Exception();
            }

            ProdutoEncontrado.NomeProduto = produto.NomeProduto;
            ProdutoEncontrado.Descricao = produto.NomeProduto;
            ProdutoEncontrado.Preco = produto.Preco;
            ProdutoEncontrado.Estoque = produto.Estoque;
            ProdutoEncontrado.Categoria = produto.Categoria;
            ProdutoEncontrado.Imagem = produto.Imagem;

            _context.SaveChanges();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Encontrar o que eu quero excluir
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Caso não encontre o produto, lanço um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
