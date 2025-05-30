﻿using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        // Injetar o Context - Banco de Dados
        // Injeção de dependência
        // Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        public ItemPedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarItemPedidoDto itemPedido)
        {
            var itemPedidoEncontrado = _context.ItemPedidos.Find(id);

            if (itemPedidoEncontrado == null)
            {
                throw new Exception();
            }

            itemPedidoEncontrado.Quantidade = itemPedido.Quantidade;
            itemPedidoEncontrado.IdPedido = itemPedido.IdPedido;
            itemPedidoEncontrado.IdProduto = itemPedido.IdProduto;

            _context.SaveChanges();
        }

        public ItemPedido? BuscarPorId(int id)
        {
            return _context.ItemPedidos.FirstOrDefault(c => c.IdItemPedido == id);
        }

        public void Cadastrar(CadastrarItemPedidoDto itemPedido)
        {
            ItemPedido itemPedidoCadastrar = new ItemPedido
            {
                Quantidade = itemPedido.Quantidade,
                IdPedido = itemPedido.IdPedido,
                IdProduto = itemPedido.IdProduto
            };
            _context.ItemPedidos.Add(itemPedidoCadastrar);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var itemPedidoEncontrado = _context.ItemPedidos.Find(id);

            if (itemPedidoEncontrado == null)
            {
                throw new Exception();
            }

            _context.ItemPedidos.Remove(itemPedidoEncontrado);

            _context.SaveChanges();
        }

        public List<ItemPedido> ListarTodos()
        {
            return _context.ItemPedidos.ToList();
        }
    }
}
