using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d_Videogame_Store
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Maps for Client
            CreateMap<Client, GetClientResponseDTO>();
            CreateMap<CreateClientRequestDTO, Client>();
            CreateMap<CreateClientRequestDTO, GetClientResponseDTO>();
            CreateMap<UpdateClientRequestDTO, Client>();
            // Maps for Videogame
            CreateMap<Videogame, GetVideogameResponseDTO>();
            CreateMap<CreateVideogameRequestDTO, Videogame>();
            CreateMap<CreateVideogameRequestDTO, GetVideogameResponseDTO>();
            CreateMap<UpdateVideogameRequestDTO, Videogame>();
        }
    }
}