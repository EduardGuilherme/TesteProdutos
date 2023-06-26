using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteProdutos.Model;

namespace TesteProdutos.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.PedidoId);

            builder.Property(x => x.Identificador).IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Descricao)
                .HasMaxLength(1000);

            builder.Property(x => x.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasMany(p => p.Itens)
                .WithOne(ip => ip.Pedido)
                .HasForeignKey(ip => ip.PedidoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
