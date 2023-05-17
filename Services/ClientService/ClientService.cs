using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        private string GetUserRole() => _httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.Role)!;

        public async Task<ServiceResponse<List<GetClientResponseDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetClientResponseDTO>>();

            List<Client> dbClients;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only return the clients that belong to the user
                dbClients = await _context.Clients.Where(c => c.User!.Id == GetUserId()).ToListAsync();
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, return all clients
                dbClients = await _context.Clients.ToListAsync();
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
                serviceResponse.Data = dbClients.Select(c => _mapper.Map<GetClientResponseDTO>(c)).ToList();
                serviceResponse.Success = true;
                serviceResponse.Message = "Clients found";
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientResponseDTO>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientResponseDTO>();

            Client dbClient;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only return the client if it belongs to the user
                dbClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, return the client
                dbClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
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
                if (dbClient is not null)
                {
                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(dbClient);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Client found";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found";
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

        public async Task<ServiceResponse<GetClientResponseDTO>> Post(CreateClientRequestDTO client)
        {
            var serviceResponse = new ServiceResponse<GetClientResponseDTO>();

            try
            {
                var newClient = _mapper.Map<Client>(client);

                newClient.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

                _context.Clients.Add(newClient);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(newClient);
                serviceResponse.Success = true;
                serviceResponse.Message = "Client created successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientResponseDTO>> Put(UpdateClientRequestDTO client)
        {
            var serviceResponse = new ServiceResponse<GetClientResponseDTO>();

            Client updateClient;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only update the client if it belongs to the user
                updateClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, update the client
                updateClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
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
                if (updateClient is not null)
                {
                    updateClient.Username = client.Username;
                    updateClient.Fullname = client.Fullname;
                    updateClient.Document = client.Document;
                    updateClient.Birthdate = client.Birthdate;
                    updateClient.Email = client.Email;
                    updateClient.Phone = client.Phone;
                    updateClient.Address = client.Address;

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(updateClient);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Client updated successfully";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found";
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

        public async Task<ServiceResponse<GetClientResponseDTO>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientResponseDTO>();

            Client deleteClient;

            if (GetUserRole() == "User")
            {
                // If the user is not an admin, only delete the client if it belongs to the user
                deleteClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            }
            else if (GetUserRole() == "Admin")
            {
                // If the user is an admin, delete the client
                deleteClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
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
                if (deleteClient is not null)
                {
                    _context.Clients.Remove(deleteClient);

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(deleteClient);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Client deleted successfully";
                }
                else
                {
                    serviceResponse.Data = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found";
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