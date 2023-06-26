using Microsoft.EntityFrameworkCore;
using TesteProdutos.Data.Map;
using TesteProdutos.Model;

namespace TesteProdutos.Data
{
    public class TesteProdutosDBContext : DbContext
    {
        public TesteProdutosDBContext (DbContextOptions<TesteProdutosDBContext> options)
            : base(options)
        {

        }

        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
