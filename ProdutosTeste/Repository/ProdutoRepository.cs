using Microsoft.EntityFrameworkCore;
using TesteProdutos.Data;
using TesteProdutos.Model;
using TesteProdutos.Repository.Intefaces;

namespace TesteProdutos.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TesteProdutosDBContext _context;

        public ProdutoRepository(TesteProdutosDBContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }
        public async Task<Produto> AddProduto(Produto produto)
        {
            await _context.Produtos.AddRangeAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> UpdateProduto(Produto produto,int id)
        {
            Produto produtiId = await GetProdutoById(id);
            if (produtiId == null)
            {
                throw new Exception($"O Produto com o ID:{id} enviado não foi encontrado");
            }
            produtiId.Nome = produto.Nome;
            produtiId.Categoria = produto.Categoria;

            _context.Produtos.Update(produtiId);
            await _context.SaveChangesAsync();
            return produtiId;
        }
        public async Task<bool> DeleteProduto(int id)
        {
            Produto produtiId = await GetProdutoById(id);
            if (produtiId == null)
            {
                throw new Exception($"O Produto com o ID:{id} enviado não foi encontrado");
            }

            _context.Produtos.Remove(produtiId);

            if(produtiId != null)
            {
                throw new Exception($"O Produto Removido com sucesso!");
            }
            await _context.SaveChangesAsync();  
            return true;
        }
       
    }
}
