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

        /// <summary>
        /// Gets all clients
        /// </summary>
        /// <param></param>
        /// <returns>A list of clients</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/client/GetAll
        ///     
        /// </remarks>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetClientResponseDTO>>>> GetAll()
        {
            return Ok(await _clientService.GetAll());
        }

        /// <summary>
        /// Gets a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A client</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/client/Get/1
        ///
        /// </remarks>
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientResponseDTO>>> Get(int id)
        {
            var client = await _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>
        /// Creates a client
        /// </summary>
        /// <param name="client"></param>
        /// <returns>A newly created client</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/client/Post
        ///     {
        ///        "username": "johndoe",
        ///        "fullname": "John Doe",
        ///        "document": "123456789",
        ///        "birthdate": "1990-01-01T00:00:00",
        ///        "email": "johndoe123@mail.com",
        ///        "phone": "1234567890",
        ///        "address": "Calle 5 #5-5"
        ///     }
        ///
        /// </remarks>
        [HttpPost("Post")]
        public async Task<ActionResult<ServiceResponse<GetClientResponseDTO>>> Post([FromBody] CreateClientRequestDTO client)
        {
            return Ok(await _clientService.Post(client));
        }

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns>An updated client</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/client/Put/1
        ///     {
        ///        "username": "johndew",
        ///        "fullname": "John Dew",
        ///        "document": "123441518",
        ///        "birthdate": "1990-01-01T00:00:00",
        ///        "email": "johndew123@mailcom",
        ///        "phone": "9876541223",
        ///        "address": "Calle 9 #9-9"
        ///     }
        ///
        /// </remarks>
        [HttpPut("Put/{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientResponseDTO>>> Put(int id, [FromBody] UpdateClientRequestDTO client)
        {
            return Ok(await _clientService.Put(id, client));
        }

        /// <summary>
        /// Deletes a client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A deleted client</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/client/Delete/1
        ///
        /// </remarks>
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientResponseDTO>>> Delete(int id)
        {
            var client = await _clientService.Delete(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
    }
}