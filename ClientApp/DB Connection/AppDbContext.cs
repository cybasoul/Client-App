using ClientApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClientApp.DB_Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Client> Clients { get; set; }

        //method to check for duplicate mobile numbers
        public bool IsMobileNumberUnique(string mobileNumber)
        {
            return !Clients.Any(c => c.MobileNumber == mobileNumber);
        }


        // method to check for duplicate ID Numbers
        public bool IsIDNumberUnique(string idNumber)
        {
            return !Clients.Any(c => c.IDNumber == idNumber);
        }

    }
}
