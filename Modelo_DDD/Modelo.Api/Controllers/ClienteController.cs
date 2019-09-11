using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Domain.Services;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Modelo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IServiceBase<Cliente> _service;

        public ClienteController(IServiceBase<Cliente> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarTodos()
        {
            var clientes = _service.GetAll();

            if (clientes.Count() < 1)
                return NoContent();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult BuscarPorId(int id)
        {
            var cliente = _service.Find(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Adicionar([FromBody] Cliente cliente)
        {
            _service.Add(cliente);

            return Created("/clientes", null);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Atualizar([FromBody] Cliente cliente)
        {
            var result = _service.Update(cliente.Id, cliente);

            if(!result)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Deletar(int id)
        {
            var result = _service.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
