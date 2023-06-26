using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TesteProdutos.Enums;

namespace TesteProdutos.Model
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public ControladorProdutos Categoria { get; set; }

        [JsonIgnore]
        public ICollection<ItemPedido>? ItensPedido { get; set; }
    }
}
