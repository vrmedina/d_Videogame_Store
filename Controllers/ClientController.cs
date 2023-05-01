using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using d_Videogame_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        // Context to access the database
        // private readonly VideogameStoreContext _context;

        // public ClientController(VideogameStoreContext context)
        // {
        //     _context = context;
        // }
        
        // mock context data
        private static List<Client> _context = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Username = "johndoe",
                Fullname = "John Doe",
                Document = "123456789",
                Birthdate = new DateTime(1990, 1, 1),
                Email = "user.com",
                Phone = "123456789",
                Address = "123 Main St.",
            },
        };

        // GET api/client
        // Summary - Gets all clients
        // Param - None
        // Return - All clients
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return Ok(_context.ToList());
        }

        // GET api/client/5
        // Summary - Gets a client by id
        // Param - id
        // Return - A client
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _context.Find(c => c.Id == id);

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
            _context.Add(client);
            //_context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        // PUT api/client/5
        // Summary - Updates a client
        // Param - id, a client
        // Return - None
        [HttpPut("{id}")]
        public ActionResult<Client> Put(int id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            //_context.Entry(client).State = EntityState.Modified;
            //_context.SaveChanges();

            return NoContent();
        }

        // DELETE api/client/5
        // Summary - Deletes a client
        // Param - id
        // Return - The deleted client
        [HttpDelete("{id}")]
        public ActionResult<Client> Delete(int id)
        {
            var client = _context.Find(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Remove(client);
            //_context.SaveChanges();

            return Ok(client);
        }
    }
}