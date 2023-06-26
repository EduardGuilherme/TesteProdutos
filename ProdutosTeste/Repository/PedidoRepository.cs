using Microsoft.EntityFrameworkCore;
using TesteProdutos.Data;
using TesteProdutos.Model;
using TesteProdutos.Repository.Intefaces;

namespace TesteProdutos.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly TesteProdutosDBContext _context;

        public PedidoRepository(TesteProdutosDBContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetPedidoById(int id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.PedidoId == id);
        }

        public async Task<List<Pedido>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public decimal CalcPedido(int id)
        {
            var pedido = _context.Pedidos.Include(p => p.Itens).FirstOrDefault(p => p.PedidoId == id);
            if (pedido == null)
                return 0;

            decimal total = 0;
            foreach (var item in pedido.Itens)
            {
                total += item.Quantidade * item.Valor;
            }

            pedido.ValorTotal = total;
            _context.SaveChanges();

            return total;
        }

        public void AtualizaPedido(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);
            if (pedido == null)
                return;

            pedido.ValorTotal = CalcPedido(id);
            _context.SaveChanges();
        }
        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            await _context.Pedidos.AddRangeAsync(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> DeletePedido(int id)
        {
            Pedido pedidoId = await GetPedidoById(id);
            if (pedidoId == null)
            {
                throw new Exception($"O Pedido com o ID:{id} enviado não foi encontrado");
            }

            _context.Pedidos.Remove(pedidoId);

            if (pedidoId != null)
            {
                throw new Exception($"O Pedido Removido com sucesso!");
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Pedido> UpdatePedido(Pedido pedido, int id)
        {
            Pedido pedidoId = await GetPedidoById(id);
            if (pedidoId == null)
            {
                throw new Exception($"O Pedido com o ID:{id} enviado não foi encontrado");
            }
            pedidoId.Descricao = pedido.Descricao;
            pedidoId.Identificador = pedido.Identificador;
            

            _context.Pedidos.Update(pedidoId);
            await _context.SaveChangesAsync();
            return pedidoId;
        }

       
    }
}
