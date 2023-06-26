using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteProdutos.Model;

namespace TesteProdutos.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Categoria).IsRequired();
            builder.HasMany(p => p.ItensPedido)
                .WithOne(ip => ip.Produto)
                .HasForeignKey(ip => ip.ProdutoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
