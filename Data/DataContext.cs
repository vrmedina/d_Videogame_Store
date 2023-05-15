using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace d_Videogame_Store.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Client> Clients => Set<Client>();
    }
}