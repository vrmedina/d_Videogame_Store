using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VideogameController : ControllerBase
    {
        private readonly IVideogameService _videogameService;

        public VideogameController(IVideogameService videogameService)
        {
            _videogameService = videogameService;
        }

        /// <summary>
        /// Gets all videogames
        /// </summary>
        /// <param></param>
        /// <returns>A list of videogames</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Videogame/GetAll
        ///     
        /// </remarks>
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetVideogameResponseDTO>>>> GetAll()
        {
            var response = await _videogameService.GetAll();

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Gets a videogame by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A videogame</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Videogame/Get/1
        ///
        /// </remarks>
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<ServiceResponse<GetVideogameResponseDTO>>> Get(int id)
        {
            var response = await _videogameService.Get(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a videogame
        /// </summary>
        /// <param name="videogame"></param>
        /// <returns>A newly created videogame</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Videogame/Post
        ///     {
        ///         "name": "The Last of Us",
        ///         "year": 1990,
        ///         "protagonists": [
        ///             "Joel",
        ///             "Ellie"
        ///         ],
        ///         "director": "Neil Druckmann",
        ///         "producer": "Bruce Straley",
        ///         "platform": "PlayStation 3",
        ///     }
        ///
        /// </remarks>
        [HttpPost("Post")]
        public async Task<ActionResult<ServiceResponse<GetVideogameResponseDTO>>> Post([FromBody] CreateVideogameRequestDTO videogame)
        {
            var response = await _videogameService.Post(videogame);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Updates a videogame
        /// </summary>
        /// <param name="videogame"></param>
        /// <returns>An updated videogame</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Videogame/Put
        ///     {
        ///         "id": 1,
        ///         "name": "The Last of Us",
        ///         "year": 1990,
        ///         "protagonists": [
        ///             "Joel",
        ///             "Ellie"
        ///         ],
        ///         "director": "Neil Druckmann",
        ///         "producer": "Bruce Straley",
        ///         "platform": "PlayStation 3",
        ///     }
        ///
        /// </remarks>
        [HttpPut("Put")]
        public async Task<ActionResult<ServiceResponse<GetVideogameResponseDTO>>> Put([FromBody] UpdateVideogameRequestDTO videogame)
        {
            var response = await _videogameService.Put(videogame);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a videogame
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A deleted videogame</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Videogame/Delete/1
        ///
        /// </remarks>
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetVideogameResponseDTO>>> Delete(int id)
        {
            var response = await _videogameService.Delete(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}