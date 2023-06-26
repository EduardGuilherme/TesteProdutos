using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteProdutos.Model;
using TesteProdutos.Repository;
using TesteProdutos.Repository.Intefaces;

namespace ProdutosTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var pedidos = await _pedidoRepository.GetPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{pedidoId}")]
        public async Task<ActionResult<Pedido>> GetPedido(int pedidoId)
        {
            var pedido = await _pedidoRepository.GetPedidoById(pedidoId);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CadastrarPedido(Pedido pedido)
        {
            Pedido prod = await _pedidoRepository.AddPedido(pedido);
            return Ok(prod);
        }

        [HttpPut("{pedidoId}")]
        public async Task<ActionResult> AtualizaPedido(int pedidoId, Pedido pedido)
        {
            pedido.PedidoId = pedidoId;
            Pedido ped = await _pedidoRepository.UpdatePedido(pedido, pedidoId);
            _pedidoRepository.AtualizaPedido(pedidoId);
            return Ok(ped);
        }

        [HttpDelete("{pedidoId}")]
        public async Task<ActionResult> DeletePedido(int pedidoId)
        {
            var pedido = await _pedidoRepository.GetPedidoById(pedidoId);
            if (pedido == null)
                return NotFound();

            await _pedidoRepository.DeletePedido(pedidoId);
            return Ok("Deletado");
        }
    }
}
