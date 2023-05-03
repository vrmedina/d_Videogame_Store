using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace d_Videogame_Store.Services.ClientService
{
    public class ClientService : IClientService
    {
        private static List<Client> _context = new List<Client>()
        {
            new Client()
            {
                Id = 1,
                Username = "johndoe",
                Fullname = "John Doe",
                Document = "123456789",
                Birthdate = new DateTime(1990, 1, 1),
                Email = "user.com",
                Phone = "123456789",
                Address = "123 Main St.",
            },
        };

        public async Task<ServiceResponse<ActionResult<IEnumerable<Client>>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<ActionResult<IEnumerable<Client>>>();

            serviceResponse.Data = _context;
            serviceResponse.Success = true;
            serviceResponse.Message = "Clients found";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ActionResult<Client>>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<ActionResult<Client>>();

            var client = _context.Find(c => c.Id == id);

            if (client is not null)
            {
                serviceResponse.Data = client;
                serviceResponse.Success = true;
                serviceResponse.Message = "Client found";

                return serviceResponse;
            }
            
            throw new Exception("Client not found");
        }

        public async Task<ServiceResponse<ActionResult<Client>>> Post(Client client)
        {
            var serviceResponse = new ServiceResponse<ActionResult<Client>>();

            _context.Add(client);
            //_context.SaveChanges();

            serviceResponse.Data = client;
            serviceResponse.Success = true;
            serviceResponse.Message = "Client created successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ActionResult<Client>>> Put(int id, Client client)
        {
            var serviceResponse = new ServiceResponse<ActionResult<Client>>();
            
            if (id != client.Id)
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "Client not found";

                return serviceResponse;
            }

            //_context.Entry(client).State = EntityState.Modified;
            //_context.SaveChanges();

            serviceResponse.Data = client;
            serviceResponse.Success = true;
            serviceResponse.Message = "Client updated successfully";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ActionResult<Client>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<ActionResult<Client>>();

            var client = _context.Find(c => c.Id == id);

            if (client is not null)
            {
                _context.Remove(client);
                //_context.SaveChanges();

                serviceResponse.Data = client;
                serviceResponse.Success = true;
                serviceResponse.Message = "Client deleted successfully";

                return serviceResponse;
            }

            throw new Exception("Client not found");
        }
    }
}