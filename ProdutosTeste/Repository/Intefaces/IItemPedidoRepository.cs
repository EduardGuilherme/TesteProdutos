using TesteProdutos.Model;

namespace TesteProdutos.Repository.Intefaces
{
    public interface IItemPedidoRepository
    {
        Task<List<ItemPedido>> GetItensPedido();
        Task<ItemPedido> GetItemPedidoById(int id);
        Task<ItemPedido> AddItemPedido(ItemPedido itemPedido);
        Task<ItemPedido> UpdateItemPedido(ItemPedido itemPedido);
        Task<bool> DeleteItemPedido(int id);
    }
}
