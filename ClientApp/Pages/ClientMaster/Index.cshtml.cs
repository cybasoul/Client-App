using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientApp.DB_Connection;
using ClientApp.Models;

namespace ClientApp.Pages.ClientMaster
{
    public class IndexModel : PageModel
    {
        private readonly ClientApp.DB_Connection.AppDbContext _context;

        public IndexModel(ClientApp.DB_Connection.AppDbContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Clients.ToListAsync();
        }
    }
}
