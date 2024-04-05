using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientApp.DB_Connection;
using ClientApp.Models;

namespace ClientApp.Pages.ClientMaster
{
    public class SearchModel : PageModel
    {
        private readonly ClientApp.DB_Connection.AppDbContext _context;

        public SearchModel(ClientApp.DB_Connection.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string SearchTerm { get; set; } // User input for search

        public List<Client> SearchResults { get; set; } // Results to display

        public void OnGet()
        {
            // Initialize the search result
            SearchResults = new List<Client>();
        }

        public IActionResult OnPost()
        {
            // Query the database based on user input
            SearchResults = _context.Clients
                .Where(c =>
                    c.FirstName.Contains(SearchTerm) ||
                    c.IDNumber.Contains(SearchTerm) ||
                    c.MobileNumber.Contains(SearchTerm))
                .ToList();

            return Page();
        }
    }

}
