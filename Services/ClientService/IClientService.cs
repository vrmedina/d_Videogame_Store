using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public interface IClientService
    {
        // GET api/Client
        Task<ServiceResponse<List<GetClientResponseDTO>>> GetAll();

        // GET api/Client/5
        Task<ServiceResponse<GetClientResponseDTO>> Get(int id);

        // POST api/Client
        Task<ServiceResponse<GetClientResponseDTO>> Post(CreateClientRequestDTO client);

        // PUT api/Client/
        Task<ServiceResponse<GetClientResponseDTO>> Put(UpdateClientRequestDTO client);

        // DELETE api/Client/5
        Task<ServiceResponse<GetClientResponseDTO>> Delete(int id);
    }
}