using System.Data.Entity;
using DBTest.Models;

namespace DBTest.DataAccessLayer
{
    public class ServerContext : DbContext
    {
        public ServerContext() : base("ServerContext")
        {
        }

        public DbSet<HostServer> HostServers { get; set; }
        public DbSet<ServerSlot> ServerSlots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<ServerType> ServerTypes { get; set; }
    }
}