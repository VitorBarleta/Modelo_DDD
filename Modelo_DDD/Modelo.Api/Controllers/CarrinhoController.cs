using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Modelo.Api.Controllers
{
    [ApiController]
    [Route("cliente/[controller]")]
    public class CarrinhoController : Controller
    {
        private readonly IServiceBase<Carrinho> _service;
        private readonly IServiceBase<Cliente> _clienteService;
        private readonly IServiceBase<Produto> _produtoService;

        public CarrinhoController(IServiceBase<Carrinho> service, IServiceBase<Cliente> clienteService, IServiceBase<Produto> produtoService)
        {
            _service = service;
            _clienteService = clienteService;
            _produtoService = produtoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Carrinho>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public IActionResult BuscarTodos(int clienteId)
        {
            if (!ClienteValido(clienteId))
                return Forbid();

            var itens = _service.FindAll(x => x.ClienteId == clienteId);

            if (itens.Count() < 1)
                return NoContent();

            return Ok(itens);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeletarDoCarrinho(int clienteId, int carrinhoId, int produtoId)
        {
            if (!ClienteValido(clienteId))
                return Forbid();

            var produto = _produtoService.Find(x => x.Id == produtoId);

            produto.RemoverDoCarrinho();

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AdicionarNoCarrinho(int clienteId, int carrinhoId, int produtoId)
        {
            if (!ClienteValido(clienteId))
                return Forbid();

            var produto = _produtoService.Find(x => x.Id == produtoId && x.CarrinhoId == carrinhoId);

            if (produto == null)
                return BadRequest();

            produto.AdicionarNoCarrinho(carrinhoId);

            _produtoService.Update(produto.Id, produto);

            _produtoService.Commit();

            return Ok();
        }

        private bool ClienteValido(int clienteId)
        {
            if (_clienteService.Find(x => x.Id == clienteId) == null)
                return false;

            return true;
        }
    }
}
