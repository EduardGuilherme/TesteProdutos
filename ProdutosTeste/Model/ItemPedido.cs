namespace TesteProdutos.Model
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        // Outras propriedades relevantes

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
