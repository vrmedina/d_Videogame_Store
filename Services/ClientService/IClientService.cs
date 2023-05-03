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
        Task<ServiceResponse<ActionResult<IEnumerable<Client>>>> GetAll();

        // GET api/client/5
        Task<ServiceResponse<ActionResult<Client>>> Get(int id);

        // POST api/client
        Task<ServiceResponse<ActionResult<Client>>> Post(Client client);

        // PUT api/client/5
        Task<ServiceResponse<ActionResult<Client>>> Put(int id, Client client);

        // DELETE api/client/5
        Task<ServiceResponse<ActionResult<Client>>> Delete(int id);
    }
}