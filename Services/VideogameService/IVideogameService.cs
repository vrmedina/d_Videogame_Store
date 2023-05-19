using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.VideogameService
{
    public interface IVideogameService
    {
        // GET api/Videogame
        Task<ServiceResponse<List<GetVideogameResponseDTO>>> GetAll();

        // GET api/Videogame/5
        Task<ServiceResponse<GetVideogameResponseDTO>> Get(int id);

        // POST api/Videogame
        Task<ServiceResponse<GetVideogameResponseDTO>> Post(CreateVideogameRequestDTO Videogame);

        // PUT api/Videogame/
        Task<ServiceResponse<GetVideogameResponseDTO>> Put(UpdateVideogameRequestDTO Videogame);

        // DELETE api/Videogame/5
        Task<ServiceResponse<GetVideogameResponseDTO>> Delete(int id);
    }
}