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
    public class EnderecoController : Controller
    {
        private readonly IServiceBase<Endereco> _service;

        public EnderecoController(IServiceBase<Endereco> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarTodos()
        {
            var enderecos = _service.GetAll();

            if (enderecos.Count() < 1)
                return NoContent();

            return Ok(enderecos);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Endereco), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult BuscarPorId(int id)
        {
            var endereco = _service.GetById(id);

            if (endereco == null)
                return NotFound();

            return Ok(endereco);
        }

        [HttpGet]
        [Route("regiao/estado")]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarPorEstado()
        {
            var result = _service.GetAll().OrderBy(x => x.Estado);

            if (result.Count() < 1)
                return NoContent();

            return Ok(result);
        }

        [HttpGet]
        [Route("regiao/cidade")]
        [ProducesResponseType(typeof(IEnumerable<Endereco>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult BuscarPorCidade()
        {
            var result = _service.GetAll().OrderBy(x => x.Cidade);

            if (result.Count() < 1)
                return NoContent();

            return Ok(result);
        }
    }
}
