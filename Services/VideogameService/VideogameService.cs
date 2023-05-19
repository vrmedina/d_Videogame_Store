using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.VideogameService
{
    public class VideogameService : IVideogameService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VideogameService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        private string GetUserRole() => _httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.Role)!;

        public async Task<ServiceResponse<List<GetVideogameResponseDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetVideogameResponseDTO>>();

            List<Videogame> dbVideogames;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only return the Videogames that belong to the user
                dbVideogames = await _context.Videogames.Where(c => c.User!.Id == GetUserId()).ToListAsync();
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, return all Videogames
                dbVideogames = await _context.Videogames.ToListAsync();
            }
            else
            {
                // If the user is not an admin or a user, return an error
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            try
            {
                serviceResponse.Data = dbVideogames.Select(c => _mapper.Map<GetVideogameResponseDTO>(c)).ToList();
                serviceResponse.Success = true;
                serviceResponse.Message = "Videogames found";
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameResponseDTO>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<GetVideogameResponseDTO>();

            Videogame dbVideogame;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only return the Videogame if it belongs to the user
                dbVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, return the Videogame
                dbVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                // If the user is not an admin or a user, return an error
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            try
            {
                if (dbVideogame is not null)
                {
                    serviceResponse.Data = _mapper.Map<GetVideogameResponseDTO>(dbVideogame);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Videogame found";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Videogame not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameResponseDTO>> Post(CreateVideogameRequestDTO Videogame)
        {
            var serviceResponse = new ServiceResponse<GetVideogameResponseDTO>();

            try
            {
                var newVideogame = _mapper.Map<Videogame>(Videogame);

                newVideogame.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

                _context.Videogames.Add(newVideogame);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetVideogameResponseDTO>(newVideogame);
                serviceResponse.Success = true;
                serviceResponse.Message = "Videogame created successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameResponseDTO>> Put(UpdateVideogameRequestDTO Videogame)
        {
            var serviceResponse = new ServiceResponse<GetVideogameResponseDTO>();

            Videogame updateVideogame;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only update the Videogame if it belongs to the user
                updateVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == Videogame.Id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, update the Videogame
                updateVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == Videogame.Id);
            }
            else
            {
                // If the user is not an admin or a user, return an error
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            try
            {
                if (updateVideogame is not null)
                {
                    updateVideogame.Name = Videogame.Name;
                    updateVideogame.Year = Videogame.Year;
                    updateVideogame.Protagonists = Videogame.Protagonists;
                    updateVideogame.Director = Videogame.Director;
                    updateVideogame.Producer = Videogame.Producer;
                    updateVideogame.Platform = Videogame.Platform;

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetVideogameResponseDTO>(updateVideogame);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Videogame updated successfully";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Videogame not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVideogameResponseDTO>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<GetVideogameResponseDTO>();

            Videogame deleteVideogame;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only delete the Videogame if it belongs to the user
                deleteVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, delete the Videogame
                deleteVideogame = await _context.Videogames.FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                // If the user is not an admin or a user, return an error
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }

            try
            {
                if (deleteVideogame is not null)
                {
                    _context.Videogames.Remove(deleteVideogame);

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetVideogameResponseDTO>(deleteVideogame);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Videogame deleted successfully";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Videogame not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}