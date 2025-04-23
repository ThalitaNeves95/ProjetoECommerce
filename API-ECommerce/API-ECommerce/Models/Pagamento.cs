using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string StatusPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public int IdPedido { get; set; }

    // <nome da tabela> Id CHAVE - Quando for criar a tabela - public virtual Pedido? Pedido { get; set; } = null!;
    public virtual Pedido? Pedido { get; set; } = null!;
}
