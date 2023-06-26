using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteProdutos.Model;
using TesteProdutos.Repository.Intefaces;

namespace TesteProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        protected readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produto)
        {
            produtoRepository = produto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            List<Produto> produtos = await produtoRepository.GetProdutos();
            return Ok(produtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> BuscarPorId(int id)
        {
            Produto produto = await produtoRepository.GetProdutoById(id);
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProduto([FromBody] Produto produto)
        {
            Produto prod = await produtoRepository.AddProduto(produto);
            return Ok(prod);
        }
        [HttpPut]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produto, int id)
        {
            produto.ProdutoId = id;
            Produto prod = await produtoRepository.UpdateProduto(produto, id);
            return Ok(prod);
        }
        [HttpDelete]
        public async Task<ActionResult<Produto>> Apagar(int id)
        {
            bool deletado = await produtoRepository.DeleteProduto(id);
            return Ok(deletado);
        }
    }
}
