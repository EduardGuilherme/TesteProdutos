using TesteProdutos.Model;

namespace TesteProdutos.Repository.Intefaces
{
    public interface IItemPedidoRepository
    {
        IEnumerable<ItemPedido> GetItensPedido();
        ItemPedido GetItemPedidoById(int id);
        void AddItemPedido(ItemPedido itemPedido);
        void UpdateItemPedido(ItemPedido itemPedido);
        void DeleteItemPedido(int id);
    }
}
