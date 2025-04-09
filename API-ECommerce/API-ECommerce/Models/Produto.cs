using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string? NomeProduto { get; set; }

    public string? Descricao { get; set; }

    public decimal? Preco { get; set; }

    public int? Estoque { get; set; }

    public string? Categoria { get; set; }

    public string? Imagem { get; set; }

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();
}
