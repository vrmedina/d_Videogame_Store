using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public class ClientService : IClientService
    {
        // private static List<Client> _context = new List<Client>()
        // {
        //     new Client()
        //     {
        //         Id = 1,
        //         Username = "johndoe",
        //         Fullname = "John Doe",
        //         Document = "123456789",
        //         Birthdate = new DateTime(1990, 1, 1),
        //         Email = "user.com",
        //         Phone = "123456789",
        //         Address = "123 Main St.",
        //     },
        //     new Client()
        //     {
        //         Id = 2,
        //         Username = "janedoe",
        //         Fullname = "Jane Doe",
        //         Document = "987654321",
        //         Birthdate = new DateTime(1998, 1, 1),
        //         Email = "usuario.com",
        //         Phone = "987654321",
        //         Address = "321 Mani St.",
        //     }
        // };

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
            var dbClients = await _context.Clients.ToListAsync();
            
            try
            {
                var newClient = _mapper.Map<Client>(client);
                newClient.Id = dbClients.Max(c => c.Id) + 1;
    
                dbClients.Add(newClient);
                
                _context.SaveChanges();
    
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
            var dbClients = await _context.Clients.ToListAsync();
            
            try
            {
                var updateClient = dbClients.FirstOrDefault(c => c.Id == client.Id);
    
                if (updateClient is not null)
                {
                    updateClient.Username = client.Username;
                    updateClient.Fullname = client.Fullname;
                    updateClient.Document = client.Document;
                    updateClient.Birthdate = client.Birthdate;
                    updateClient.Email = client.Email;
                    updateClient.Phone = client.Phone;
                    updateClient.Address = client.Address;
    
                    _context.SaveChanges();
    
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
            var dbClients = await _context.Clients.ToListAsync();

            try
            {
                var client = dbClients.Find(c => c.Id == id);

                if (client is not null)
                {
                    _context.Remove(client);
                    
                    _context.SaveChanges();
    
                    serviceResponse.Data = _mapper.Map<GetClientResponseDTO>(client);
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