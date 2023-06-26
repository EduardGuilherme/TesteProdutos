using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteProdutos.Model
{
    public class ItemPedido
    {
        [Key]
        public int ItemPedidoId { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        
        [JsonIgnore]
        public Pedido Pedido { get; set; }
        
        [JsonIgnore]
        public Produto Produto { get; set; }
    }
}
