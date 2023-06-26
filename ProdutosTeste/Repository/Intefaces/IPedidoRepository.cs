using TesteProdutos.Model;

namespace TesteProdutos.Repository.Intefaces
{
    public interface IPedidoRepository
    {
        decimal CalcPedido(int id);
        void AtualizaPedido(int id);
        Task<List<Pedido>> GetPedidos();
        Task<Pedido> GetPedidoById(int id);
        Task<Pedido> AddPedido(Pedido pedido);
        Task<Pedido> UpdatePedido(Pedido pedido, int id);
        Task<bool> DeletePedido(int id);
    }
}
