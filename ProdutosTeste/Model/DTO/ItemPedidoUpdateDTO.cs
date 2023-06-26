namespace ProdutosTeste.Model.DTO
{
    public class ItemPedidoUpdateDTO
    {
        public int ItemPedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
