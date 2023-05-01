using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    { 
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET api/client
        // Summary - Gets all clients
        // Param - None
        // Return - All clients
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return Ok(_clientService.GetAll());
        }

        // GET api/client/5
        // Summary - Gets a client by id
        // Param - id
        // Return - A client
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST api/client
        // Summary - Creates a client
        // Param - A client
        // Return - The created client
        [HttpPost]
        public ActionResult<Client> Post([FromBody] Client client)
        {
            return Ok(_clientService.Post(client));
        }

        // PUT api/client/5
        // Summary - Updates a client
        // Param - id, a client
        // Return - The updated client
        [HttpPut("{id}")]
        public ActionResult<Client> Put(int id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            return Ok(_clientService.Put(id, client));
        }

        // DELETE api/client/5
        // Summary - Deletes a client
        // Param - id
        // Return - The deleted client
        [HttpDelete("{id}")]
        public ActionResult<Client> Delete(int id)
        {
            var client = _clientService.Delete(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}