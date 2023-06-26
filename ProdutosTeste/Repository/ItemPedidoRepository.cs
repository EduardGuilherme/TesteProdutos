using Microsoft.EntityFrameworkCore;
using TesteProdutos.Data;
using TesteProdutos.Model;
using TesteProdutos.Repository.Intefaces;

namespace TesteProdutos.Repository
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly TesteProdutosDBContext _context;

        public ItemPedidoRepository(TesteProdutosDBContext context)
        {
            _context= context;
        }
        public async Task<List<ItemPedido>> GetItensPedido()
        {
            return await _context.ItemPedido.ToListAsync();
        }

        public async Task<ItemPedido> GetItemPedidoById(int id)
        {
            return await _context.ItemPedido.FindAsync(id);
        }

        public async Task<ItemPedido> AddItemPedido(ItemPedido itemPedido)
        {
            _context.ItemPedido.Add(itemPedido);
            await _context.SaveChangesAsync();
            return itemPedido;
        }

        public async Task<ItemPedido> UpdateItemPedido(ItemPedido itemPedido)
        {
            _context.Entry(itemPedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return itemPedido;
        }

        public async Task<bool> DeleteItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido == null)
                return false;

            _context.ItemPedido.Remove(itemPedido);
            if (itemPedido != null)
                throw new Exception($"O ItemPedido Removido com sucesso!");
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
