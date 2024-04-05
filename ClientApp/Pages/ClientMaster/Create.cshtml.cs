using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClientApp.DB_Connection;
using ClientApp.Models;

namespace ClientApp.Pages.ClientMaster
{
    public class CreateModel : PageModel
    {
        private readonly ClientApp.DB_Connection.AppDbContext _context;

        public CreateModel(ClientApp.DB_Connection.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Validate the mobile number
            if (!_context.IsMobileNumberUnique(Client.MobileNumber))
            {
                ModelState.AddModelError("Client.MobileNumber", "Mobile Number already exists.");
                return Page();
            }

            // Validate the ID Number
            if (!IDValidationHelper.IsSouthAfricanIDValid(Client.IDNumber))
            {
                ModelState.AddModelError("Client.IDNumber", "Invalid or duplicate ID Number.");
                return Page();
            }

            // Check if the ID Number is unique
            if (!_context.IsIDNumberUnique(Client.IDNumber))
            {
                ModelState.AddModelError("Client.IDNumber", "ID Number already exists.");
                return Page();
            }


            // Save client data to DB

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
