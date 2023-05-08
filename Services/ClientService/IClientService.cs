using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public interface IClientService
    {
        // GET api/client
        Task<ServiceResponse<ActionResult<IEnumerable<GetClientResponseDTO>>>> GetAll();

        // GET api/client/5
        Task<ServiceResponse<ActionResult<GetClientResponseDTO>>> Get(int id);

        // POST api/client
        Task<ServiceResponse<ActionResult<GetClientResponseDTO>>> Post(CreateClientRequestDTO client);

        // PUT api/client/5
        Task<ServiceResponse<ActionResult<GetClientResponseDTO>>> Put(int id, UpdateClientRequestDTO client);

        // DELETE api/client/5
        Task<ServiceResponse<ActionResult<GetClientResponseDTO>>> Delete(int id);
    }
}