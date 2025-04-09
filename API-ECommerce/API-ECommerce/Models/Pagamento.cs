using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string? FormaPagamento { get; set; }

    public string? StatusPagamento { get; set; }

    public int? IdPedido { get; set; }

    public DateTime? DataPagamento { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
