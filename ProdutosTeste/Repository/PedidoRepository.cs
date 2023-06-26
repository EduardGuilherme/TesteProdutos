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
            var pedido = _context.Pedidos.Include(p => p.Itens)
                                     .FirstOrDefault(p => p.PedidoId == id);

            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            decimal valorTotal = pedido.Itens.Sum(ip => ip.Valor * ip.Quantidade);

            return valorTotal;
        }

        public void AtualizaPedido(int id)
        {
            var pedido = _context.Pedidos.Include(p => p.Itens)
                                     .FirstOrDefault(p => p.PedidoId == id);

            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            decimal valorTotal = pedido.Itens.Sum(ip => ip.Valor * ip.Quantidade);
            pedido.ValorTotal = valorTotal;

            _context.SaveChanges();
        }
        public Task<Produto> AddPedido(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePedido(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> UpdatePedido(Produto produto, int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
