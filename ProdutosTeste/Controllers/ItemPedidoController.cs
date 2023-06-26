using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosTeste.Model.DTO;
using TesteProdutos.Model;
using TesteProdutos.Repository.Intefaces;

namespace ProdutosTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItensPedido()
        {
            var itensPedido = await _itemPedidoRepository.GetItensPedido();
            return Ok(itensPedido);
        }

        [HttpGet("{itemPedidoId}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedidoid(int itemPedidoId)
        {
            var itemPedido = await _itemPedidoRepository.GetItemPedidoById(itemPedidoId);
            if (itemPedido == null)
                return NotFound();

            return Ok(itemPedido);
        }

        [HttpPost]
        public async Task<ActionResult<ItemPedido>> CadastrarItemPedido([FromBody]ItemPedido itemPedido)
        {
            var newItemPedido = await _itemPedidoRepository.AddItemPedido(itemPedido);
            return CreatedAtAction(nameof(GetItemPedidoid), new { itemPedidoId = newItemPedido.ItemPedidoId }, newItemPedido);
        }

        [HttpPut("{itemPedidoId}")]
        public async Task<ActionResult> UpdateItemPedido(int itemPedidoId, [FromBody] ItemPedido itemPedido)
        {
            if (itemPedidoId != itemPedido.ItemPedidoId)
                return BadRequest();

            var existingItemPedido = await _itemPedidoRepository.GetItemPedidoById(itemPedidoId);
            if (existingItemPedido == null)
                return NotFound();

            existingItemPedido.ProdutoId = itemPedido.ProdutoId;
            existingItemPedido.Quantidade = itemPedido.Quantidade;
            existingItemPedido.Valor = itemPedido.Valor;

            await _itemPedidoRepository.UpdateItemPedido(existingItemPedido);

            return Ok();
        }

        [HttpDelete("{itemPedidoId}")]
        public async Task<ActionResult> DeleteItemPedido(int itemPedidoId)
        {
            bool result = await _itemPedidoRepository.DeleteItemPedido(itemPedidoId);
            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
