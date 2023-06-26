using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteProdutos.Model
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorTotal { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedido>? Itens { get; set; }
    }
}
