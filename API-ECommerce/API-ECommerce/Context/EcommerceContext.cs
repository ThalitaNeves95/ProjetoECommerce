using System;
using System.Collections.Generic;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Context;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ItemPedido> ItemPedidos { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EUMC23F\\SQLEXPRESS;Initial Catalog=ECommerce;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642246BD5B1");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Telefone, "UQ__Cliente__4EC504B6BA955E96").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido).HasName("PK__ItemPedi__F77088BA00AF177B");

            entity.ToTable("ItemPedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemPedid__IdPed__7A672E12");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemPedid__IdPro__7B5B524B");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.IdPagamento).HasName("PK__Pagament__D474651E1D8609B5");

            entity.ToTable("Pagamento");

            entity.Property(e => e.DataPagamento).HasColumnType("datetime");
            entity.Property(e => e.FormaPagamento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StatusPagamento)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagamento__IdPed__7E37BEF6");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC3566B49F6");

            entity.ToTable("Pedido");

            entity.Property(e => e.StatusPedido)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedido__IdClient__72C60C4A");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C232531FC80");

            entity.ToTable("Produto");

            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Imagem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(12, 6)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
