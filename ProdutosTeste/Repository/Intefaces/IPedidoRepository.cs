using TesteProdutos.Model;

namespace TesteProdutos.Repository.Intefaces
{
    public interface IPedidoRepository
    {
        decimal CalcPedido(int id);
        void AtualizaPedido(int id);
        Task<List<Pedido>> GetPedidos();
        Task<Pedido> GetPedidoById(int id);
        Task<Produto> AddPedido(Produto produto);
        Task<Produto> UpdatePedido(Produto produto, int id);
        Task<bool> DeletePedido(int id);
    }
}
