using Client_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Client_App.Data
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");

            // Configure other entity properties, keys, etc.
        }
    }
}