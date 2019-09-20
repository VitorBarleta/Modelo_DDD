using Microsoft.AspNetCore.Mvc;
using Modelo.Api.Services.Core;
using Modelo.Api.ViewModels;
using System.Linq;
using System.Net;
using Modelo.Api.Application.Extensions;
using Modelo.Domain.Entities;

namespace Modelo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetAll()
        {
            var clients = _service.GetAll();

            if (clients.Count() < 1)
                return NoContent();

            return Ok(clients.ToViewModel());
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            var client = _service.Find(id);

            if (client == null)
                return NotFound();

            return Ok(client.ToViewModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientDetailsViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddClient([FromBody] ClientDetailsViewModel client)
        {
            var newClient = new Client(
                client.Name,
                client.LastName,
                client.Email,
                client.Phone,
                client.BirthDate,
                client.Address
                );

            var result = _service.Add(newClient);

            if (result < 1)
                return BadRequest();

            return Created("/client", client.ToString());
        }

        [HttpPut]
        [Route("{id:int}/email")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateEmail(int id, [FromBody] string email)
        {
            var operationResult = _service.UpdateEmail(id, email);

            if (operationResult < 1)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/phone")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdatePhone(int id, [FromBody] string phone)
        {
            var operationResult = _service.UpdatePhone(id, phone);

            if (operationResult < 1)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/address")]
        [ProducesResponseType(typeof(ClientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateAddress(int id, [FromBody] string address)
        {
            var operationResult = _service.UpdateAddress(id, address);

            if (operationResult < 1)
                return BadRequest();

            return Ok();
        }
    }
}
