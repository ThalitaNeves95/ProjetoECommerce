﻿using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IPedidoRepository
    {
        // Read - Ler
        List<Pedido> ListarTodos();

        Pedido? BuscarPorId(int id);

        // Create
        void Cadastrar(CadastrarPedidoDto pedido);

        // Update
        void Atualizar(int id, CadastrarPedidoDto pedido);

        // Delete
        void Deletar(int id);
    }
}
