using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ClientService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetClientResponseDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetClientResponseDTO>>();
            var dbClients = await _context.Clients.ToListAsync();

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
            var dbClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                if (dbClient is not null)
                {
                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(dbClient);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Client found";
                } else
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
            var updateClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == client.Id);
            
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
                } else
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
            var deleteClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                if (deleteClient is not null)
                {
                    _context.Clients.Remove(deleteClient);
                    
                    await _context.SaveChangesAsync();
    
                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(deleteClient);
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Client deleted successfully";
                } else
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