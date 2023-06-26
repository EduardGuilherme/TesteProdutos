using TesteProdutos.Model;

namespace TesteProdutos.Repository.Intefaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutos();
        Task <Produto> GetProdutoById(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto, int id);
        Task<bool> DeleteProduto(int id);
    }
}
