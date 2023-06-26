using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteProdutos.Model;

namespace TesteProdutos.Data.Map
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.ItemPedidoId);

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.HasOne(ip => ip.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(ip => ip.PedidoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
   
            builder.HasOne(ip => ip.Produto)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(ip => ip.ProdutoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
