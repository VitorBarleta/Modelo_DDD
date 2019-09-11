using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Modelo.Api.Controllers
{
    [ApiController]
    [Route("cliente/[controller]")]
    public class TelefoneController : Controller
    {
        private readonly IServiceBase<Telefone> _service;

        public TelefoneController(IServiceBase<Telefone> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Telefone>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarTodos()
        {
            var telefones = _service.GetAll();

            if (telefones.Count() < 1)
                return NoContent();

            return Ok(telefones);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Telefone), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarPorId(int id)
        {
            var telefone = _service.GetById(id);

            if (telefone == null)
                return NotFound();

            return Ok(telefone);
        }

        [HttpGet]
        [Route("regiao/{codigoRegiao}")]
        [ProducesResponseType(typeof(IEnumerable<Telefone>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarPorRegiao(string codigoRegiao)
        {
            var telefones = _service.FindAll(x => x.CodigoRegiao == codigoRegiao);

            if (telefones.Count() < 1)
                return NoContent();

            return Ok(telefones);
        }
    }
}
