using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    // Repository - Métodos que acessam o Banco de Dados
    public class PagamentoRepository : IPagamentoRepository
    {
        // Injetar o Context - Banco de Dados
        // Injeção de dependência
        // Variavel privada, porque só vai ser usada nessa classe.
        private readonly EcommerceContext _context;

        // Método Construtor - ctor
        // Quando criar um objeto o que eu preciso ter?
        // É semelhante ao new()
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pagamento pagamento)
        {
            var PagamentoEncontrado = _context.Pagamentos.Find(id);

            if (PagamentoEncontrado == null)
            {
                throw new Exception();
            }

            PagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            PagamentoEncontrado.StatusPagamento = pagamento.StatusPagamento;
            PagamentoEncontrado.DataPagamento = pagamento.DataPagamento;
            PagamentoEncontrado.IdPedido = pagamento.IdPedido;

            _context.SaveChanges();
        }

        public Pagamento? BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(c => c.IdPagamento == id);
        }

        public void Cadastrar(CadastrarPagamentoDto pagamento)
        {
            Pagamento pagamentoCadastro = new Pagamento
            {
                FormaPagamento = pagamento.FormaPagamento,
                StatusPagamento = pagamento.StatusPagamento,
                DataPagamento = pagamento.DataPagamento,
                IdPedido = pagamento.IdPedido
            };
            _context.Pagamentos.Add(pagamentoCadastro);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.Pedido).ToList();
        }
    }
}
