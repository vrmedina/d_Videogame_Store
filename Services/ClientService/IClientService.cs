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
        // Summary - Gets all clients
        // Param - None
        // Return - All clients
        ActionResult<IEnumerable<Client>> GetAll();

        // GET api/client/5
        // Summary - Gets a client by id
        // Param - id
        // Return - A client
        ActionResult<Client> Get(int id);

        // POST api/client
        // Summary - Creates a client
        // Param - A client object
        // Return - The created client
        ActionResult<Client> Post(Client client);

        // PUT api/client/5
        // Summary - Updates a client
        // Param - id, a client object
        // Return - The updated client
        ActionResult<Client> Put(int id, Client client);

        // DELETE api/client/5
        // Summary - Deletes a client
        // Param - id
        // Return - The deleted client
        ActionResult<Client> Delete(int id);
    }
}