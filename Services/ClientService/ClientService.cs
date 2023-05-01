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

        public ActionResult<IEnumerable<Client>> GetAll()
        {
            return _context.ToList();
        }

        public ActionResult<Client> Get(int id)
        {
            var client = _context.Find(c => c.Id == id);

            if (client == null)
            {
                return null;
            }

            return client;
        }

        public ActionResult<Client> Post(Client client)
        {
            _context.Add(client);
            //_context.SaveChanges();

            return client;
        }

        public ActionResult<Client> Put(int id, Client client)
        {
            if (id != client.Id)
            {
                return null;
            }

            //_context.Entry(client).State = EntityState.Modified;
            //_context.SaveChanges();

            return client;
        }

        public ActionResult<Client> Delete(int id)
        {
            var client = _context.Find(c => c.Id == id);

            if (client == null)
            {
                return null;
            }

            _context.Remove(client);
            //_context.SaveChanges();

            return client;
        }
    }
}